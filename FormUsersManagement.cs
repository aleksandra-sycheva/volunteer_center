using Microsoft.EntityFrameworkCore;
using volonteer_center.models;

namespace volonteer_center
{
    public partial class FormUsersManagement : Form
    {
        private User _currentUser;
        private bool _isGuest;
        private List<User> _allUsers;
        private string _currentSearchText = "";
        private int? _currentFilterRoleId = null;
        private string _currentSortOrder = "По возрастанию (А-Я)";

        public FormUsersManagement(User user, bool guest)
        {
            InitializeComponent();
            _currentUser = user;
            _isGuest = guest;

            SetupDataGridViewColumns();
            LoadRoleFilter();
            LoadUsers();

            // Устанавливаем значение по умолчанию для сортировки
            if (cmbSortOrder.Items.Count > 0)
                cmbSortOrder.SelectedIndex = 0;
        }

        private void SetupDataGridViewColumns()
        {
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsers.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                FillWeight = 5,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colLastName = new DataGridViewTextBoxColumn
            {
                Name = "colLastName",
                HeaderText = "Фамилия",
                FillWeight = 15
            };

            var colFirstName = new DataGridViewTextBoxColumn
            {
                Name = "colFirstName",
                HeaderText = "Имя",
                FillWeight = 15
            };

            var colMiddleName = new DataGridViewTextBoxColumn
            {
                Name = "colMiddleName",
                HeaderText = "Отчество",
                FillWeight = 15
            };

            var colLogin = new DataGridViewTextBoxColumn
            {
                Name = "colLogin",
                HeaderText = "Логин",
                FillWeight = 15
            };

            var colPassword = new DataGridViewTextBoxColumn
            {
                Name = "colPassword",
                HeaderText = "Пароль",
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colRole = new DataGridViewTextBoxColumn
            {
                Name = "colRole",
                HeaderText = "Роль",
                FillWeight = 15,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            dgvUsers.Columns.AddRange(colId, colLastName, colFirstName, colMiddleName, colLogin, colPassword, colRole);
        }

        private void LoadRoleFilter()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var roles = db.Roles.ToList();

                    var items = new List<KeyValuePair<int?, string>>();
                    items.Add(new KeyValuePair<int?, string>(null, "Все роли"));

                    foreach (var role in roles)
                    {
                        items.Add(new KeyValuePair<int?, string>(role.Id, role.RoleName));
                    }

                    cmbFilterRole.DataSource = items;
                    cmbFilterRole.DisplayMember = "Value";
                    cmbFilterRole.ValueMember = "Key";

                    if (items.Count > 0)
                        cmbFilterRole.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки ролей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    _allUsers = db.Users
                        .Include(u => u.Role)
                        .ToList();

                    ApplyFiltersAndSort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFiltersAndSort()
        {
            if (_allUsers == null) return;

            var filteredUsers = _allUsers.AsEnumerable();

            // Фильтр по поиску
            if (!string.IsNullOrWhiteSpace(_currentSearchText))
            {
                filteredUsers = filteredUsers.Where(u =>
                    (u.LastName?.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.FirstName?.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.MiddleName?.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (u.Login?.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            // Фильтр по роли
            if (_currentFilterRoleId.HasValue)
            {
                filteredUsers = filteredUsers.Where(u => u.RoleId == _currentFilterRoleId.Value);
            }

            // Сортировка
            if (_currentSortOrder == "По возрастанию (А-Я)")
            {
                filteredUsers = filteredUsers.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
            }
            else
            {
                filteredUsers = filteredUsers.OrderByDescending(u => u.LastName).ThenByDescending(u => u.FirstName);
            }

            DisplayUsers(filteredUsers.ToList());
        }

        private void DisplayUsers(List<User> users)
        {
            dgvUsers.SuspendLayout();
            dgvUsers.Rows.Clear();

            foreach (var user in users)
            {
                dgvUsers.Rows.Add(
                    user.Id,
                    user.LastName ?? "",
                    user.FirstName ?? "",
                    user.MiddleName ?? "",
                    user.Login ?? "",
                    "••••••", // Скрываем пароль
                    user.Role?.RoleName ?? "Неизвестно"
                );
            }

            dgvUsers.ResumeLayout();

            // Обновляем заголовок
            Text = $"Управление пользователями (Найдено: {users.Count} из {_allUsers?.Count ?? 0})";
        }

        private void RefreshUsers()
        {
            LoadUsers();
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            _currentSearchText = txtSearch.Text;
            ApplyFiltersAndSort();
        }

        private void CmbFilterRole_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbFilterRole.SelectedItem != null)
            {
                var selected = (KeyValuePair<int?, string>)cmbFilterRole.SelectedItem;
                _currentFilterRoleId = selected.Key;
                ApplyFiltersAndSort();
            }
        }

        private void CmbSortOrder_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbSortOrder.SelectedItem != null)
            {
                _currentSortOrder = cmbSortOrder.SelectedItem.ToString();
                ApplyFiltersAndSort();
            }
        }

        private void BtnClearFilters_Click(object? sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (cmbFilterRole.Items.Count > 0)
                cmbFilterRole.SelectedIndex = 0;
            if (cmbSortOrder.Items.Count > 0)
                cmbSortOrder.SelectedIndex = 0;

            _currentSearchText = "";
            _currentFilterRoleId = null;
            _currentSortOrder = "По возрастанию (А-Я)";
            ApplyFiltersAndSort();

            MessageBox.Show("Все фильтры сброшены!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            using (var formUserEdit = new FormUserEdit(null))
            {
                if (formUserEdit.ShowDialog() == DialogResult.OK)
                {
                    RefreshUsers();
                    MessageBox.Show("Пользователь успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = (int)dgvUsers.CurrentRow.Cells["colId"].Value;

            using (var formUserEdit = new FormUserEdit(userId))
            {
                if (formUserEdit.ShowDialog() == DialogResult.OK)
                {
                    RefreshUsers();
                    MessageBox.Show("Пользователь успешно обновлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = (int)dgvUsers.CurrentRow.Cells["colId"].Value;
            string userName = dgvUsers.CurrentRow.Cells["colLastName"].Value?.ToString() ?? "Unknown";

            // Нельзя удалить самого себя
            if (userId == _currentUser.Id)
            {
                MessageBox.Show("Вы не можете удалить свою собственную учетную запись!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить пользователя '{userName}'?\n\nВНИМАНИЕ: Это действие необратимо!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var userToDelete = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (userToDelete != null)
                    {
                        db.Users.Remove(userToDelete);
                        db.SaveChanges();
                        RefreshUsers();
                        MessageBox.Show("Пользователь успешно удален!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}