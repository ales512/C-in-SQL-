using System.Windows.Forms;

namespace vaje_stroka___prava_verzija_c_
{
    public partial class Form1 : Form
    {
   
        public static string SetValueForText1 = "";
      
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Form2.SetValueForText1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformOperation("Add");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperation("Subtract");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PerformOperation("Multiply");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PerformOperation("Divide");
        }

        private void PerformOperation(string operation)
        {
            try
            {
                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);

                CRacunaj c = new CRacunaj(num1, num2);
                decimal rez = 0;

                switch (operation)
                {
                    case "Add":
                        rez = c.Add();
                        break;
                    case "Subtract":
                        rez = c.Subtract();
                        break;
                    case "Multiply":
                        rez = c.Multiply();
                        break;
                    case "Divide":
                        rez = c.Divide();
                        break;
                }
                textBox3.Text = rez.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetValueForText1 = textBox3.Text;
            Form2 frm2 = new Form2();

            frm2.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
