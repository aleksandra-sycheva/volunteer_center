using Microsoft.EntityFrameworkCore;
using volonteer_center.models;

namespace volonteer_center
{
    public partial class FormEvents : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormEvents(User user, bool guest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = guest;

            // Настройка DataGridView
            SetupDataGridViewColumns();

            // Настройка видимости кнопок в зависимости от роли
            SetupRoleBasedVisibility();

            // Подписка на события кнопок
            btnLogout.Click += BtnLogout_Click;
            btnRegistrationOfVolunteer.Click += BtnRegistrationOfVolunteer_Click;
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCoordinatorStats.Click += BtnCoordinatorStats_Click;

            // Загрузка данных
            LoadEvents();

            // Статистика для волонтера (автоматически при входе)
            if (!IsGuest && CurrentUser.RoleId == 3)
            {
                ShowVolunteerStats(CurrentUser.Id);
            }
        }

        private void SetupRoleBasedVisibility()
        {
            // Отображение имени пользователя
            if (IsGuest)
            {
                lbUser.Text = "Гость";
                // Гость: только просмотр
                btnCreate.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnRegistrationOfVolunteer.Visible = false;
                btnCoordinatorStats.Visible = false;
            }
            else
            {
                string fullName = $"{CurrentUser.LastName} {CurrentUser.FirstName} {CurrentUser.MiddleName}".Trim();
                lbUser.Text = string.IsNullOrWhiteSpace(fullName) ? CurrentUser.Login : fullName;

                int roleId = CurrentUser.RoleId;

                // Администратор (RoleId = 1)
                if (roleId == 1)
                {
                    btnCreate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnRegistrationOfVolunteer.Visible = true;
                    btnCoordinatorStats.Visible = true;
                }
                // Координатор (RoleId = 2)
                else if (roleId == 2)
                {
                    btnCreate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnRegistrationOfVolunteer.Visible = true;
                    btnCoordinatorStats.Visible = false;
                }
                // Волонтер (RoleId = 3)
                else if (roleId == 3)
                {
                    btnCreate.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnRegistrationOfVolunteer.Visible = true;
                    btnCoordinatorStats.Visible = false;
                }
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvEvents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.ReadOnly = true;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvEvents.Columns.Clear();

            // 1. Колонка с основной информацией
            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.HeaderText = "Информация о мероприятии";
            colInfo.FillWeight = 50;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 2. Колонка "Нужно волонтеров"
            var colNeedVolunteer = new DataGridViewTextBoxColumn();
            colNeedVolunteer.Name = "colNeedVolunteer";
            colNeedVolunteer.HeaderText = "Нужно волонтеров";
            colNeedVolunteer.FillWeight = 10;
            colNeedVolunteer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 3. Колонка "Статус мероприятия"
            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Статус";
            colStatus.FillWeight = 12;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 4. Колонка "Свободные места"
            var colAvailableSeats = new DataGridViewTextBoxColumn();
            colAvailableSeats.Name = "colAvailableSeats";
            colAvailableSeats.HeaderText = "Свободно мест";
            colAvailableSeats.FillWeight = 10;
            colAvailableSeats.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 5. Колонка "Процент набора"
            var colRecruitmentPercentage = new DataGridViewTextBoxColumn();
            colRecruitmentPercentage.Name = "colRecruitmentPercentage";
            colRecruitmentPercentage.HeaderText = "Набор %";
            colRecruitmentPercentage.FillWeight = 8;
            colRecruitmentPercentage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRecruitmentPercentage.DefaultCellStyle.Format = "F1";

            dgvEvents.Columns.AddRange(new DataGridViewColumn[]
            {
                colInfo,
                colNeedVolunteer,
                colStatus,
                colAvailableSeats,
                colRecruitmentPercentage
            });
        }

        private void LoadEvents()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var events = db.Events
                        .Include(e => e.Category)
                        .Include(e => e.Coordinator)
                        .Include(e => e.EventStatus)
                        .Include(e => e.RegistrationOfVolunteers)
                        .OrderBy(e => e.Date)
                        .ToList();

                    dgvEvents.SuspendLayout();
                    dgvEvents.Rows.Clear();

                    foreach (var ev in events)
                    {
                        // Расчет подтвержденных волонтеров (статус 1 = Подтверждено)
                        int confirmedCount = ev.RegistrationOfVolunteers
                            .Count(r => r.RedistrationStatusId == 1);

                        // Свободные места
                        int freeSpots = ev.NeedVolonters - confirmedCount;
                        freeSpots = freeSpots < 0 ? 0 : freeSpots;

                        // Процент набора
                        double fillPercent = ev.NeedVolonters > 0
                            ? (double)confirmedCount / ev.NeedVolonters * 100
                            : 0;

                        // Форматирование информации
                        string info = FormatEventInfo(ev);
                        string status = ev.EventStatus?.StatusName ?? "Неизвестно";

                        int rowIndex = dgvEvents.Rows.Add(
                            info,
                            ev.NeedVolonters,
                            status,
                            freeSpots,
                            fillPercent
                        );

                        var row = dgvEvents.Rows[rowIndex];
                        row.Tag = ev.Id;

                        // Применение цветовой подсветки
                        ApplyRowColor(row, ev, freeSpots);
                    }

                    dgvEvents.ResumeLayout();
                    dgvEvents.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мероприятий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatEventInfo(Event ev)
        {
            string coordinatorFullName = "Не назначен";
            if (ev.Coordinator != null)
            {
                coordinatorFullName = $"{ev.Coordinator.LastName} {ev.Coordinator.FirstName} {ev.Coordinator.MiddleName}".Trim();
                coordinatorFullName = string.IsNullOrWhiteSpace(coordinatorFullName)
                    ? ev.Coordinator.Login
                    : coordinatorFullName;
            }

            return $"Название: {ev.EventName}\n" +
                   $"Категория: {ev.Category?.CategoryName ?? "Без категории"}\n" +
                   $"Дата: {ev.Date:dd.MM.yyyy}\n" +
                   $"Место: {ev.Place}\n" +
                   $"Координатор: {coordinatorFullName}";
        }

        private void ApplyRowColor(DataGridViewRow row, Event ev, int freeSpots)
        {
            string status = ev.EventStatus?.StatusName ?? "";

            if (status == "Отменено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1");
            }
            else if (status == "Завершено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            }
            else if (status == "Запланировано" && freeSpots < 3 && freeSpots > 0)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4");
            }
            else if (freeSpots <= 0 && status != "Завершено" && status != "Отменено")
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void BtnCoordinatorStats_Click(object? sender, EventArgs e)
        {
            LoadCoordinatorStats();
        }

        private void LoadCoordinatorStats()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var stats = db.Users
                        .Where(u => u.RoleId == 2)
                        .Select(u => new
                        {
                            CoordinatorFullName = $"{u.LastName} {u.FirstName} {u.MiddleName}".Trim(),
                            EventsCount = db.Events.Count(e => e.CoordinatorId == u.Id)
                        })
                        .OrderByDescending(s => s.EventsCount)
                        .ToList();

                    // Формирование сообщения с простым форматированием
                    string message = "==================================================\n";
                    message += "          СТАТИСТИКА КООРДИНАТОРОВ           \n";
                    message += "==================================================\n\n";

                    // Заголовки
                    message += string.Format("{0,-40} {1,10}\n", "Координатор", "Мероприятий");
                    message += new string('-', 52) + "\n";

                    if (stats.Count == 0)
                    {
                        message += "Нет назначенных координаторов.\n";
                    }
                    else
                    {
                        foreach (var stat in stats)
                        {
                            string name = string.IsNullOrWhiteSpace(stat.CoordinatorFullName)
                                ? "Координатор без ФИО"
                                : stat.CoordinatorFullName;

                            // Ограничиваем длину имени 38 символами
                            if (name.Length > 38)
                                name = name.Substring(0, 35) + "...";

                            message += string.Format("{0,-40} {1,10}\n", name, stat.EventsCount);
                        }
                    }

                    message += new string('-', 52) + "\n";
                    message += string.Format("{0,-40} {1,10}\n", "Всего координаторов:", stats.Count);
                    message += "==================================================";

                    MessageBox.Show(message, "Статистика координаторов",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики координаторов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowVolunteerStats(int volunteerId)
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    int completedEvents = db.RegistrationOfVolunteers
                        .Include(r => r.Event)
                        .ThenInclude(e => e.EventStatus)
                        .Count(r => r.VolonteerId == volunteerId
                                 && r.RedistrationStatusId == 1
                                 && r.Event.EventStatus.StatusName == "Завершено");

                    int totalEvents = db.RegistrationOfVolunteers
                        .Count(r => r.VolonteerId == volunteerId && r.RedistrationStatusId == 1);

                    string message = "==================================================\n";
                    message += "          ЛИЧНЫЙ КАБИНЕТ ВОЛОНТЕРА           \n";
                    message += "==================================================\n\n";
                    message += string.Format("{0,-35} {1,10}\n", "Завершенных мероприятий:", completedEvents);
                    message += string.Format("{0,-35} {1,10}\n", "Всего участий:", totalEvents);
                    message += "==================================================\n\n";
                    message += "     Спасибо за вашу активность и добрые дела! 🌟";

                    MessageBox.Show(message, "Личный кабинет волонтера",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshEvents()
        {
            LoadEvents();
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            // Спрашиваем подтверждение
            var result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?",
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Скрываем текущую форму
                this.Hide();

                // Создаем и показываем форму входа
                using (var formLogin = new FormLogin())
                {
                    var loginResult = formLogin.ShowDialog();

                    if (loginResult == DialogResult.OK)
                    {
                        // Если пользователь успешно вошел, создаем новую FormEvents
                        var formEvents = new FormEvents(formLogin.CurrentUser, formLogin.IsGuest);
                        formEvents.ShowDialog();
                    }
                    else
                    {
                        // Если пользователь закрыл форму входа, закрываем приложение
                        Application.Exit();
                        return;
                    }
                }

                // Закрываем текущую форму
                this.Close();
            }
        }

        private void BtnRegistrationOfVolunteer_Click(object? sender, EventArgs e)
        {
            if (IsGuest)
            {
                MessageBox.Show("Для регистрации на мероприятие необходимо авторизоваться!",
                    "Требуется авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEvents.CurrentRow == null || dgvEvents.CurrentRow.Tag == null)
            {
                MessageBox.Show("Выберите мероприятие!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = (int)dgvEvents.CurrentRow.Tag;

            using (var formReg = new FormRegistrationOfVolunteer(CurrentUser, IsGuest, eventId))
            {
                if (formReg.ShowDialog() == DialogResult.OK)
                {
                    RefreshEvents();
                }
            }
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            using (var formEventEdit = new FormEventEdit(CurrentUser, IsGuest, null))
            {
                if (formEventEdit.ShowDialog() == DialogResult.OK)
                {
                    RefreshEvents();
                }
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow == null || dgvEvents.CurrentRow.Tag == null)
            {
                MessageBox.Show("Выберите мероприятие для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = (int)dgvEvents.CurrentRow.Tag;

            using (var formEventEdit = new FormEventEdit(CurrentUser, IsGuest, eventId))
            {
                if (formEventEdit.ShowDialog() == DialogResult.OK)
                {
                    RefreshEvents();
                }
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow == null || dgvEvents.CurrentRow.Tag == null)
            {
                MessageBox.Show("Выберите мероприятие для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить это мероприятие?\n\n" +
                "ВНИМАНИЕ: Все связанные регистрации будут также удалены!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                int eventId = (int)dgvEvents.CurrentRow.Tag;

                using (var db = new VolunteerCenterContext())
                {
                    var eventToDelete = db.Events
                        .Include(e => e.RegistrationOfVolunteers)
                        .FirstOrDefault(e => e.Id == eventId);

                    if (eventToDelete != null)
                    {
                        db.Events.Remove(eventToDelete);
                        db.SaveChanges();
                        RefreshEvents();

                        MessageBox.Show("Мероприятие успешно удалено!", "Успех",
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
    }
}