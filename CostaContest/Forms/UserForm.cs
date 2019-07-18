using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BL.Models;

namespace CostaContest.Forms
{
    public partial class UserForm : EditorBase
    {
        private readonly IEnumerable<Department> _departments;

        public Employee Employee { get; private set; }

        #region Constructors

        /// <summary>
        /// Конструктор создания сотрудника
        /// </summary>
        /// <param name="department">Отдел сотрудника</param>
        public UserForm(Department department) : this(new Employee(department), new Department[] { department }, ShowingMode.Creating)
        {
        }

        /// <summary>
        /// Конструктор просмотра
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public UserForm(Employee employee) : this(employee, new Department[0], ShowingMode.Showing)
        {
        }

        /// <summary>
        /// Конструктор редактирования
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="departments">Доступные отделы</param>
        /// <param name="mode">Режим показа</param>
        public UserForm(Employee employee, IEnumerable<Department> departments, ShowingMode mode = ShowingMode.Editing) : this()
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _departments = departments ?? throw new ArgumentNullException(nameof(departments));
            SetMode(mode);
        }

        private UserForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Mode != ShowingMode.Showing)
            {
                if (!CheckModel())
                {
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Actions
        
        protected override void LockEditing()
        {
            tbxName.ReadOnly = true;
            tbxSurname.ReadOnly = true;
            tbxPatronymic.ReadOnly = true;
            tbxPost.ReadOnly = true;
            tbxDocSer.ReadOnly = true;
            tbxDocNum.ReadOnly = true;
            cbxDepart.Visible = false;
            btnSave.Text = "Закрыть";
        }

        protected override bool UpdateData()
        {
            Employee.FirstName = tbxName.Text;
            Employee.SurName = tbxSurname.Text;
            Employee.Patronymic = tbxPatronymic.Text;
            Employee.DateOfBirth = dtDateOfBirth.Value;
            Employee.Position = tbxPost.Text;
            Employee.DocSeries = tbxDocSer.Text;
            Employee.DocNumber = tbxDocNum.Text;

            Employee.Department = (Department)cbxDepart.SelectedItem;

            return true;
        }

        protected override void SetData()
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

            cbxDepart.Items.AddRange(_departments.ToArray());
            cbxDepart.SelectedItem = Employee.Department;
        }

        #endregion
    }
}
