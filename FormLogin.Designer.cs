namespace volonteer_center
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnGuest = new Button();
            btnLogin = new Button();
            label3 = new Label();
            label4 = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.логотип;
            pictureBox1.Location = new Point(246, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(206, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(113, 285);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 339);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(204, 124);
            label2.Name = "label2";
            label2.Size = new Size(72, 22);
            label2.TabIndex = 1;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 25);
            label1.Name = "label1";
            label1.Size = new Size(64, 22);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtLogin);
            panel2.Controls.Add(btnGuest);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(113, 285);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 339);
            panel2.TabIndex = 1;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.Honeydew;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.ForeColor = Color.Black;
            btnGuest.Location = new Point(118, 273);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(236, 39);
            btnGuest.TabIndex = 5;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += btnGuest_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(76, 175, 80);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(118, 213);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(236, 39);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(200, 119);
            label3.Name = "label3";
            label3.Size = new Size(72, 22);
            label3.TabIndex = 1;
            label3.Text = "Пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(204, 25);
            label4.Name = "label4";
            label4.Size = new Size(64, 22);
            label4.TabIndex = 0;
            label4.Text = "Логин";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(81, 68);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Логин";
            txtLogin.Size = new Size(310, 30);
            txtLogin.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(81, 162);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пароль";
            txtPassword.Size = new Size(310, 30);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 657);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button btnGuest;
        private Button btnLogin;
        private Label label3;
        private Label label4;
        private TextBox txtPassword;
        private TextBox txtLogin;
    }
}
