using Microsoft.EntityFrameworkCore;
using volonteer_center.models;

namespace volonteer_center
{
    public partial class FormEventEdit : Form
    {
        private User _currentUser;
        private bool _isGuest;
        private int? _eventId;
        private Event _event;

        public FormEventEdit(User user, bool guest, int? eventId = null)
        {
            InitializeComponent();
            _currentUser = user;
            _isGuest = guest;
            _eventId = eventId;

            // Загрузка данных в ComboBox
            LoadCategories();
            LoadCoordinators();
            LoadEventStatuses();

            if (_eventId.HasValue)
            {
                // Режим редактирования
                this.Text = "Редактирование мероприятия";
                btnSave.Text = "Сохранить";
                LoadEventData();

                // При редактировании проверяем права
                CheckEditPermissions();
            }
            else
            {
                // Режим создания
                this.Text = "Добавление мероприятия";
                btnSave.Text = "Добавить";
                dtpDate.Value = DateTime.Now;
                cmbStatus.SelectedValue = 1; // Запланировано

                // Если координатор, автоматически выбираем его в качестве координатора
                if (_currentUser.RoleId == 2) // Роль координатора
                {
                    cmbCoordinator.SelectedValue = _currentUser.Id;
                    cmbCoordinator.Enabled = false; // Запрещаем выбор другого координатора
                }
            }
        }

        private void CheckEditPermissions()
        {
            // Если координатор редактирует мероприятие, проверяем, что он координатор этого мероприятия
            if (_currentUser.RoleId == 2 && _event != null && _event.CoordinatorId != _currentUser.Id)
            {
                MessageBox.Show("Вы можете редактировать только свои мероприятия!", "Доступ запрещен",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var categories = db.Categories.ToList();
                    cmbCategory.DataSource = categories;
                    cmbCategory.DisplayMember = "CategoryName";
                    cmbCategory.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCoordinators()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    List<dynamic> coordinators;

                    // Если пользователь - администратор, показываем всех координаторов
                    if (_currentUser.RoleId == 1) // Администратор
                    {
                        coordinators = db.Users
                            .Where(u => u.RoleId == 2)
                            .Select(u => new
                            {
                                Id = u.Id,
                                FullName = $"{u.LastName} {u.FirstName} {u.MiddleName}".Trim()
                            })
                            .ToList<dynamic>();
                    }
                    // Если пользователь - координатор, показываем только его
                    else if (_currentUser.RoleId == 2) // Координатор
                    {
                        coordinators = db.Users
                            .Where(u => u.Id == _currentUser.Id && u.RoleId == 2)
                            .Select(u => new
                            {
                                Id = u.Id,
                                FullName = $"{u.LastName} {u.FirstName} {u.MiddleName}".Trim()
                            })
                            .ToList<dynamic>();
                    }
                    else
                    {
                        coordinators = new List<dynamic>();
                    }

                    cmbCoordinator.DataSource = coordinators;
                    cmbCoordinator.DisplayMember = "FullName";
                    cmbCoordinator.ValueMember = "Id";

                    // Если нет координаторов, показываем сообщение
                    if (coordinators.Count == 0)
                    {
                        if (_currentUser.RoleId == 1)
                            MessageBox.Show("В системе нет координаторов! Добавьте координаторов перед созданием мероприятия.",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (_currentUser.RoleId == 2)
                            MessageBox.Show("Ваша учетная запись не привязана к роли координатора! Обратитесь к администратору.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки координаторов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventStatuses()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var statuses = db.EventStatuses.ToList();
                    cmbStatus.DataSource = statuses;
                    cmbStatus.DisplayMember = "StatusName";
                    cmbStatus.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventData()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    _event = db.Events
                        .Include(e => e.Category)
                        .Include(e => e.Coordinator)
                        .Include(e => e.EventStatus)
                        .FirstOrDefault(e => e.Id == _eventId);

                    if (_event != null)
                    {
                        txtEventName.Text = _event.EventName;
                        cmbCategory.SelectedValue = _event.CategoryId;
                        dtpDate.Value = _event.Date.ToDateTime(TimeOnly.MinValue);
                        txtPlace.Text = _event.Place;
                        numNeedVolunteers.Value = _event.NeedVolonters;

                        // Устанавливаем координатора по ID
                        cmbCoordinator.SelectedValue = _event.CoordinatorId;
                        cmbStatus.SelectedValue = _event.EventStatusId;

                        // Если координатор редактирует мероприятие, запрещаем менять координатора
                        if (_currentUser.RoleId == 2)
                        {
                            cmbCoordinator.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных мероприятия: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show("Введите название мероприятия!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEventName.Focus();
                return;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPlace.Text))
            {
                MessageBox.Show("Введите место проведения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlace.Focus();
                return;
            }

            if (numNeedVolunteers.Value <= 0)
            {
                MessageBox.Show("Количество волонтеров должно быть больше 0!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numNeedVolunteers.Focus();
                return;
            }

            if (cmbCoordinator.SelectedItem == null)
            {
                MessageBox.Show("Выберите координатора!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус мероприятия!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    if (_eventId.HasValue)
                    {
                        // Редактирование
                        var eventToUpdate = db.Events.Find(_eventId);
                        if (eventToUpdate != null)
                        {
                            // Дополнительная проверка прав при редактировании
                            if (_currentUser.RoleId == 2 && eventToUpdate.CoordinatorId != _currentUser.Id)
                            {
                                MessageBox.Show("Вы можете редактировать только свои мероприятия!", "Доступ запрещен",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            eventToUpdate.EventName = txtEventName.Text.Trim();
                            eventToUpdate.CategoryId = (int)cmbCategory.SelectedValue;
                            eventToUpdate.Date = DateOnly.FromDateTime(dtpDate.Value);
                            eventToUpdate.Place = txtPlace.Text.Trim();
                            eventToUpdate.NeedVolonters = (int)numNeedVolunteers.Value;

                            // Только администратор может менять координатора при редактировании
                            if (_currentUser.RoleId == 1)
                            {
                                eventToUpdate.CoordinatorId = (int)cmbCoordinator.SelectedValue;
                            }

                            eventToUpdate.EventStatusId = (int)cmbStatus.SelectedValue;

                            db.SaveChanges();
                            MessageBox.Show("Мероприятие успешно обновлено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Создание
                        int coordinatorId;

                        // Определяем ID координатора
                        if (_currentUser.RoleId == 1) // Администратор
                        {
                            coordinatorId = (int)cmbCoordinator.SelectedValue;
                        }
                        else if (_currentUser.RoleId == 2) // Координатор
                        {
                            coordinatorId = _currentUser.Id;
                        }
                        else
                        {
                            MessageBox.Show("У вас недостаточно прав для создания мероприятия!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var newEvent = new Event
                        {
                            EventName = txtEventName.Text.Trim(),
                            CategoryId = (int)cmbCategory.SelectedValue,
                            Date = DateOnly.FromDateTime(dtpDate.Value),
                            Place = txtPlace.Text.Trim(),
                            NeedVolonters = (int)numNeedVolunteers.Value,
                            CoordinatorId = coordinatorId,
                            EventStatusId = (int)cmbStatus.SelectedValue
                        };

                        db.Events.Add(newEvent);
                        db.SaveChanges();
                        MessageBox.Show("Мероприятие успешно добавлено!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}