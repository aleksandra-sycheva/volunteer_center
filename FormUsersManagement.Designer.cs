namespace volonteer_center
{
    partial class FormUsersManagement
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
            btnClose = new Button();
            panelSearch = new Panel();
            cmbSortOrder = new ComboBox();
            lblSortOrder = new Label();
            btnClearFilters = new Button();
            cmbFilterRole = new ComboBox();
            lblFilterRole = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvUsers = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            panelButtons = new Panel();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Honeydew;
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblTitle.Location = new Point(12, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(369, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Управление пользователями";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(76, 175, 80);
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1100, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 60);
            btnClose.TabIndex = 1;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(240, 248, 240);
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(cmbSortOrder);
            panelSearch.Controls.Add(lblSortOrder);
            panelSearch.Controls.Add(btnClearFilters);
            panelSearch.Controls.Add(cmbFilterRole);
            panelSearch.Controls.Add(lblFilterRole);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 60);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1200, 110);
            panelSearch.TabIndex = 1;
            // 
            // cmbSortOrder
            // 
            cmbSortOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortOrder.Font = new Font("Times New Roman", 11F);
            cmbSortOrder.FormattingEnabled = true;
            cmbSortOrder.Items.AddRange(new object[] { "По возрастанию (А-Я)", "По убыванию (Я-А)" });
            cmbSortOrder.Location = new Point(580, 50);
            cmbSortOrder.Name = "cmbSortOrder";
            cmbSortOrder.Size = new Size(250, 28);
            cmbSortOrder.TabIndex = 6;
            cmbSortOrder.SelectedIndexChanged += CmbSortOrder_SelectedIndexChanged;
            // 
            // lblSortOrder
            // 
            lblSortOrder.AutoSize = true;
            lblSortOrder.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblSortOrder.ForeColor = Color.FromArgb(46, 125, 50);
            lblSortOrder.Location = new Point(580, 25);
            lblSortOrder.Name = "lblSortOrder";
            lblSortOrder.Size = new Size(197, 22);
            lblSortOrder.TabIndex = 5;
            lblSortOrder.Text = "Сортировка по ФИО:";
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.FromArgb(76, 175, 80);
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(580, 80);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(150, 30);
            btnClearFilters.TabIndex = 4;
            btnClearFilters.Text = "Сбросить фильтры";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += BtnClearFilters_Click;
            // 
            // cmbFilterRole
            // 
            cmbFilterRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterRole.Font = new Font("Times New Roman", 11F);
            cmbFilterRole.FormattingEnabled = true;
            cmbFilterRole.Location = new Point(350, 50);
            cmbFilterRole.Name = "cmbFilterRole";
            cmbFilterRole.Size = new Size(200, 28);
            cmbFilterRole.TabIndex = 3;
            cmbFilterRole.SelectedIndexChanged += CmbFilterRole_SelectedIndexChanged;
            // 
            // lblFilterRole
            // 
            lblFilterRole.AutoSize = true;
            lblFilterRole.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblFilterRole.ForeColor = Color.FromArgb(46, 125, 50);
            lblFilterRole.Location = new Point(350, 25);
            lblFilterRole.Name = "lblFilterRole";
            lblFilterRole.Size = new Size(155, 22);
            lblFilterRole.TabIndex = 2;
            lblFilterRole.Text = "Фильтр по роли:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Times New Roman", 11F);
            txtSearch.Location = new Point(12, 50);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 29);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(46, 125, 50);
            lblSearch.Location = new Point(12, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(195, 22);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск (ФИО, логин):";
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 170);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1200, 470);
            dgvUsers.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Dock = DockStyle.Right;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1077, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(123, 60);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(76, 175, 80);
            btnEdit.Dock = DockStyle.Right;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(913, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(164, 60);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(76, 175, 80);
            btnDelete.Dock = DockStyle.Right;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(782, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(131, 60);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Honeydew;
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 640);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1200, 60);
            panelButtons.TabIndex = 2;
            // 
            // FormUsersManagement
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(dgvUsers);
            Controls.Add(panelButtons);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "FormUsersManagement";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление пользователями";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Button btnClose;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private ComboBox cmbFilterRole;
        private Label lblFilterRole;
        private Button btnClearFilters;
        private ComboBox cmbSortOrder;
        private Label lblSortOrder;
        private DataGridView dgvUsers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Panel panelButtons;
    }
}