using Microsoft.EntityFrameworkCore;
using volonteer_center.models;

namespace volonteer_center
{
    public partial class FormUserEdit : Form
    {
        private int? _userId;
        private User _user;

        public FormUserEdit(int? userId = null)
        {
            InitializeComponent();
            _userId = userId;

            LoadRoles();

            if (_userId.HasValue)
            {
                this.Text = "Редактирование пользователя";
                lblTitle.Text = "Редактирование пользователя";
                LoadUserData();
            }
            else
            {
                this.Text = "Добавление пользователя";
                lblTitle.Text = "Добавление пользователя";
            }
        }

        private void LoadRoles()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var roles = db.Roles.ToList();
                    cmbRole.DataSource = roles;
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки ролей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    _user = db.Users.FirstOrDefault(u => u.Id == _userId);
                    if (_user != null)
                    {
                        txtLastName.Text = _user.LastName;
                        txtFirstName.Text = _user.FirstName;
                        txtMiddleName.Text = _user.MiddleName;
                        txtLogin.Text = _user.Login;
                        txtPassword.Text = _user.Password;
                        cmbRole.SelectedValue = _user.RoleId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных пользователя: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    // Проверка уникальности логина
                    bool loginExists;
                    if (_userId.HasValue)
                    {
                        loginExists = db.Users.Any(u => u.Login == txtLogin.Text.Trim() && u.Id != _userId.Value);
                    }
                    else
                    {
                        loginExists = db.Users.Any(u => u.Login == txtLogin.Text.Trim());
                    }

                    if (loginExists)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLogin.Focus();
                        return;
                    }

                    if (_userId.HasValue)
                    {
                        // Редактирование
                        var userToUpdate = db.Users.Find(_userId);
                        if (userToUpdate != null)
                        {
                            userToUpdate.LastName = txtLastName.Text.Trim();
                            userToUpdate.FirstName = txtFirstName.Text.Trim();
                            userToUpdate.MiddleName = txtMiddleName.Text.Trim();
                            userToUpdate.Login = txtLogin.Text.Trim();
                            userToUpdate.Password = txtPassword.Text.Trim();
                            userToUpdate.RoleId = (int)cmbRole.SelectedValue;

                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        // Создание
                        var newUser = new User
                        {
                            LastName = txtLastName.Text.Trim(),
                            FirstName = txtFirstName.Text.Trim(),
                            MiddleName = txtMiddleName.Text.Trim(),
                            Login = txtLogin.Text.Trim(),
                            Password = txtPassword.Text.Trim(),
                            RoleId = (int)cmbRole.SelectedValue
                        };

                        db.Users.Add(newUser);
                        db.SaveChanges();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}