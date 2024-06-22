using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Napiši C# aplikacijo, ki v DataGridView-u prikaže vsa imena ter priimke zaposlenih. Omogoči tudi
filtriranje rezultatov po imenu/priimku. (Baza AdventureWorks). Zadeve se lahko lotiš na poljuben
način (ado.net, linq to sql,...).*/

/* Naloga 5


    Naloga master-detail.
	Dodelaj nalogo 4 tako, da za vsakega zaposlenega v drugem gridu izpišeš zgodovino plač za izbranega
	zaposlenega HumanResources.EmployeePayHistory (master-detail).

*/

namespace DataGrid_in_ADO.net
{


    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=DESKTOP-H7R6E44\\SQLEXPRESS;Initial Catalog=AdventureWorks2022;Integrated Security=True;";
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        private SqlConnection _connection;
        private SqlDataAdapter _employeesDataAdapter;
        private DataSet _dataSet;
        private SqlDataAdapter _payHistoryDataAdapter;


        public Form1()
        {
            InitializeComponent();
            _connection = new SqlConnection(connectionString);
            InitializeData();
        }

        private void InitializeData()
        {
            string sqlQuery = @"
                        SELECT
                            eph.RateChangeDate,
                            eph.Rate,
                            eph.PayFrequency,
                            pp.FirstName,
                            pp.LastName
                        FROM
                            HumanResources.EmployeePayHistory AS eph
                        INNER JOIN
                            Person.Person AS pp ON eph.BusinessEntityID = pp.BusinessEntityID;
                    ";
            _dataSet = new DataSet();
            // Employees grid setup
            _employeesDataAdapter = new SqlDataAdapter(sqlQuery, _connection);
            _employeesDataAdapter.Fill(_dataSet, "Employees");

            dataGridView2.DataSource = _dataSet.Tables["Employees"];

            // Pay history grid setup (empty initially)
            DataTable payHistoryTable = new DataTable("PayHistory");
            payHistoryTable.Columns.Add("RateChangeDate", typeof(DateTime));
            payHistoryTable.Columns.Add("Rate", typeof(decimal));
            payHistoryTable.Columns.Add("PayFrequency", typeof(string));
            payHistoryTable.Columns.Add("FirstName", typeof(string));
            payHistoryTable.Columns.Add("LastName", typeof(string));

            _dataSet.Tables.Add(payHistoryTable);

            dataGridView2.DataSource = _dataSet.Tables["PayHistory"];
            // Add event handler for employee selection change
            dataGridView1.SelectionChanged += dataGridViewEmployees_SelectionChanged;

            // Ensure single event subscription
            dataGridView1.SelectionChanged -= dataGridViewEmployees_SelectionChanged; // Unsubscribe first to avoid duplicate subscription
            dataGridView1.SelectionChanged += dataGridViewEmployees_SelectionChanged;
        }
        private void LoadPayHistory(int employeeID)
        {
            // Clear previous pay history data
            _dataSet.Tables["PayHistory"].Rows.Clear();

            // Load new pay history data
            string sqlQuery = @"
                        SELECT
                            eph.RateChangeDate,
                            eph.Rate,
                            eph.PayFrequency,
                            pp.FirstName,
                            pp.LastName
                        FROM
                            HumanResources.EmployeePayHistory AS eph
                        INNER JOIN
                            Person.Person AS pp ON eph.BusinessEntityID = @EmployeeID;
                    ";
            string query = sqlQuery;

            /* SqlCommand command = new SqlCommand(query, _connection);
             command.Parameters.AddWithValue("@EmployeeID", employeeID);

             SqlDataAdapter adapter = new SqlDataAdapter(command);
             adapter.Fill(_dataSet.Tables["PayHistory"]);*/


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    _payHistoryDataAdapter = new SqlDataAdapter(command);
                    _payHistoryDataAdapter.Fill(_dataSet.Tables["PayHistory"]);
                }
            }
        }

        private void dataGridViewEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedEmployeeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BusinessEntityID"].Value);
                LoadPayHistory(selectedEmployeeID);
            }
            else
            {
                _dataSet.Tables["PayHistory"].Rows.Clear();
            }
        }
    
    private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT BusinessEntityID, FirstName, LastName FROM Person.Person";
                    adapter = new SqlDataAdapter(query, connection);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Napaka! " + ex.Message);
                }
            }
        }
        private void FilterData(string filter)
        {
            if (dataTable != null)
            {
                dataTable.DefaultView.RowFilter = $"FirstName LIKE '%{filter}%' OR LastName LIKE '%{filter}%'";
                if (dataTable.DefaultView.Count == 0)
                {
                    _dataSet.Tables["PayHistory"].Rows.Clear();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterData(textBox1.Text);
        }

        /* private void textBoxFilter_TextChanged(object sender, EventArgs e)
         {
             FilterData(textBoxFilter.Text);
         }*/

    }
}
