using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vaje_stroka___prava_verzija_c_
{
    public partial class Form2 : Form
    {
        public static string SetValueForText1 = "";

        Form f = new Form();
        public Form2()
        {
            InitializeComponent();
            //form.Show();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.SetValueForText1;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperation("Subtract");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformOperation("Add");
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
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetValueForText1 = textBox3.Text;
            Form1 frm2 = new Form1();

            frm2.Show();
        }
    }
}
