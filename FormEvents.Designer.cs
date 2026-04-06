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
            pictureBox1 = new PictureBox();
            lbUser = new Label();
            btnLogout = new Button();
            panel1 = new Panel();
            panelLeft = new Panel();
            btnCoordinatorStats = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            btnRegistrationOfVolunteer = new Button();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            dgvEvents = new DataGridView();
            paneltTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            SuspendLayout();
            // 
            // paneltTop
            // 
            paneltTop.BackColor = Color.Honeydew;
            paneltTop.Controls.Add(pictureBox1);
            paneltTop.Controls.Add(lbUser);
            paneltTop.Controls.Add(btnLogout);
            paneltTop.Controls.Add(panel1);
            paneltTop.Dock = DockStyle.Top;
            paneltTop.Location = new Point(0, 0);
            paneltTop.Name = "paneltTop";
            paneltTop.Size = new Size(1188, 112);
            paneltTop.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.логотип;
            pictureBox1.Location = new Point(3, 4);
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
            lbUser.Location = new Point(921, 0);
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
            btnLogout.Location = new Point(991, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(197, 112);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(1015, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 603);
            panel1.TabIndex = 1;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.Honeydew;
            panelLeft.Controls.Add(btnCoordinatorStats);
            panelLeft.Controls.Add(btnDelete);
            panelLeft.Controls.Add(btnUpdate);
            panelLeft.Controls.Add(btnCreate);
            panelLeft.Controls.Add(btnRegistrationOfVolunteer);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 112);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(260, 600);
            panelLeft.TabIndex = 1;
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
            btnCoordinatorStats.Text = "Загрузка координатора";
            btnCoordinatorStats.UseVisualStyleBackColor = false;
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
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // dgvEvents
            // 
            dgvEvents.BackgroundColor = Color.White;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Dock = DockStyle.Fill;
            dgvEvents.Location = new Point(260, 112);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.RowHeadersWidth = 51;
            dgvEvents.Size = new Size(928, 600);
            dgvEvents.TabIndex = 2;
            // 
            // FormEvents
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 712);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
        }


        private Panel paneltTop;
        private Label lbUser;
        private Button btnLogout;
        private Panel panel1;
        private Panel panelLeft;
        private PictureBox pictureBox1;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private Button btnRegistrationOfVolunteer;
        private DataGridView dgvEvents;
        private Button btnCoordinatorStats;
    }
}