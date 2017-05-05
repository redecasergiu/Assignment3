namespace StudentsClient
{
    partial class formStudents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridStudents = new System.Windows.Forms.DataGridView();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateRegistered = new System.Windows.Forms.DateTimePicker();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStudents
            // 
            this.gridStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStudents.Location = new System.Drawing.Point(57, 62);
            this.gridStudents.Name = "gridStudents";
            this.gridStudents.Size = new System.Drawing.Size(410, 150);
            this.gridStudents.TabIndex = 0;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(204, 246);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(95, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Get Students";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(519, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(519, 97);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // dateRegistered
            // 
            this.dateRegistered.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRegistered.Location = new System.Drawing.Point(577, 91);
            this.dateRegistered.Name = "dateRegistered";
            this.dateRegistered.Size = new System.Drawing.Size(100, 20);
            this.dateRegistered.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(577, 59);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(152, 20);
            this.tbName.TabIndex = 5;
            // 
            // tbAge
            // 
            this.tbAge.Location = new System.Drawing.Point(577, 128);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(39, 20);
            this.tbAge.TabIndex = 7;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(519, 131);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Age";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(577, 173);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // formStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 293);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dateRegistered);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.gridStudents);
            this.Name = "formStudents";
            this.Text = "Students";
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridStudents;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateRegistered;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Button btnAdd;
    }
}

