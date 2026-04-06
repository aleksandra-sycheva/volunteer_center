using Microsoft.EntityFrameworkCore;
using volonteer_center.models;

namespace volonteer_center
{
    public partial class FormEvents : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        private List<Event> _allEvents;
        private string _currentSearchText = "";
        private int? _currentFilterStatusId = null;
        private string _currentSortMode = "Все";

        public FormEvents(User user, bool guest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = guest;

            SetupDataGridViewColumns();
            SetupRoleBasedVisibility();
            LoadStatusFilter();
            SetupSortVisibility();

            // Подписка на события
            btnLogout.Click += BtnLogout_Click;
            btnRegistrationOfVolunteer.Click += BtnRegistrationOfVolunteer_Click;
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCoordinatorStats.Click += BtnCoordinatorStats_Click;

            LoadEvents();

            if (!IsGuest && CurrentUser.RoleId == 3)
            {
                ShowVolunteerStats(CurrentUser.Id);
            }
        }

        private void SetupSortVisibility()
        {
            bool showSort = !IsGuest && (CurrentUser.RoleId == 1 || CurrentUser.RoleId == 2);
            cmbSortCoordinator.Visible = showSort;
            lblSort.Visible = showSort;

            // Устанавливаем значение по умолчанию
            if (showSort && cmbSortCoordinator.Items.Count > 0)
            {
                cmbSortCoordinator.SelectedIndex = 0;
            }
        }

        private void LoadStatusFilter()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    var statuses = db.EventStatuses.ToList();

                    // Очищаем ComboBox
                    cmbFilterStatus.Items.Clear();

                    // Создаем список для хранения элементов
                    var items = new List<KeyValuePair<int?, string>>();

                    // Добавляем пункт "Все статусы"
                    items.Add(new KeyValuePair<int?, string>(null, "Все статусы"));

                    // Добавляем все статусы из базы данных
                    foreach (var status in statuses)
                    {
                        items.Add(new KeyValuePair<int?, string>(status.Id, status.StatusName));
                    }

                    // Привязываем данные к ComboBox
                    cmbFilterStatus.DataSource = items;
                    cmbFilterStatus.DisplayMember = "Value";
                    cmbFilterStatus.ValueMember = "Key";

                    // Выбираем первый пункт ("Все статусы")
                    if (items.Count > 0)
                        cmbFilterStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupRoleBasedVisibility()
        {
            if (IsGuest)
            {
                lbUser.Text = "Гость";
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

                if (roleId == 1) // Администратор
                {
                    btnCreate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnRegistrationOfVolunteer.Visible = true;
                    btnCoordinatorStats.Visible = true;
                }
                else if (roleId == 2) // Координатор
                {
                    btnCreate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnRegistrationOfVolunteer.Visible = true;
                    btnCoordinatorStats.Visible = false;
                }
                else if (roleId == 3) // Волонтер
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

            var colInfo = new DataGridViewTextBoxColumn
            {
                Name = "colInfo",
                HeaderText = "Информация о мероприятии",
                FillWeight = 50,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };

            var colNeedVolunteer = new DataGridViewTextBoxColumn
            {
                Name = "colNeedVolunteer",
                HeaderText = "Нужно волонтеров",
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Статус",
                FillWeight = 12,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colAvailableSeats = new DataGridViewTextBoxColumn
            {
                Name = "colAvailableSeats",
                HeaderText = "Свободно мест",
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colRecruitmentPercentage = new DataGridViewTextBoxColumn
            {
                Name = "colRecruitmentPercentage",
                HeaderText = "Набор %",
                FillWeight = 8,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "F1" }
            };

            dgvEvents.Columns.AddRange(colInfo, colNeedVolunteer, colStatus, colAvailableSeats, colRecruitmentPercentage);
        }

        private void LoadEvents()
        {
            try
            {
                using (var db = new VolunteerCenterContext())
                {
                    _allEvents = db.Events
                        .Include(e => e.Category)
                        .Include(e => e.Coordinator)
                        .Include(e => e.EventStatus)
                        .Include(e => e.RegistrationOfVolunteers)
                        .OrderBy(e => e.Date)
                        .ToList();

                    ApplyFiltersAndSort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мероприятий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFiltersAndSort()
        {
            if (_allEvents == null) return;

            var filteredEvents = _allEvents.AsEnumerable();

            // Фильтр по поиску
            if (!string.IsNullOrWhiteSpace(_currentSearchText))
            {
                filteredEvents = filteredEvents.Where(e =>
                    e.EventName.Contains(_currentSearchText, StringComparison.OrdinalIgnoreCase));
            }

            // Фильтр по статусу
            if (_currentFilterStatusId.HasValue)
            {
                filteredEvents = filteredEvents.Where(e => e.EventStatusId == _currentFilterStatusId.Value);
            }

            // Сортировка
            switch (_currentSortMode)
            {
                case "Мои мероприятия":
                    if (CurrentUser.RoleId == 2)
                        filteredEvents = filteredEvents.Where(e => e.CoordinatorId == CurrentUser.Id);
                    filteredEvents = filteredEvents.OrderBy(e => e.Date);
                    break;
                case "По возрастанию":
                    filteredEvents = filteredEvents.OrderBy(e => e.Coordinator?.LastName ?? "");
                    break;
                case "По убыванию":
                    filteredEvents = filteredEvents.OrderByDescending(e => e.Coordinator?.LastName ?? "");
                    break;
                default:
                    filteredEvents = filteredEvents.OrderBy(e => e.Date);
                    break;
            }

            DisplayEvents(filteredEvents.ToList());
        }

        private void DisplayEvents(List<Event> events)
        {
            dgvEvents.SuspendLayout();
            dgvEvents.Rows.Clear();

            foreach (var ev in events)
            {
                int confirmedCount = ev.RegistrationOfVolunteers.Count(r => r.RedistrationStatusId == 1);
                int freeSpots = Math.Max(0, ev.NeedVolonters - confirmedCount);
                double fillPercent = ev.NeedVolonters > 0 ? (double)confirmedCount / ev.NeedVolonters * 100 : 0;
                string info = FormatEventInfo(ev);
                string status = ev.EventStatus?.StatusName ?? "Неизвестно";

                int rowIndex = dgvEvents.Rows.Add(info, ev.NeedVolonters, status, freeSpots, fillPercent);
                var row = dgvEvents.Rows[rowIndex];
                row.Tag = ev.Id;
                ApplyRowColor(row, ev, freeSpots);
            }

            dgvEvents.ResumeLayout();
            dgvEvents.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            // Обновляем заголовок с количеством записей
            string userName = lbUser.Text.Split('(')[0].Trim();
            if (events.Count != _allEvents?.Count)
            {
                lbUser.Text = $"{userName} (Найдено: {events.Count} из {_allEvents?.Count ?? 0})";
            }
            else
            {
                lbUser.Text = userName;
            }
        }

        private string FormatEventInfo(Event ev)
        {
            string coordinatorFullName = "Не назначен";
            if (ev.Coordinator != null)
            {
                coordinatorFullName = $"{ev.Coordinator.LastName} {ev.Coordinator.FirstName} {ev.Coordinator.MiddleName}".Trim();
                coordinatorFullName = string.IsNullOrWhiteSpace(coordinatorFullName) ? ev.Coordinator.Login : coordinatorFullName;
            }

            return $"Название: {ev.EventName}\nКатегория: {ev.Category?.CategoryName ?? "Без категории"}\nДата: {ev.Date:dd.MM.yyyy}\nМесто: {ev.Place}\nКоординатор: {coordinatorFullName}";
        }

        private void ApplyRowColor(DataGridViewRow row, Event ev, int freeSpots)
        {
            string status = ev.EventStatus?.StatusName ?? "";

            if (status == "Отменено")
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1");
            else if (status == "Завершено")
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            else if (status == "Запланировано" && freeSpots < 3 && freeSpots > 0)
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4");
            else if (freeSpots <= 0 && status != "Завершено" && status != "Отменено")
                row.DefaultCellStyle.BackColor = Color.LightGray;
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            _currentSearchText = txtSearch.Text;
            ApplyFiltersAndSort();
        }

        private void CmbFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbFilterStatus.SelectedItem != null)
            {
                var selected = (KeyValuePair<int?, string>)cmbFilterStatus.SelectedItem;
                _currentFilterStatusId = selected.Key;
                ApplyFiltersAndSort();
            }
        }

        private void CmbSortCoordinator_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbSortCoordinator.SelectedItem != null)
            {
                _currentSortMode = cmbSortCoordinator.SelectedItem.ToString();
                ApplyFiltersAndSort();
            }
        }

        private void BtnClearFilters_Click(object? sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (cmbFilterStatus.Items.Count > 0)
                cmbFilterStatus.SelectedIndex = 0;
            if (cmbSortCoordinator.Items.Count > 0)
                cmbSortCoordinator.SelectedIndex = 0;

            _currentSearchText = "";
            _currentFilterStatusId = null;
            _currentSortMode = "Все";
            ApplyFiltersAndSort();

            MessageBox.Show("Все фильтры сброшены!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCoordinatorStats_Click(object? sender, EventArgs e)
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

                    string message = "=======================================\n";
                    message += "          СТАТИСТИКА КООРДИНАТОРОВ           \n";
                    message += "=======================================\n\n";
                    message += string.Format("{0,-40} {1,10}\n", "Координатор", "Мероприятий");
                    message += new string('-', 52) + "\n";

                    if (stats.Count == 0)
                        message += "Нет назначенных координаторов.\n";
                    else
                    {
                        foreach (var stat in stats)
                        {
                            string name = string.IsNullOrWhiteSpace(stat.CoordinatorFullName) ? "Координатор без ФИО" : stat.CoordinatorFullName;
                            if (name.Length > 38) name = name.Substring(0, 35) + "...";
                            message += string.Format("{0,-40} {1,10}\n", name, stat.EventsCount);
                        }
                    }

                    message += new string('-', 52) + "\n";
                    message += string.Format("{0,-40} {1,10}\n", "Всего координаторов:", stats.Count);
                    message += "=======================================";

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
                        .Count(r => r.VolonteerId == volunteerId && r.RedistrationStatusId == 1 && r.Event.EventStatus.StatusName == "Завершено");

                    int totalEvents = db.RegistrationOfVolunteers
                        .Count(r => r.VolonteerId == volunteerId && r.RedistrationStatusId == 1);

                    string message = "=======================================\n";
                    message += "          ЛИЧНЫЙ КАБИНЕТ ВОЛОНТЕРА           \n";
                    message += "=======================================\n\n";
                    message += string.Format("{0,-35} {1,10}\n", "Завершенных мероприятий:", completedEvents);
                    message += string.Format("{0,-35} {1,10}\n", "Всего участий:", totalEvents);
                    message += "=======================================\n\n";
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

        private void RefreshEvents() => LoadEvents();

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?",
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                using (var formLogin = new FormLogin())
                {
                    var loginResult = formLogin.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        var formEvents = new FormEvents(formLogin.CurrentUser, formLogin.IsGuest);
                        formEvents.ShowDialog();
                    }
                    else
                    {
                        Application.Exit();
                        return;
                    }
                }
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

            if (dgvEvents.CurrentRow?.Tag == null)
            {
                MessageBox.Show("Выберите мероприятие!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = (int)dgvEvents.CurrentRow.Tag;
            using (var formReg = new FormRegistrationOfVolunteer(CurrentUser, IsGuest, eventId))
            {
                if (formReg.ShowDialog() == DialogResult.OK)
                    RefreshEvents();
            }
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            using (var formEventEdit = new FormEventEdit(CurrentUser, IsGuest, null))
            {
                if (formEventEdit.ShowDialog() == DialogResult.OK)
                    RefreshEvents();
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow?.Tag == null)
            {
                MessageBox.Show("Выберите мероприятие для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = (int)dgvEvents.CurrentRow.Tag;
            using (var formEventEdit = new FormEventEdit(CurrentUser, IsGuest, eventId))
            {
                if (formEventEdit.ShowDialog() == DialogResult.OK)
                    RefreshEvents();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow?.Tag == null)
            {
                MessageBox.Show("Выберите мероприятие для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить это мероприятие?\n\nВНИМАНИЕ: Все связанные регистрации будут также удалены!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                int eventId = (int)dgvEvents.CurrentRow.Tag;
                using (var db = new VolunteerCenterContext())
                {
                    var eventToDelete = db.Events.Include(e => e.RegistrationOfVolunteers).FirstOrDefault(e => e.Id == eventId);
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