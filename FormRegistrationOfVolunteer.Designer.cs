namespace volonteer_center
{
    partial class FormRegistrationOfVolunteer
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
            panelTop = new Panel();
            lblTitle = new Label();
            panelEventInfo = new Panel();
            lblFreeSpots = new Label();
            lblStatusTitle = new Label();
            lblStatus = new Label();
            lblCoordinatorTitle = new Label();
            lblCoordinator = new Label();
            lblPlaceTitle = new Label();
            lblPlace = new Label();
            lblDateTitle = new Label();
            lblDate = new Label();
            lblCategoryTitle = new Label();
            lblCategory = new Label();
            lblEventNameTitle = new Label();
            lblEventName = new Label();
            panelRegistrations = new Panel();
            lblStats = new Label();
            lblRegistrationsTitle = new Label();
            dgvRegistrations = new DataGridView();
            panelButtons = new Panel();
            btnMarkAttendance = new Button();
            btnReject = new Button();
            btnConfirm = new Button();
            btnRegister = new Button();
            btnClose = new Button();
            lblAccessWarning = new Label();
            panelTop.SuspendLayout();
            panelEventInfo.SuspendLayout();
            panelRegistrations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Honeydew;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(950, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(287, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Регистрация волонтеров";
            // 
            // panelEventInfo
            // 
            panelEventInfo.BackColor = Color.White;
            panelEventInfo.BorderStyle = BorderStyle.FixedSingle;
            panelEventInfo.Controls.Add(lblFreeSpots);
            panelEventInfo.Controls.Add(lblStatusTitle);
            panelEventInfo.Controls.Add(lblStatus);
            panelEventInfo.Controls.Add(lblCoordinatorTitle);
            panelEventInfo.Controls.Add(lblCoordinator);
            panelEventInfo.Controls.Add(lblPlaceTitle);
            panelEventInfo.Controls.Add(lblPlace);
            panelEventInfo.Controls.Add(lblDateTitle);
            panelEventInfo.Controls.Add(lblDate);
            panelEventInfo.Controls.Add(lblCategoryTitle);
            panelEventInfo.Controls.Add(lblCategory);
            panelEventInfo.Controls.Add(lblEventNameTitle);
            panelEventInfo.Controls.Add(lblEventName);
            panelEventInfo.Location = new Point(12, 70);
            panelEventInfo.Name = "panelEventInfo";
            panelEventInfo.Size = new Size(926, 200);
            panelEventInfo.TabIndex = 1;
            // 
            // lblEventNameTitle
            // 
            lblEventNameTitle.AutoSize = true;
            lblEventNameTitle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblEventNameTitle.Location = new Point(15, 15);
            lblEventNameTitle.Name = "lblEventNameTitle";
            lblEventNameTitle.Size = new Size(88, 19);
            lblEventNameTitle.TabIndex = 0;
            lblEventNameTitle.Text = "Название:";
            // 
            // lblEventName
            // 
            lblEventName.AutoSize = true;
            lblEventName.Font = new Font("Times New Roman", 10F);
            lblEventName.Location = new Point(120, 15);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new Size(68, 19);
            lblEventName.TabIndex = 1;
            lblEventName.Text = "Название";
            // 
            // lblCategoryTitle
            // 
            lblCategoryTitle.AutoSize = true;
            lblCategoryTitle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblCategoryTitle.Location = new Point(15, 45);
            lblCategoryTitle.Name = "lblCategoryTitle";
            lblCategoryTitle.Size = new Size(92, 19);
            lblCategoryTitle.TabIndex = 2;
            lblCategoryTitle.Text = "Категория:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Times New Roman", 10F);
            lblCategory.Location = new Point(120, 45);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 19);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Категория";
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblDateTitle.Location = new Point(15, 75);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(60, 19);
            lblDateTitle.TabIndex = 4;
            lblDateTitle.Text = "Дата:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Times New Roman", 10F);
            lblDate.Location = new Point(120, 75);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(44, 19);
            lblDate.TabIndex = 5;
            lblDate.Text = "Дата";
            // 
            // lblPlaceTitle
            // 
            lblPlaceTitle.AutoSize = true;
            lblPlaceTitle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblPlaceTitle.Location = new Point(15, 105);
            lblPlaceTitle.Name = "lblPlaceTitle";
            lblPlaceTitle.Size = new Size(69, 19);
            lblPlaceTitle.TabIndex = 6;
            lblPlaceTitle.Text = "Место:";
            // 
            // lblPlace
            // 
            lblPlace.AutoSize = true;
            lblPlace.Font = new Font("Times New Roman", 10F);
            lblPlace.Location = new Point(120, 105);
            lblPlace.Name = "lblPlace";
            lblPlace.Size = new Size(53, 19);
            lblPlace.TabIndex = 7;
            lblPlace.Text = "Место";
            // 
            // lblCoordinatorTitle
            // 
            lblCoordinatorTitle.AutoSize = true;
            lblCoordinatorTitle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblCoordinatorTitle.Location = new Point(15, 135);
            lblCoordinatorTitle.Name = "lblCoordinatorTitle";
            lblCoordinatorTitle.Size = new Size(115, 19);
            lblCoordinatorTitle.TabIndex = 8;
            lblCoordinatorTitle.Text = "Координатор:";
            // 
            // lblCoordinator
            // 
            lblCoordinator.AutoSize = true;
            lblCoordinator.Font = new Font("Times New Roman", 10F);
            lblCoordinator.Location = new Point(150, 135);
            lblCoordinator.Name = "lblCoordinator";
            lblCoordinator.Size = new Size(95, 19);
            lblCoordinator.TabIndex = 9;
            lblCoordinator.Text = "Координатор";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblStatusTitle.Location = new Point(450, 15);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(72, 19);
            lblStatusTitle.TabIndex = 10;
            lblStatusTitle.Text = "Статус:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Times New Roman", 10F);
            lblStatus.Location = new Point(540, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 19);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Статус";
            // 
            // lblFreeSpots
            // 
            lblFreeSpots.AutoSize = true;
            lblFreeSpots.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblFreeSpots.ForeColor = Color.FromArgb(76, 175, 80);
            lblFreeSpots.Location = new Point(450, 50);
            lblFreeSpots.Name = "lblFreeSpots";
            lblFreeSpots.Size = new Size(149, 22);
            lblFreeSpots.TabIndex = 12;
            lblFreeSpots.Text = "Свободно мест: 0";
            // 
            // panelRegistrations
            // 
            panelRegistrations.Controls.Add(lblStats);
            panelRegistrations.Controls.Add(lblRegistrationsTitle);
            panelRegistrations.Controls.Add(dgvRegistrations);
            panelRegistrations.Location = new Point(12, 280);
            panelRegistrations.Name = "panelRegistrations";
            panelRegistrations.Size = new Size(926, 350);
            panelRegistrations.TabIndex = 2;
            // 
            // lblRegistrationsTitle
            // 
            lblRegistrationsTitle.AutoSize = true;
            lblRegistrationsTitle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblRegistrationsTitle.Location = new Point(0, 0);
            lblRegistrationsTitle.Name = "lblRegistrationsTitle";
            lblRegistrationsTitle.Size = new Size(151, 23);
            lblRegistrationsTitle.TabIndex = 1;
            lblRegistrationsTitle.Text = "Список заявок";
            // 
            // dgvRegistrations
            // 
            dgvRegistrations.BackgroundColor = Color.White;
            dgvRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistrations.Location = new Point(0, 30);
            dgvRegistrations.Name = "dgvRegistrations";
            dgvRegistrations.RowHeadersWidth = 51;
            dgvRegistrations.Size = new Size(926, 280);
            dgvRegistrations.TabIndex = 0;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new Font("Times New Roman", 9F);
            lblStats.Location = new Point(0, 320);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(119, 17);
            lblStats.TabIndex = 2;
            lblStats.Text = "Статистика: 0";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Honeydew;
            panelButtons.Controls.Add(lblAccessWarning);
            panelButtons.Controls.Add(btnMarkAttendance);
            panelButtons.Controls.Add(btnReject);
            panelButtons.Controls.Add(btnConfirm);
            panelButtons.Controls.Add(btnRegister);
            panelButtons.Controls.Add(btnClose);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 650);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(950, 80);
            panelButtons.TabIndex = 3;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(76, 175, 80);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(20, 20);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(180, 45);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Записаться";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(33, 150, 243);
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(220, 20);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(150, 45);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Подтвердить";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += BtnConfirm_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.FromArgb(244, 67, 54);
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(390, 20);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(150, 45);
            btnReject.TabIndex = 2;
            btnReject.Text = "Отклонить";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += BtnReject_Click;
            // 
            // btnMarkAttendance
            // 
            btnMarkAttendance.BackColor = Color.FromArgb(255, 152, 0);
            btnMarkAttendance.FlatStyle = FlatStyle.Flat;
            btnMarkAttendance.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnMarkAttendance.ForeColor = Color.White;
            btnMarkAttendance.Location = new Point(560, 20);
            btnMarkAttendance.Name = "btnMarkAttendance";
            btnMarkAttendance.Size = new Size(180, 45);
            btnMarkAttendance.TabIndex = 3;
            btnMarkAttendance.Text = "Отметить участие";
            btnMarkAttendance.UseVisualStyleBackColor = false;
            btnMarkAttendance.Click += BtnMarkAttendance_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(830, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 45);
            btnClose.TabIndex = 4;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // lblAccessWarning
            // 
            lblAccessWarning.AutoSize = true;
            lblAccessWarning.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            lblAccessWarning.ForeColor = Color.Red;
            lblAccessWarning.Location = new Point(20, 55);
            lblAccessWarning.Name = "lblAccessWarning";
            lblAccessWarning.Size = new Size(0, 17);
            lblAccessWarning.TabIndex = 5;
            lblAccessWarning.Visible = false;
            // 
            // FormRegistrationOfVolunteer
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 730);
            Controls.Add(panelButtons);
            Controls.Add(panelRegistrations);
            Controls.Add(panelEventInfo);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistrationOfVolunteer";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Регистрация волонтеров";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelEventInfo.ResumeLayout(false);
            panelEventInfo.PerformLayout();
            panelRegistrations.ResumeLayout(false);
            panelRegistrations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Panel panelEventInfo;
        private Label lblFreeSpots;
        private Label lblStatusTitle;
        private Label lblStatus;
        private Label lblCoordinatorTitle;
        private Label lblCoordinator;
        private Label lblPlaceTitle;
        private Label lblPlace;
        private Label lblDateTitle;
        private Label lblDate;
        private Label lblCategoryTitle;
        private Label lblCategory;
        private Label lblEventNameTitle;
        private Label lblEventName;
        private Panel panelRegistrations;
        private Label lblStats;
        private Label lblRegistrationsTitle;
        private DataGridView dgvRegistrations;
        private Panel panelButtons;
        private Button btnMarkAttendance;
        private Button btnReject;
        private Button btnConfirm;
        private Button btnRegister;
        private Button btnClose;
        private Label lblAccessWarning;
    }
}