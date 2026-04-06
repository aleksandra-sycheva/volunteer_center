namespace volonteer_center
{
    partial class FormEventEdit
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
            panelMain = new Panel();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblCoordinator = new Label();
            cmbCoordinator = new ComboBox();
            lblNeedVolunteers = new Label();
            numNeedVolunteers = new NumericUpDown();
            lblPlace = new Label();
            txtPlace = new TextBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblEventName = new Label();
            txtEventName = new TextBox();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNeedVolunteers).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblStatus);
            panelMain.Controls.Add(cmbStatus);
            panelMain.Controls.Add(lblCoordinator);
            panelMain.Controls.Add(cmbCoordinator);
            panelMain.Controls.Add(lblNeedVolunteers);
            panelMain.Controls.Add(numNeedVolunteers);
            panelMain.Controls.Add(lblPlace);
            panelMain.Controls.Add(txtPlace);
            panelMain.Controls.Add(lblDate);
            panelMain.Controls.Add(dtpDate);
            panelMain.Controls.Add(lblCategory);
            panelMain.Controls.Add(cmbCategory);
            panelMain.Controls.Add(lblEventName);
            panelMain.Controls.Add(txtEventName);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(550, 500);
            panelMain.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblStatus.Location = new Point(23, 444);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(76, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Times New Roman", 12F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(23, 470);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(500, 30);
            cmbStatus.TabIndex = 13;
            // 
            // lblCoordinator
            // 
            lblCoordinator.AutoSize = true;
            lblCoordinator.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblCoordinator.Location = new Point(23, 375);
            lblCoordinator.Name = "lblCoordinator";
            lblCoordinator.Size = new Size(133, 23);
            lblCoordinator.TabIndex = 10;
            lblCoordinator.Text = "Координатор:";
            // 
            // cmbCoordinator
            // 
            cmbCoordinator.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCoordinator.Font = new Font("Times New Roman", 12F);
            cmbCoordinator.FormattingEnabled = true;
            cmbCoordinator.Location = new Point(23, 401);
            cmbCoordinator.Name = "cmbCoordinator";
            cmbCoordinator.Size = new Size(500, 30);
            cmbCoordinator.TabIndex = 11;
            // 
            // lblNeedVolunteers
            // 
            lblNeedVolunteers.AutoSize = true;
            lblNeedVolunteers.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblNeedVolunteers.Location = new Point(23, 306);
            lblNeedVolunteers.Name = "lblNeedVolunteers";
            lblNeedVolunteers.Size = new Size(188, 23);
            lblNeedVolunteers.TabIndex = 8;
            lblNeedVolunteers.Text = "Нужно волонтеров:";
            // 
            // numNeedVolunteers
            // 
            numNeedVolunteers.Font = new Font("Times New Roman", 12F);
            numNeedVolunteers.Location = new Point(23, 332);
            numNeedVolunteers.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNeedVolunteers.Name = "numNeedVolunteers";
            numNeedVolunteers.Size = new Size(500, 30);
            numNeedVolunteers.TabIndex = 9;
            numNeedVolunteers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPlace
            // 
            lblPlace.AutoSize = true;
            lblPlace.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblPlace.Location = new Point(23, 237);
            lblPlace.Name = "lblPlace";
            lblPlace.Size = new Size(73, 23);
            lblPlace.TabIndex = 6;
            lblPlace.Text = "Место:";
            // 
            // txtPlace
            // 
            txtPlace.Font = new Font("Times New Roman", 12F);
            txtPlace.Location = new Point(23, 263);
            txtPlace.Name = "txtPlace";
            txtPlace.Size = new Size(500, 30);
            txtPlace.TabIndex = 7;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblDate.Location = new Point(23, 168);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(59, 23);
            lblDate.TabIndex = 4;
            lblDate.Text = "Дата:";
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd.MM.yyyy";
            dtpDate.Font = new Font("Times New Roman", 12F);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(23, 194);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(500, 30);
            dtpDate.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblCategory.Location = new Point(23, 99);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(112, 23);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Times New Roman", 12F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(23, 125);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(500, 30);
            cmbCategory.TabIndex = 3;
            // 
            // lblEventName
            // 
            lblEventName.AutoSize = true;
            lblEventName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblEventName.Location = new Point(23, 30);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new Size(105, 23);
            lblEventName.TabIndex = 0;
            lblEventName.Text = "Название:";
            // 
            // txtEventName
            // 
            txtEventName.Font = new Font("Times New Roman", 12F);
            txtEventName.Location = new Point(23, 56);
            txtEventName.Name = "txtEventName";
            txtEventName.Size = new Size(500, 30);
            txtEventName.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Honeydew;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 500);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(550, 70);
            panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(430, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(303, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // FormEventEdit
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 570);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEventEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Мероприятие";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNeedVolunteers).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }


        private Panel panelMain;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblCoordinator;
        private ComboBox cmbCoordinator;
        private Label lblNeedVolunteers;
        private NumericUpDown numNeedVolunteers;
        private Label lblPlace;
        private TextBox txtPlace;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblEventName;
        private TextBox txtEventName;
        private Panel panelButtons;
        private Button btnCancel;
        private Button btnSave;
    }
}