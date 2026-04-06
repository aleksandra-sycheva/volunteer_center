using Microsoft.EntityFrameworkCore;
using volonteer_center.models;

namespace volonteer_center
{
    public partial class FormRegistrationOfVolunteer : Form
    {
        private User _currentUser;
        private bool _isGuest;
        private int _eventId;
        private Event _event;

        public FormRegistrationOfVolunteer(User user, bool guest, int eventId)
        {
            InitializeComponent();
            _currentUser = user;
            _isGuest = guest;
            _eventId = eventId;

            LoadEventInfo();
            LoadRegistrations();
            SetupRoleBasedVisibility();
        }

        private void SetupRoleBasedVisibility()
        {
            if (_isGuest)
            {
                btnRegister.Visible = false;
                btnConfirm.Visible = false;
                btnReject.Visible = false;
                btnMarkAttendance.Visible = false;
                lblAccessWarning.Visible = false;
                return;
            }

            int roleId = _currentUser.RoleId;

            // Волонтер (RoleId = 3)
            if (roleId == 3)
            {
                btnRegister.Visible = true;
                btnConfirm.Visible = false;
                btnReject.Visible = false;
                btnMarkAttendance.Visible = false;
                lblRegistrationsTitle.Text = "Мои регистрации";
                lblAccessWarning.Visible = false;
            }
            // Координатор (RoleId = 2)
            else if (roleId == 2)
            {
                btnRegister.Visible = false;
                btnConfirm.Visible = true;
                btnReject.Visible = true;
                btnMarkAttendance.Visible = true;
                lblRegistrationsTitle.Text = "Управление заявками";

                // Проверка, является ли текущий пользователь координатором этого мероприятия
                if (_event != null && _event.CoordinatorId != _currentUser.Id)
                {
                    // Координатор не является координатором этого мероприятия
                    btnConfirm.Enabled = false;
                    btnReject.Enabled = false;
                    btnMarkAttendance.Enabled = false;
                    lblAccessWarning.Visible = true;
                    lblAccessWarning.Text = "⚠ Вы не являетесь координатором этого мероприятия!";
                    lblAccessWarning.ForeColor = Color.Red;
                }
                else
                {
                    btnConfirm.Enabled = true;
                    btnReject.Enabled = true;
                    btnMarkAttendance.Enabled = true;
                    lblAccessWarning.Visible = false;
                }
            }
            // Администратор (RoleId = 1)
            else if (roleId == 1)
            {
                btnRegister.Visible = false;
                btnConfirm.Visible = true;
                btnReject.Visible = true;
                btnMarkAttendance.Visible = true;
                lblRegistrationsTitle.Text = "Управление заявками (Администратор)";
                lblAccessWarning.Visible = false;
                btnConfirm.Enabled = true;
                btnReject.Enabled = true;
                btnMarkAttendance.Enabled = true;
            }
        }

        private void LoadEventInfo()
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
                        lblEventName.Text = _event.EventName;
                        lblCategory.Text = _event.Category?.CategoryName ?? "Без категории";
                        lblDate.Text = _event.Date.ToString("dd.MM.yyyy");
                        lblPlace.Text = _event.Place;

                        string coordinatorName = _event.Coordinator != null
                            ? $"{_event.Coordinator.LastName} {_event.Coordinator.FirstName}"
                            : "Не назначен";
                        lblCoordinator.Text = coordinatorName;
                        lblStatus.Text = _event.EventStatus?.StatusName ?? "Неизвестно";

                        int confirmedCount = db.RegistrationOfVolunteers
                            .Count(r => r.EventId == _eventId && r.RedistrationStatusId == 1);
                        int freeSpots = _event.NeedVolonters - confirmedCount;
                        lblFreeSpots.Text = $"Свободно мест: {freeSpots} из {_event.NeedVolonters}";

                        if (freeSpots <= 0)
                        {
                            lblFreeSpots.ForeColor = Color.Red;
                            if (_currentUser.RoleId == 3) // Только волонтерам блокируем кнопку
                            {
                                btnRegister.Enabled = false;
                            }
                        }
                        else
                        {
                            lblFreeSpots.ForeColor = Color.Black;
                            if (_currentUser.RoleId == 3)
                            {
                                btnRegister.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки информации о мероприятии: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRegistrations()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    dgvRegistrations.SuspendLayout();
                    dgvRegistrations.Rows.Clear();

                    // Настройка колонок
                    SetupRegistrationsGrid();

                    IQueryable<RegistrationOfVolunteer> query = db.RegistrationOfVolunteers
                        .Include(r => r.Volonteer)
                        .Where(r => r.EventId == _eventId);

                    // Для координатора показываем только заявки на его мероприятия
                    // (уже отфильтровано по eventId, но дополнительно проверяем)
                    if (_currentUser.RoleId == 2 && !_isGuest)
                    {
                        // Проверяем, что координатор имеет доступ к этому мероприятию
                        var eventItem = db.Events.FirstOrDefault(e => e.Id == _eventId);
                        if (eventItem != null && eventItem.CoordinatorId != _currentUser.Id)
                        {
                            // Если координатор пытается смотреть не свое мероприятие - показываем сообщение
                            dgvRegistrations.Rows.Add("Нет доступа", "Заявки недоступны", "");
                            dgvRegistrations.ResumeLayout();
                            lblStats.Text = "У вас нет прав на просмотр заявок этого мероприятия!";
                            return;
                        }
                    }

                    var registrations = query.ToList();

                    foreach (var reg in registrations)
                    {
                        string volunteerName = reg.Volonteer != null
                            ? $"{reg.Volonteer.LastName} {reg.Volonteer.FirstName} {reg.Volonteer.MiddleName}".Trim()
                            : "Неизвестно";

                        string status = GetStatusName(reg.RedistrationStatusId);
                        string registrationDate = reg.RegistrationDate.ToString("dd.MM.yyyy");

                        int rowIndex = dgvRegistrations.Rows.Add(
                            volunteerName,
                            status,
                            registrationDate
                        );

                        var row = dgvRegistrations.Rows[rowIndex];
                        row.Tag = reg.Id;

                        // Подсветка строк в зависимости от статуса
                        ApplyRowColor(row, reg.RedistrationStatusId);
                    }

                    dgvRegistrations.ResumeLayout();
                    dgvRegistrations.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                    UpdateStats(registrations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки регистраций: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupRegistrationsGrid()
        {
            dgvRegistrations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRegistrations.AllowUserToAddRows = false;
            dgvRegistrations.ReadOnly = true;
            dgvRegistrations.RowHeadersVisible = false;
            dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRegistrations.Columns.Clear();

            var colVolunteer = new DataGridViewTextBoxColumn();
            colVolunteer.Name = "colVolunteer";
            colVolunteer.HeaderText = "Волонтер";
            colVolunteer.FillWeight = 50;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Статус";
            colStatus.FillWeight = 25;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colDate = new DataGridViewTextBoxColumn();
            colDate.Name = "colDate";
            colDate.HeaderText = "Дата регистрации";
            colDate.FillWeight = 25;
            colDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRegistrations.Columns.AddRange(new DataGridViewColumn[]
            {
                colVolunteer,
                colStatus,
                colDate
            });
        }

        private string GetStatusName(int statusId)
        {
            switch (statusId)
            {
                case 1: return "Подтверждено";
                case 2: return "На рассмотрении";
                case 3: return "Отклонено";
                case 4: return "Завершено";
                case 5: return "Отменено";
                default: return "Неизвестно";
            }
        }

        private void ApplyRowColor(DataGridViewRow row, int statusId)
        {
            switch (statusId)
            {
                case 1: // Подтверждено
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#90EE90");
                    break;
                case 2: // На рассмотрении
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4");
                    break;
                case 3: // Отклонено
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1");
                    break;
                case 4: // Завершено
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0");
                    break;
                case 5: // Отменено
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D3D3D3");
                    break;
            }
        }

        private void UpdateStats(List<RegistrationOfVolunteer> registrations)
        {
            int confirmed = registrations.Count(r => r.RedistrationStatusId == 1);
            int pending = registrations.Count(r => r.RedistrationStatusId == 2);
            int rejected = registrations.Count(r => r.RedistrationStatusId == 3);
            int completed = registrations.Count(r => r.RedistrationStatusId == 4);

            lblStats.Text = $"📊 Статистика: Подтверждено: {confirmed} | На рассмотрении: {pending} | Отклонено: {rejected} | Завершено: {completed}";
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    // Проверка, не зарегистрирован ли уже
                    var existing = db.RegistrationOfVolunteers
                        .FirstOrDefault(r => r.EventId == _eventId && r.VolonteerId == _currentUser.Id);

                    if (existing != null)
                    {
                        MessageBox.Show("Вы уже зарегистрированы на это мероприятие!",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Проверка, есть ли свободные места
                    int confirmedCount = db.RegistrationOfVolunteers
                        .Count(r => r.EventId == _eventId && r.RedistrationStatusId == 1);

                    if (confirmedCount >= _event.NeedVolonters)
                    {
                        MessageBox.Show("К сожалению, все места уже заняты!",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var registration = new RegistrationOfVolunteer
                    {
                        EventId = _eventId,
                        VolonteerId = _currentUser.Id,
                        RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                        RedistrationStatusId = 2 // На рассмотрении
                    };

                    db.RegistrationOfVolunteers.Add(registration);
                    db.SaveChanges();

                    MessageBox.Show("Заявка на участие отправлена! Ожидайте подтверждения координатора.",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadRegistrations();
                    LoadEventInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null || dgvRegistrations.CurrentRow.Tag == null)
            {
                MessageBox.Show("Выберите заявку для подтверждения!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int registrationId = (int)dgvRegistrations.CurrentRow.Tag;
            string volunteerName = dgvRegistrations.CurrentRow.Cells["colVolunteer"].Value.ToString();
            string currentStatus = dgvRegistrations.CurrentRow.Cells["colStatus"].Value.ToString();

            if (currentStatus != "На рассмотрении")
            {
                MessageBox.Show("Подтвердить можно только заявки со статусом 'На рассмотрении'!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Подтвердить заявку волонтера {volunteerName}?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new VolunteerCenterContext())
                    {
                        // Проверка, есть ли свободные места
                        var eventItem = db.Events.Find(_eventId);
                        int confirmedCount = db.RegistrationOfVolunteers
                            .Count(r => r.EventId == _eventId && r.RedistrationStatusId == 1);

                        if (confirmedCount >= eventItem.NeedVolonters)
                        {
                            MessageBox.Show("Нет свободных мест для подтверждения этой заявки!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var registration = db.RegistrationOfVolunteers.Find(registrationId);
                        if (registration != null)
                        {
                            registration.RedistrationStatusId = 1; // Подтверждено
                            db.SaveChanges();

                            MessageBox.Show("Заявка подтверждена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadRegistrations();
                            LoadEventInfo();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null || dgvRegistrations.CurrentRow.Tag == null)
            {
                MessageBox.Show("Выберите заявку для отклонения!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int registrationId = (int)dgvRegistrations.CurrentRow.Tag;
            string volunteerName = dgvRegistrations.CurrentRow.Cells["colVolunteer"].Value.ToString();
            string currentStatus = dgvRegistrations.CurrentRow.Cells["colStatus"].Value.ToString();

            if (currentStatus != "На рассмотрении")
            {
                MessageBox.Show("Отклонить можно только заявки со статусом 'На рассмотрении'!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Отклонить заявку волонтера {volunteerName}?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new VolunteerCenterContext())
                    {
                        var registration = db.RegistrationOfVolunteers.Find(registrationId);
                        if (registration != null)
                        {
                            registration.RedistrationStatusId = 3; // Отклонено
                            db.SaveChanges();

                            MessageBox.Show("Заявка отклонена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadRegistrations();
                            LoadEventInfo();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.CurrentRow == null || dgvRegistrations.CurrentRow.Tag == null)
            {
                MessageBox.Show("Выберите волонтера для отметки посещаемости!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int registrationId = (int)dgvRegistrations.CurrentRow.Tag;
            string volunteerName = dgvRegistrations.CurrentRow.Cells["colVolunteer"].Value.ToString();
            string currentStatus = dgvRegistrations.CurrentRow.Cells["colStatus"].Value.ToString();

            if (currentStatus != "Подтверждено")
            {
                MessageBox.Show("Отметить посещаемость можно только для подтвержденных волонтеров!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Отметить участие волонтера {volunteerName} как завершенное?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new VolunteerCenterContext())
                    {
                        var registration = db.RegistrationOfVolunteers.Find(registrationId);
                        if (registration != null)
                        {
                            registration.RedistrationStatusId = 4; // Завершено
                            db.SaveChanges();

                            MessageBox.Show("Посещаемость отмечена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadRegistrations();
                            LoadEventInfo();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}