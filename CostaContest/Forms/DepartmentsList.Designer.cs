namespace CostaContest.Forms
{
    partial class DepartmentsList
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
            this.departmentsTreeView = new System.Windows.Forms.TreeView();
            this.employeesDataGridView = new System.Windows.Forms.DataGridView();
            this.empEditBtn = new System.Windows.Forms.Button();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.showEmpBnt = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depGroupBox = new System.Windows.Forms.GroupBox();
            this.empGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).BeginInit();
            this.depGroupBox.SuspendLayout();
            this.empGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // departmentsTreeView
            // 
            this.departmentsTreeView.Location = new System.Drawing.Point(6, 19);
            this.departmentsTreeView.Name = "departmentsTreeView";
            this.departmentsTreeView.Size = new System.Drawing.Size(308, 442);
            this.departmentsTreeView.TabIndex = 0;
            this.departmentsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DepartmentsTreeView_AfterSelect);
            // 
            // employeesDataGridView
            // 
            this.employeesDataGridView.AllowUserToAddRows = false;
            this.employeesDataGridView.AllowUserToDeleteRows = false;
            this.employeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SurName,
            this.FirstName,
            this.Patronymic,
            this.Position});
            this.employeesDataGridView.Location = new System.Drawing.Point(6, 19);
            this.employeesDataGridView.Name = "employeesDataGridView";
            this.employeesDataGridView.ReadOnly = true;
            this.employeesDataGridView.Size = new System.Drawing.Size(519, 442);
            this.employeesDataGridView.TabIndex = 1;
            this.employeesDataGridView.SelectionChanged += new System.EventHandler(this.EmployeesDataGridView_SelectionChanged);
            // 
            // empEditBtn
            // 
            this.empEditBtn.Location = new System.Drawing.Point(424, 471);
            this.empEditBtn.Name = "empEditBtn";
            this.empEditBtn.Size = new System.Drawing.Size(101, 35);
            this.empEditBtn.TabIndex = 6;
            this.empEditBtn.Text = "Редактирование сотрудника";
            this.empEditBtn.UseVisualStyleBackColor = true;
            this.empEditBtn.Click += new System.EventHandler(this.EmpEditBtn_Click);
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(6, 467);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(101, 35);
            this.btnAddEmp.TabIndex = 7;
            this.btnAddEmp.Text = "Добавить сотруднка";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.BtnAddEmp_Click);
            // 
            // showEmpBnt
            // 
            this.showEmpBnt.Location = new System.Drawing.Point(317, 471);
            this.showEmpBnt.Name = "showEmpBnt";
            this.showEmpBnt.Size = new System.Drawing.Size(101, 35);
            this.showEmpBnt.TabIndex = 8;
            this.showEmpBnt.Text = "Просмотр";
            this.showEmpBnt.UseVisualStyleBackColor = true;
            this.showEmpBnt.Click += new System.EventHandler(this.ShowEmpBnt_Click);
            // 
            // Id
            // 
            this.Id.Frozen = true;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // SurName
            // 
            this.SurName.Frozen = true;
            this.SurName.HeaderText = "Фамиля";
            this.SurName.Name = "SurName";
            this.SurName.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // Patronymic
            // 
            this.Patronymic.HeaderText = "Отчество";
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "Должность";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // depGroupBox
            // 
            this.depGroupBox.Controls.Add(this.departmentsTreeView);
            this.depGroupBox.Controls.Add(this.btnAddEmp);
            this.depGroupBox.Location = new System.Drawing.Point(12, 13);
            this.depGroupBox.Name = "depGroupBox";
            this.depGroupBox.Size = new System.Drawing.Size(325, 512);
            this.depGroupBox.TabIndex = 9;
            this.depGroupBox.TabStop = false;
            this.depGroupBox.Text = "Отделы";
            // 
            // empGroupBox
            // 
            this.empGroupBox.Controls.Add(this.employeesDataGridView);
            this.empGroupBox.Controls.Add(this.showEmpBnt);
            this.empGroupBox.Controls.Add(this.empEditBtn);
            this.empGroupBox.Location = new System.Drawing.Point(343, 13);
            this.empGroupBox.Name = "empGroupBox";
            this.empGroupBox.Size = new System.Drawing.Size(531, 512);
            this.empGroupBox.TabIndex = 10;
            this.empGroupBox.TabStop = false;
            this.empGroupBox.Text = "Сотрудники отдела";
            // 
            // DepartmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 539);
            this.Controls.Add(this.empGroupBox);
            this.Controls.Add(this.depGroupBox);
            this.Name = "DepartmentsList";
            this.Text = "DepartmentsList";
            this.Load += new System.EventHandler(this.DepartmentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeesDataGridView)).EndInit();
            this.depGroupBox.ResumeLayout(false);
            this.empGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView departmentsTreeView;
        private System.Windows.Forms.DataGridView employeesDataGridView;
        private System.Windows.Forms.Button empEditBtn;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.Button showEmpBnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.GroupBox depGroupBox;
        private System.Windows.Forms.GroupBox empGroupBox;
    }
}