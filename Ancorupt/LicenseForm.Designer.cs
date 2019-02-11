namespace Ancorupt
{
    partial class LicenseForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.registrationButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.registrationLoginGroup = new System.Windows.Forms.GroupBox();
            this.buyAttachGroup = new System.Windows.Forms.GroupBox();
            this.restoreButton = new System.Windows.Forms.Button();
            this.attachButton = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.keyLabel = new System.Windows.Forms.Label();
            this.licenseKeyBox = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.runProgramButton = new System.Windows.Forms.Button();
            this.registrationStatusLabel = new System.Windows.Forms.Label();
            this.registrationLoginGroup.SuspendLayout();
            this.buyAttachGroup.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(69, 25);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(157, 20);
            this.emailBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(69, 51);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(157, 20);
            this.passwordBox.TabIndex = 1;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(15, 28);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(37, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Почта";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(15, 54);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(45, 13);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Пароль";
            // 
            // registrationButton
            // 
            this.registrationButton.Location = new System.Drawing.Point(15, 77);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(105, 23);
            this.registrationButton.TabIndex = 4;
            this.registrationButton.Text = "Регистрация";
            this.registrationButton.UseVisualStyleBackColor = true;
            this.registrationButton.Click += new System.EventHandler(this.registrationButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(126, 77);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Вход";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registrationLoginGroup
            // 
            this.registrationLoginGroup.Controls.Add(this.emailLabel);
            this.registrationLoginGroup.Controls.Add(this.loginButton);
            this.registrationLoginGroup.Controls.Add(this.emailBox);
            this.registrationLoginGroup.Controls.Add(this.registrationButton);
            this.registrationLoginGroup.Controls.Add(this.passwordBox);
            this.registrationLoginGroup.Controls.Add(this.passwordLabel);
            this.registrationLoginGroup.Location = new System.Drawing.Point(12, 12);
            this.registrationLoginGroup.Name = "registrationLoginGroup";
            this.registrationLoginGroup.Size = new System.Drawing.Size(239, 113);
            this.registrationLoginGroup.TabIndex = 6;
            this.registrationLoginGroup.TabStop = false;
            this.registrationLoginGroup.Text = "Регистрация / Вход";
            // 
            // buyAttachGroup
            // 
            this.buyAttachGroup.Controls.Add(this.restoreButton);
            this.buyAttachGroup.Controls.Add(this.attachButton);
            this.buyAttachGroup.Controls.Add(this.buyButton);
            this.buyAttachGroup.Controls.Add(this.keyLabel);
            this.buyAttachGroup.Controls.Add(this.licenseKeyBox);
            this.buyAttachGroup.Location = new System.Drawing.Point(269, 12);
            this.buyAttachGroup.Name = "buyAttachGroup";
            this.buyAttachGroup.Size = new System.Drawing.Size(228, 113);
            this.buyAttachGroup.TabIndex = 7;
            this.buyAttachGroup.TabStop = false;
            this.buyAttachGroup.Text = "Покупка / Привязка программы";
            // 
            // restoreButton
            // 
            this.restoreButton.Location = new System.Drawing.Point(120, 54);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(102, 23);
            this.restoreButton.TabIndex = 11;
            this.restoreButton.Text = "Восстановить";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // attachButton
            // 
            this.attachButton.Location = new System.Drawing.Point(9, 83);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(213, 23);
            this.attachButton.TabIndex = 10;
            this.attachButton.Text = "Привязать к этому компьютеру";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(9, 54);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(105, 23);
            this.buyButton.TabIndex = 9;
            this.buyButton.Text = "Купить";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(6, 28);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(33, 13);
            this.keyLabel.TabIndex = 6;
            this.keyLabel.Text = "Ключ";
            // 
            // licenseKeyBox
            // 
            this.licenseKeyBox.Location = new System.Drawing.Point(38, 25);
            this.licenseKeyBox.Name = "licenseKeyBox";
            this.licenseKeyBox.Size = new System.Drawing.Size(184, 20);
            this.licenseKeyBox.TabIndex = 8;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 224);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(515, 22);
            this.status.TabIndex = 8;
            this.status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // runProgramButton
            // 
            this.runProgramButton.Enabled = false;
            this.runProgramButton.Location = new System.Drawing.Point(368, 162);
            this.runProgramButton.Name = "runProgramButton";
            this.runProgramButton.Size = new System.Drawing.Size(138, 56);
            this.runProgramButton.TabIndex = 9;
            this.runProgramButton.Text = "Запустить программу";
            this.runProgramButton.UseVisualStyleBackColor = true;
            this.runProgramButton.Click += new System.EventHandler(this.runProgramButton_Click);
            // 
            // registrationStatusLabel
            // 
            this.registrationStatusLabel.AutoSize = true;
            this.registrationStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registrationStatusLabel.Location = new System.Drawing.Point(12, 205);
            this.registrationStatusLabel.Name = "registrationStatusLabel";
            this.registrationStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.registrationStatusLabel.TabIndex = 10;
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 246);
            this.Controls.Add(this.registrationStatusLabel);
            this.Controls.Add(this.runProgramButton);
            this.Controls.Add(this.status);
            this.Controls.Add(this.buyAttachGroup);
            this.Controls.Add(this.registrationLoginGroup);
            this.Name = "LicenseForm";
            this.Text = "Ancorupt: Защита программы от запуска на другом компьютере";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.registrationLoginGroup.ResumeLayout(false);
            this.registrationLoginGroup.PerformLayout();
            this.buyAttachGroup.ResumeLayout(false);
            this.buyAttachGroup.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.GroupBox registrationLoginGroup;
        private System.Windows.Forms.GroupBox buyAttachGroup;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox licenseKeyBox;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button runProgramButton;
        private System.Windows.Forms.Label registrationStatusLabel;
    }
}

