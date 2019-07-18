using BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostaContest.Forms
{
    public partial class DepartmentForm : EditorBase
    {
        public Department Department { get; private set; }
        public IEnumerable<Department> AllDepartments { get; }

        /// <summary>
        /// Конструктор по умолчанию для отрисовки формы
        /// </summary>
        private  DepartmentForm() : this(new Department(), new Department[0], ShowingMode.Creating)
        {
        }

        /// <summary>
        /// Конструктор создания отдела
        /// </summary>
        /// <param name="departments">Коллекция доступных отделов</param>
        public DepartmentForm(Department[] departments) : this(new Department(), departments, ShowingMode.Creating)
        {
        }

        /// <summary>
        /// Конструктор просмотра
        /// </summary>
        /// <param name="department">Отдел для просмотра</param>
        public DepartmentForm(Department department) : this(department, new Department[0], ShowingMode.Showing)
        {
        }

        /// <summary>
        /// Конструктор редактирования
        /// </summary>
        /// <param name="department">Отдел для редактирования</param>
        /// <param name="allDepartments">Доступные отделы</param>
        /// <param name="mode">Режим отображения</param>
        public DepartmentForm(Department department, IEnumerable<Department> allDepartments, ShowingMode mode = ShowingMode.Editing)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
            AllDepartments = allDepartments ?? throw new ArgumentNullException(nameof(allDepartments));
            InitializeComponent();
            SetMode(mode);
            cbxParent.Items.AddRange(allDepartments.ToArray());
            if (department.ParentDepartmen != null)
            {
                cbxParent.SelectedItem = department.ParentDepartmen;
            }
        }

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
            tbxCode.ReadOnly = true;
            btnSave.Text = "Закрыть";
            //TODO: Блокировка родительского отдела
        }

        protected override bool UpdateData()
        {
            Department.Name = tbxName.Text;
            Department.Code = tbxCode.Text;
            Department.ParentDepartmen = (Department)cbxParent.SelectedItem;

            return true;
        }

        protected override void SetData()
        {
            tbxName.Text = Department.Name;
            tbxCode.Text = Department.Code;
            if (Department.ParentDepartmen != null && !cbxParent.Items.Contains(Department.ParentDepartmen))
            {
                cbxParent.Items.Add(Department.ParentDepartmen);
            }
            cbxParent.SelectedItem = Department.ParentDepartmen;
        }

        #endregion
    }
}
