namespace volonteer_center
{
    partial class FormUserEdit
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
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtLogin = new TextBox();
            lblLogin = new Label();
            txtMiddleName = new TextBox();
            lblMiddleName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            lblTitle = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelMain.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(cmbRole);
            panelMain.Controls.Add(lblRole);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(txtLogin);
            panelMain.Controls.Add(lblLogin);
            panelMain.Controls.Add(txtMiddleName);
            panelMain.Controls.Add(lblMiddleName);
            panelMain.Controls.Add(txtFirstName);
            panelMain.Controls.Add(lblFirstName);
            panelMain.Controls.Add(txtLastName);
            panelMain.Controls.Add(lblLastName);
            panelMain.Controls.Add(lblTitle);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(500, 450);
            panelMain.TabIndex = 0;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Times New Roman", 12F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(150, 340);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(300, 30);
            cmbRole.TabIndex = 12;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(76, 175, 80);
            lblRole.Location = new Point(50, 343);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(60, 23);
            lblRole.TabIndex = 11;
            lblRole.Text = "Роль:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Times New Roman", 12F);
            txtPassword.Location = new Point(150, 290);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 30);
            txtPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(76, 175, 80);
            lblPassword.Location = new Point(50, 293);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(83, 23);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Пароль:";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Times New Roman", 12F);
            txtLogin.Location = new Point(150, 240);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(300, 30);
            txtLogin.TabIndex = 8;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(76, 175, 80);
            lblLogin.Location = new Point(50, 243);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(75, 23);
            lblLogin.TabIndex = 7;
            lblLogin.Text = "Логин:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Times New Roman", 12F);
            txtMiddleName.Location = new Point(150, 190);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(300, 30);
            txtMiddleName.TabIndex = 6;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblMiddleName.ForeColor = Color.FromArgb(76, 175, 80);
            lblMiddleName.Location = new Point(50, 193);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(102, 23);
            lblMiddleName.TabIndex = 5;
            lblMiddleName.Text = "Отчество:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Times New Roman", 12F);
            txtFirstName.Location = new Point(150, 140);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(300, 30);
            txtFirstName.TabIndex = 4;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(76, 175, 80);
            lblFirstName.Location = new Point(50, 143);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(57, 23);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "Имя:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Times New Roman", 12F);
            txtLastName.Location = new Point(150, 90);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(300, 30);
            txtLastName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(76, 175, 80);
            lblLastName.Location = new Point(50, 93);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(104, 23);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Фамилия:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblTitle.Location = new Point(150, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 35);
            lblTitle.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Honeydew;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 450);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(500, 60);
            panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(76, 175, 80);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(279, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 60);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(379, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 60);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // FormUserEdit
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 510);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUserEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование пользователя";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblTitle;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private TextBox txtMiddleName;
        private Label lblMiddleName;
        private TextBox txtLogin;
        private Label lblLogin;
        private TextBox txtPassword;
        private Label lblPassword;
        private ComboBox cmbRole;
        private Label lblRole;
        private Panel panelButtons;
        private Button btnCancel;
        private Button btnSave;
    }
}