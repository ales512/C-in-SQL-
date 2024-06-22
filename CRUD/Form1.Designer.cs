
namespace CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewDepartments = new DataGridView();
            textBox1 = new TextBox();
            Add = new Button();
            Delete = new Button();
            Update = new Button();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDepartments
            // 
            dataGridViewDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDepartments.Location = new Point(79, 133);
            dataGridViewDepartments.Name = "dataGridViewDepartments";
            dataGridViewDepartments.RowHeadersWidth = 51;
            dataGridViewDepartments.Size = new Size(1225, 516);
            dataGridViewDepartments.TabIndex = 0;
            dataGridViewDepartments.CellContentClick += dataGridViewDepartments_CellContentClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 27);
            textBox1.TabIndex = 1;
            // 
            // Add
            // 
            Add.Location = new Point(434, 33);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 2;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(675, 35);
            Delete.Name = "Delete";
            Delete.Size = new Size(94, 29);
            Delete.TabIndex = 3;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Update
            // 
            Update.Location = new Point(555, 33);
            Update.Name = "Update";
            Update.Size = new Size(94, 29);
            Update.TabIndex = 4;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(812, 33);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(304, 27);
            textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1393, 814);
            Controls.Add(textBox2);
            Controls.Add(Update);
            Controls.Add(Delete);
            Controls.Add(Add);
            Controls.Add(textBox1);
            Controls.Add(dataGridViewDepartments);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dataGridViewDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        #endregion

        private DataGridView dataGridViewDepartments;
        private TextBox textBox1;
        private Button Add;
        private Button Delete;
        private Button Update;
        private TextBox textBox2;
    }
}
