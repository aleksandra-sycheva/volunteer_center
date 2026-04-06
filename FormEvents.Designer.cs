namespace volonteer_center
{
    partial class FormEvents
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            paneltTop = new Panel();
            panelSearch = new Panel();
            btnClearFilters = new Button();
            cmbSortCoordinator = new ComboBox();
            lblSort = new Label();
            cmbFilterStatus = new ComboBox();
            lblFilter = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pictureBox1 = new PictureBox();
            lbUser = new Label();
            btnLogout = new Button();
            panelLeft = new Panel();
            btnUsersManagement = new Button();
            btnCoordinatorStats = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnRegistrationOfVolunteer = new Button();
            dgvEvents = new DataGridView();
            paneltTop.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            SuspendLayout();
            // 
            // paneltTop
            // 
            paneltTop.BackColor = Color.Honeydew;
            paneltTop.Controls.Add(panelSearch);
            paneltTop.Controls.Add(pictureBox1);
            paneltTop.Controls.Add(lbUser);
            paneltTop.Controls.Add(btnLogout);
            paneltTop.Dock = DockStyle.Top;
            paneltTop.Location = new Point(0, 0);
            paneltTop.Margin = new Padding(4, 3, 4, 3);
            paneltTop.Name = "paneltTop";
            paneltTop.Size = new Size(1726, 150);
            paneltTop.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(240, 248, 240);
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnClearFilters);
            panelSearch.Controls.Add(cmbSortCoordinator);
            panelSearch.Controls.Add(lblSort);
            panelSearch.Controls.Add(cmbFilterStatus);
            panelSearch.Controls.Add(lblFilter);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Location = new Point(112, 5);
            panelSearch.Margin = new Padding(4, 3, 4, 3);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(868, 140);
            panelSearch.TabIndex = 5;
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.FromArgb(76, 175, 80);
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(540, 80);
            btnClearFilters.Margin = new Padding(4, 3, 4, 3);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(200, 40);
            btnClearFilters.TabIndex = 6;
            btnClearFilters.Text = "Сбросить фильтры";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += BtnClearFilters_Click;
            // 
            // cmbSortCoordinator
            // 
            cmbSortCoordinator.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortCoordinator.Font = new Font("Times New Roman", 11F);
            cmbSortCoordinator.FormattingEnabled = true;
            cmbSortCoordinator.Items.AddRange(new object[] { "Все", "Мои мероприятия", "По возрастанию", "По убыванию" });
            cmbSortCoordinator.Location = new Point(540, 40);
            cmbSortCoordinator.Margin = new Padding(4, 3, 4, 3);
            cmbSortCoordinator.Name = "cmbSortCoordinator";
            cmbSortCoordinator.Size = new Size(200, 28);
            cmbSortCoordinator.TabIndex = 5;
            cmbSortCoordinator.SelectedIndexChanged += CmbSortCoordinator_SelectedIndexChanged;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblSort.ForeColor = Color.FromArgb(46, 125, 50);
            lblSort.Location = new Point(540, 15);
            lblSort.Margin = new Padding(4, 0, 4, 0);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(272, 22);
            lblSort.TabIndex = 4;
            lblSort.Text = "Сортировка по координатору:";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Font = new Font("Times New Roman", 11F);
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Location = new Point(10, 100);
            cmbFilterStatus.Margin = new Padding(4, 3, 4, 3);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(320, 28);
            cmbFilterStatus.TabIndex = 3;
            cmbFilterStatus.SelectedIndexChanged += CmbFilterStatus_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblFilter.ForeColor = Color.FromArgb(46, 125, 50);
            lblFilter.Location = new Point(10, 75);
            lblFilter.Margin = new Padding(4, 0, 4, 0);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(176, 22);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Фильтр по статусу:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Times New Roman", 11F);
            txtSearch.Location = new Point(10, 40);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(320, 29);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(46, 125, 50);
            lblSearch.Location = new Point(10, 15);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(187, 22);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск по названию:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.логотип;
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.Dock = DockStyle.Right;
            lbUser.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            lbUser.ForeColor = Color.FromArgb(76, 175, 80);
            lbUser.Location = new Point(1434, 0);
            lbUser.Margin = new Padding(4, 0, 4, 0);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(70, 25);
            lbUser.TabIndex = 3;
            lbUser.Text = "label1";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(76, 175, 80);
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1504, 0);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(222, 150);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.Honeydew;
            panelLeft.Controls.Add(btnUsersManagement);
            panelLeft.Controls.Add(btnCoordinatorStats);
            panelLeft.Controls.Add(btnDelete);
            panelLeft.Controls.Add(btnUpdate);
            panelLeft.Controls.Add(btnCreate);
            panelLeft.Controls.Add(btnRegistrationOfVolunteer);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 150);
            panelLeft.Margin = new Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(260, 562);
            panelLeft.TabIndex = 1;
            // 
            // btnUsersManagement
            // 
            btnUsersManagement.BackColor = Color.FromArgb(76, 175, 80);
            btnUsersManagement.FlatStyle = FlatStyle.Flat;
            btnUsersManagement.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnUsersManagement.ForeColor = Color.White;
            btnUsersManagement.Location = new Point(10, 360);
            btnUsersManagement.Margin = new Padding(10);
            btnUsersManagement.Name = "btnUsersManagement";
            btnUsersManagement.Size = new Size(240, 59);
            btnUsersManagement.TabIndex = 10;
            btnUsersManagement.Text = "Управление пользователями";
            btnUsersManagement.UseVisualStyleBackColor = false;
            btnUsersManagement.Click += BtnUsersManagement_Click;
            // 
            // btnCoordinatorStats
            // 
            btnCoordinatorStats.BackColor = Color.FromArgb(76, 175, 80);
            btnCoordinatorStats.FlatStyle = FlatStyle.Flat;
            btnCoordinatorStats.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCoordinatorStats.ForeColor = Color.White;
            btnCoordinatorStats.Location = new Point(10, 290);
            btnCoordinatorStats.Margin = new Padding(10);
            btnCoordinatorStats.Name = "btnCoordinatorStats";
            btnCoordinatorStats.Size = new Size(240, 59);
            btnCoordinatorStats.TabIndex = 9;
            btnCoordinatorStats.Text = "Статистика координаторов";
            btnCoordinatorStats.UseVisualStyleBackColor = false;
            btnCoordinatorStats.Click += BtnCoordinatorStats_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(76, 175, 80);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(10, 219);
            btnDelete.Margin = new Padding(10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(240, 59);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(76, 175, 80);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(10, 149);
            btnUpdate.Margin = new Padding(10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(240, 59);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Редактировать";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(76, 175, 80);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(10, 79);
            btnCreate.Margin = new Padding(10);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(240, 59);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Добавить";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnRegistrationOfVolunteer
            // 
            btnRegistrationOfVolunteer.BackColor = Color.FromArgb(76, 175, 80);
            btnRegistrationOfVolunteer.FlatStyle = FlatStyle.Flat;
            btnRegistrationOfVolunteer.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnRegistrationOfVolunteer.ForeColor = Color.White;
            btnRegistrationOfVolunteer.Location = new Point(10, 10);
            btnRegistrationOfVolunteer.Margin = new Padding(10);
            btnRegistrationOfVolunteer.Name = "btnRegistrationOfVolunteer";
            btnRegistrationOfVolunteer.Size = new Size(240, 59);
            btnRegistrationOfVolunteer.TabIndex = 5;
            btnRegistrationOfVolunteer.Text = "Регистрация волонтеров";
            btnRegistrationOfVolunteer.UseVisualStyleBackColor = false;
            btnRegistrationOfVolunteer.Click += BtnRegistrationOfVolunteer_Click;
            // 
            // dgvEvents
            // 
            dgvEvents.BackgroundColor = Color.White;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Dock = DockStyle.Fill;
            dgvEvents.Location = new Point(260, 150);
            dgvEvents.Margin = new Padding(4, 3, 4, 3);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.RowHeadersWidth = 51;
            dgvEvents.Size = new Size(1466, 562);
            dgvEvents.TabIndex = 2;
            // 
            // FormEvents
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1726, 712);
            Controls.Add(dgvEvents);
            Controls.Add(panelLeft);
            Controls.Add(paneltTop);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "FormEvents";
            Text = "События";
            paneltTop.ResumeLayout(false);
            paneltTop.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
        }

        // Компоненты формы
        private Panel paneltTop;
        private Panel panelSearch;
        private Button btnClearFilters;
        private ComboBox cmbSortCoordinator;
        private Label lblSort;
        private ComboBox cmbFilterStatus;
        private Label lblFilter;
        private TextBox txtSearch;
        private Label lblSearch;
        private PictureBox pictureBox1;
        private Label lbUser;
        private Button btnLogout;
        private Panel panelLeft;
        private Button btnUsersManagement;
        private Button btnCoordinatorStats;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private Button btnRegistrationOfVolunteer;
        private DataGridView dgvEvents;
    }
}