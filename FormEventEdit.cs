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
            }
            else
            {
                // Режим создания
                this.Text = "Добавление мероприятия";
                btnSave.Text = "Добавить";
                dtpDate.Value = DateTime.Now;
                cmbStatus.SelectedValue = 1; // Запланировано
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
                    var coordinators = db.Users
                        .Where(u => u.RoleId == 2)
                        .Select(u => new
                        {
                            Id = u.Id,
                            FullName = $"{u.LastName} {u.FirstName} {u.MiddleName}".Trim()
                        })
                        .ToList();

                    cmbCoordinator.DataSource = coordinators;
                    cmbCoordinator.DisplayMember = "FullName";
                    cmbCoordinator.ValueMember = "Id";

                    // Если нет координаторов, показываем сообщение
                    if (coordinators.Count == 0)
                    {
                        MessageBox.Show("В системе нет координаторов! Добавьте координаторов перед созданием мероприятия.",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            eventToUpdate.EventName = txtEventName.Text.Trim();
                            eventToUpdate.CategoryId = (int)cmbCategory.SelectedValue;
                            eventToUpdate.Date = DateOnly.FromDateTime(dtpDate.Value);
                            eventToUpdate.Place = txtPlace.Text.Trim();
                            eventToUpdate.NeedVolonters = (int)numNeedVolunteers.Value;
                            eventToUpdate.CoordinatorId = (int)cmbCoordinator.SelectedValue;
                            eventToUpdate.EventStatusId = (int)cmbStatus.SelectedValue;

                            db.SaveChanges();
                            MessageBox.Show("Мероприятие успешно обновлено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Создание
                        var newEvent = new Event
                        {
                            EventName = txtEventName.Text.Trim(),
                            CategoryId = (int)cmbCategory.SelectedValue,
                            Date = DateOnly.FromDateTime(dtpDate.Value),
                            Place = txtPlace.Text.Trim(),
                            NeedVolonters = (int)numNeedVolunteers.Value,
                            CoordinatorId = (int)cmbCoordinator.SelectedValue,
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