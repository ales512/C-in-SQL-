using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

/*Naloga crud:
V gridu izpiši vse oddelke (HumanResources.Department). Omogoči dodajanje, brisanje in spreminjanje
oddelka. V kolikor obstaja relacija v bazi uporabnika na lep način opozori, da oddelka ni mogoče izbrisati.
*/

namespace CRUD
{
    public partial class Form1 : Form
    {

        private const string connectionString = "Data Source=DESKTOP-H7R6E44\\SQLEXPRESS;Initial Catalog=AdventureWorks2022;Integrated Security=True;";
        private SqlDataAdapter adapter;
        private DataTable departmentsTable;
        private SqlConnection _connection;

        private object departmentID;

        public Form1()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DepartmentID, Name, GroupName FROM HumanResources.Department";
                    adapter = new SqlDataAdapter(query, connection);
                    departmentsTable = new DataTable();
                    adapter.Fill(departmentsTable);
                    dataGridViewDepartments.DataSource = departmentsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string groupName = textBox2.Text;
            AddDepartment(name, groupName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddDepartment(string name, string department)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = "INSERT INTO HumanResources.Department (Name, GroupName) VALUES (@Name, @GroupName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@GroupName", department);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                LoadDepartments();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Napaka" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDepartment(int departmentID, string name, string groupName)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE HumanResources.Department SET Name = @Name, GroupName = @GroupName WHERE DepartmentID = @DepartmentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@GroupName", groupName);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating department: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteDepartment(int departmentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM HumanResources.Department WHERE DepartmentID = @DepartmentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", departmentID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    LoadDepartments();
                }
            }
            catch (SqlException ex) when (ex.Number == 547) // Foreign Key violation
            {
                MessageBox.Show("Cannot delete this department as it has related records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting department: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["DepartmentID"].Value);
                string name = textBox1.Text;
                string groupName = textBox2.Text;
                UpdateDepartment(departmentID, name, groupName);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["DepartmentID"].Value);
                DeleteDepartment(departmentID);
            }
        }

        private void dataGridViewDepartments_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridViewDepartments.SelectedRows[0].Cells["Name"].Value.ToString();
                textBox2.Text = dataGridViewDepartments.SelectedRows[0].Cells["GroupName"].Value.ToString();
            }
        }
    }
}
