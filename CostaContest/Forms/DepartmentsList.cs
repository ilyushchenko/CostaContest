using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using BL.Models;

namespace CostaContest.Forms
{
    public partial class DepartmentsList : Form
    {
        EmployeesManager _employeesManager;
        DepartmentsManager _departmentsManager;
        Department _currentDepartment;
        Employee _currentEmployee;

        public DepartmentsList()
        {
            _departmentsManager = new DepartmentsManager();
            _employeesManager = new EmployeesManager();
            InitializeComponent();
        }

        private void DepartmentsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            employeesDataGridView.Rows.Clear();

            if (e.Node.Tag is Department department)
            {
                _currentDepartment = department;
                UpdateEmployees();
            }
        }

        private async void DepartmentsList_Load(object sender, EventArgs e)
        {
            await UpdateDataAsync();
        }

        private void EmployeesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRow = employeesDataGridView.Rows[employeesDataGridView.CurrentCell.RowIndex];

            if (selectedRow.IsNewRow)
            {
                return;
            }

            var userId = selectedRow.Cells[0].Value.ToString();
            var id = decimal.Parse(userId);

            _currentEmployee = _employeesManager.GetById(id);
        }

        #region CRUD Employees

        private void ShowEmpBnt_Click(object sender, EventArgs e)
        {
            if (!IsEmployeeSelected()) return;

            var userForm = new UserForm(_currentEmployee);
            userForm.ShowDialog();
        }

        private void BtnAddEmp_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentSelected()) return;

            var userForm = new UserForm(_currentDepartment);
            var result = userForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            if (!_employeesManager.Create(userForm.Employee))
            {
                MessageBox.Show("Произошла ошибка, при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateEmployees();
        }

        private async void EmpEditBtn_Click(object sender, EventArgs e)
        {
            if (!IsEmployeeSelected()) return;

            var departments = await _departmentsManager.GetDepartmentsAsync();

            var userForm = new UserForm(_currentEmployee, departments);
            var result = userForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            if (!_employeesManager.Update(userForm.Employee))
            {
                MessageBox.Show("Произошла ошибка, при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateEmployees();
        }

        #endregion

        #region CRUD Departments

        private async void BtnAddDep_Click(object sender, EventArgs e)
        {
            var departments = await _departmentsManager.GetDepartmentsAsync();
            var departmentForm = new DepartmentForm(departments);
            var result = departmentForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            if (!_departmentsManager.Create(departmentForm.Department))
            {
                MessageBox.Show("Произошла ошибка, при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await UpdateDataAsync();
        }

        private async void BtnEditDep_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentSelected()) return;

            var departments = await _departmentsManager.GetDepartmentsAsync();
            var departmentForm = new DepartmentForm(_currentDepartment, departments);

            var result = departmentForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            if (!_departmentsManager.Update(departmentForm.Department))
            {
                MessageBox.Show("Произошла ошибка, при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await UpdateDataAsync();
        }

        private void BtnShowDep_Click(object sender, EventArgs e)
        {
            if (!IsDepartmentSelected()) return;

            var departmentForm = new DepartmentForm(_currentDepartment);
            departmentForm.ShowDialog();
        }

        #endregion

        #region Helpers

        private bool IsDepartmentSelected()
        {
            if (_currentDepartment == null)
            {
                MessageBox.Show("Вы не выбрали отдел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool IsEmployeeSelected()
        {
            if (_currentEmployee == null)
            {
                MessageBox.Show("Вы не выбрали сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region Updaters

        public async Task UpdateDataAsync()
        {
            // Clear previous data
            _currentDepartment = null;
            _currentEmployee = null;
            await UpdateDepartments();
            UpdateEmployees();
        }

        private async Task UpdateDepartments()
        {
            departmentsTreeView.Nodes.Clear();

            // Full new data
            var departments = await Task.Run(() => _departmentsManager.GetDepartments());
            var rootDepertments = departments.Where(d => !d.ParentDepartmentId.HasValue).ToArray();

            //TODO: Удалить дублирование
            foreach (var department in rootDepertments)
            {
                var node = new TreeNode(department.ToString()) { Name = department.Id.ToString(), Tag = department };
                departmentsTreeView.Nodes.Add(node);
                FillNode(node, department);
            }
        }
        private void FillNode(TreeNode node, Department department)
        {
            foreach (var subDepartment in department.SubDepartmenents)
            {
                var subNode = new TreeNode(subDepartment.ToString()) { Name = subDepartment.Id.ToString(), Tag = subDepartment };
                node.Nodes.Add(subNode);
                FillNode(subNode, subDepartment);
            }
        }

        private void UpdateEmployees()
        {
            employeesDataGridView.Rows.Clear();

            if (_currentDepartment == null) return;

            foreach (var employee in _currentDepartment.Empoyees)
            {
                employeesDataGridView.Rows.Add(new[] {
                    employee.ID.ToString(),
                    employee.FirstName,
                    employee.SurName,
                    employee.Patronymic,
                    employee.Position
                });
            }
        }

        #endregion  
    }
}
