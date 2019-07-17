using System;
using System.Windows.Forms;
using BL.Models;

namespace CostaContest.Forms
{
    public partial class UserForm : Form
    {
        private bool _needSave;
        public Employee Employee { get; private set; }
        public UserForm(Department department) : this()
        {
            Employee = new Employee()
            {
                Department = department,
                DepartmentID = department.Id
            };
        }

        public UserForm(Employee employee, bool edit = false) : this()
        {
            Employee = employee;
            if (!edit)
            {
                _needSave = false;
                btnSave.Text = "Закрыть";
                LockEditing();
            }
        }

        private UserForm()
        {
            InitializeComponent();
            _needSave = true;
        }

        #region Events

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_needSave)
            {
                if (!UpdateUserData())
                {
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            SetUserData();
        }

        #endregion

        #region Actions
        
        private void LockEditing()
        {
            tbxName.ReadOnly = true;
            tbxSurname.ReadOnly = true;
            tbxPatronymic.ReadOnly = true;
            tbxPost.ReadOnly = true;
            tbxDocSer.ReadOnly = true;
            tbxDocNum.ReadOnly = true;
        }

        private bool UpdateUserData()
        {
            try
            {
                Employee.FirstName = tbxName.Text;
                Employee.SurName = tbxSurname.Text;
                Employee.Patronymic = tbxPatronymic.Text;
                Employee.DateOfBirth = dtDateOfBirth.Value;
                Employee.Position = tbxPost.Text;
                Employee.DocSeries = tbxDocSer.Text;
                Employee.DocNumber = tbxDocNum.Text;
            }
            catch (Exception e)
            {
                ShowError(e.Message);
                return false;
            }
            return true;
        }

        private void SetUserData()
        {
            tbxName.Text = Employee.FirstName;
            tbxSurname.Text = Employee.SurName;
            tbxPatronymic.Text = Employee.Patronymic;
            dtDateOfBirth.Value = Employee.DateOfBirth;
            tbxDepart.Text = Employee.Department?.Name;
            tbxPost.Text = Employee.Position;
            tbxAge.Text = Employee.Age.ToString();
            tbxDocSer.Text = Employee.DocSeries;
            tbxDocNum.Text = Employee.DocNumber;
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Ошибка вводы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
