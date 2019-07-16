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

                foreach (var employee in department.Empoyees)
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
        }

        private async void DepartmentsList_Load(object sender, EventArgs e)
        {
            await UpdateDataAsync();
        }

        public async Task UpdateDataAsync()
        {
            // Clear previous data
            _currentDepartment = null;
            _currentEmployee = null;
            departmentsTreeView.Nodes.Clear();

            // Full new data
            var departments = await Task.Run( () => _departmentsManager.GetDepartments());
            var rootDepertments = departments.Where(d => !d.ParentDepartmentId.HasValue).ToArray();

            //TODO: Удалить дублирование
            foreach (var department in rootDepertments)
            {
                var node = new TreeNode(department.Name) { Name = department.Id.ToString(), Tag = department };
                departmentsTreeView.Nodes.Add(node);
                FillNode(node, department);
            }
        }

        private void FillNode(TreeNode node, Department department)
        {
            foreach (var subDepartment in department.SubDepartmenents)
            {
                var subNode = new TreeNode(subDepartment.Name) { Name = subDepartment.Id.ToString(), Tag = subDepartment };
                node.Nodes.Add(subNode);
                FillNode(subNode, subDepartment);
            }
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

        private void ShowEmpBnt_Click(object sender, EventArgs e)
        {
            if (_currentEmployee == null)
            {
                MessageBox.Show("Вы не выбрали сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var userForm = new UserForm(_currentEmployee);
            userForm.ShowDialog();
        }

        private async void BtnAddEmp_Click(object sender, EventArgs e)
        {
            if (_currentDepartment == null)
            {
                MessageBox.Show("Вы не выбрали отдел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            await UpdateDataAsync();
        }

        private async void EmpEditBtn_Click(object sender, EventArgs e)
        {
            if (_currentEmployee == null)
            {
                MessageBox.Show("Вы не выбрали отдел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userForm = new UserForm(_currentEmployee, true);
            var result = userForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            if (!_employeesManager.Update(userForm.Employee))
            {
                MessageBox.Show("Произошла ошибка, при сохранении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await UpdateDataAsync();
        }
    }
}
