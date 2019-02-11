using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SimpleJSON;

namespace Ancorupt
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        // После загрузки формы, считываем информацию из файла лицензии
        // Проверяем на корректность и выдаем соответствующее сообщение
        // Если лицензионный файл существует и он корректный, то копия зарегистрирована
        // Иначе копия не зарегистрирована
        private void LicenseForm_Load(object sender, EventArgs e)
        {
            ServerRequest.SetSessionId("");
            if (SystemInfoHelper.CheckLicense())
            {
                registrationStatusLabel.ForeColor = Color.Green;
                registrationStatusLabel.Text = "Зарегистрированная копия";
                runProgramButton.Enabled = true;
            }
            else
            {
                registrationStatusLabel.ForeColor = Color.Red;
                registrationStatusLabel.Text = "Не зарегистрированная копия";
                if (File.Exists("license.dat"))
                {
                    File.Delete("license.dat");
                }
            }
        }

        // Регистрация
        private void registrationButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(emailBox.Text) && !string.IsNullOrEmpty(passwordBox.Text))
            {
                if (emailBox.Text.Contains("@") && emailBox.Text.Contains("."))
                {
                    try
                    {
                        var response = ServerRequest.Registration(emailBox.Text, passwordBox.Text);
                        if (response["status"] == "registration")
                        {
                            ServerRequest.SetSessionId(response["session"]);
                            statusLabel.Text = "Регистрация успешно завершена";
                            registrationLoginGroup.Text = emailBox.Text;
                            buyAttachGroup.Enabled = true;
                            emailBox.Enabled = false;
                            passwordBox.Enabled = false;
                            passwordBox.Text = "";
                            registrationButton.Enabled = false;
                            loginButton.Text = "Выход";
                        }
                        else
                        {
                            statusLabel.Text = response["message"];
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = ex.Message;
                    }
                }
            }
        }

        // Вход
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginButton.Text == "Вход")
            {
                if (!string.IsNullOrEmpty(emailBox.Text) && !string.IsNullOrEmpty(passwordBox.Text))
                {
                    try
                    {
                        var response = ServerRequest.Login(emailBox.Text, passwordBox.Text);
                        if (response["status"] == "login")
                        {
                            ServerRequest.SetSessionId(response["session"]);
                            statusLabel.Text = "Вход выполнен успешно";
                            registrationLoginGroup.Text = emailBox.Text;
                            buyAttachGroup.Enabled = true;
                            emailBox.Enabled = false;
                            passwordBox.Enabled = false;
                            passwordBox.Text = "";
                            registrationButton.Enabled = false;
                            loginButton.Text = "Выход";
                        }
                        else
                        {
                            statusLabel.Text = response["message"];
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = ex.Message;
                    }
                }
            }
            else if (loginButton.Text == "Выход")
            {
                registrationLoginGroup.Text = "Регистрация / Вход";
                buyAttachGroup.Enabled = false;
                emailBox.Enabled = true;
                passwordBox.Enabled = true;
                registrationButton.Enabled = true;
                loginButton.Text = "Вход";
                ServerRequest.SetSessionId("");
            }
        }

        // Купить
        private void buyButton_Click(object sender, EventArgs e)
        {
            if (ServerRequest.Logged())
            {
                try
                {
                    var response = ServerRequest.Buy();
                    if (response["status"] == "buy")
                    {
                        statusLabel.Text = "Благодарим за приобретение продукта";
                        licenseKeyBox.Text = new RSAHelper().Decrypt(response["key"], true);
                    }
                    else
                    {
                        statusLabel.Text = response["message"];
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = ex.Message;
                }
            }
        }

        // Привязать ключ
        private void attachButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(licenseKeyBox.Text) || ServerRequest.Logged())
            {
                try
                {
                    var response = ServerRequest.Attach(string.IsNullOrEmpty(licenseKeyBox.Text) ? "" : licenseKeyBox.Text);
                    if (response["status"] == "attach")
                    {
                        File.WriteAllText("license.dat", response["license"]);
                        runProgramButton.Enabled = true;
                        registrationStatusLabel.ForeColor = Color.Green;
                        registrationStatusLabel.Text = "Зарегистрированная копия";
                        statusLabel.Text = "Ключ успешно привязан к текущему компьютеру";
                    }
                    else
                    {
                        statusLabel.Text = response["message"];
                    }
                }
                catch (Exception ex) { statusLabel.Text = "Сервер временно недоступен"; }
            }
        }

        // Восстановить ключ
        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (ServerRequest.Logged())
            {
                try
                {
                    var response = ServerRequest.Recover();
                    if (response["status"] == "recover")
                    {
                        statusLabel.Text = "Ваш ключ успешно восстановлен";
                        licenseKeyBox.Text = Encoding.UTF8.GetString(Convert.FromBase64String(response["key"]));
                    }
                    else
                    {
                        statusLabel.Text = response["message"];
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = ex.Message;
                }
            }
        }

        // Запуск программы
        private void runProgramButton_Click(object sender, EventArgs e)
        {
            if (SystemInfoHelper.CheckLicense())
            {
                new MainForm().ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Неудалось запустить программу. Главный файл программы поврежден.");
                runProgramButton.Enabled = false;
                registrationStatusLabel.ForeColor = Color.Red;
                registrationStatusLabel.Text = "Не зарегистрированная копия";
                if (File.Exists("license.dat"))
                {
                    File.Delete("license.dat");
                }
            }
        }
    }
}
