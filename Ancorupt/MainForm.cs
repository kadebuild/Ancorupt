using System;
using System.Windows.Forms;

namespace Ancorupt
{
    public partial class MainForm : Form
    {
        // Защищаемая программа, не несет в себе никакой практической пользы
        // Простая форма с TextBox и возможностью открывать и сохранять текстовые файлы
        // Каждый раз при открытии или сохранении файла проверяется лицензия
        // Если окажется, что файл отсутствует или лицензия не совпадает с параметрами текущего компьютера
        // Тогда программа закроется и выдаст ошибку
        public MainForm()
        {
            InitializeComponent();
        }

        // Сохранить в файл
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            // После того, как пользователь выбрал файл
            // Проверяем наличие и верность лицензии
            // Если все в порядке, продолжаем работу программы
            // Иначе закрываем форму и выдаем ошибку
            if (SystemInfoHelper.CheckLicense())
            {
                System.IO.File.WriteAllText(filename, simpleTextBox.Text);
                MessageBox.Show("Файл сохранен");
            }
            else
            {
                MessageBox.Show("Неудалось сохранить файл");
                Close();
            }
        }

        // Закрыть форму
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Открыть файл
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            // После того, как пользователь выбрал файл
            // Проверяем наличие и верность лицензии
            // Если все в порядке, продолжаем работу программы
            // Иначе закрываем форму и выдаем ошибку
            if (SystemInfoHelper.CheckLicense())
            {
                simpleTextBox.Text = System.IO.File.ReadAllText(filename);
            }
            else
            {
                MessageBox.Show("Неудается открыть файл");
                Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ancorupt - protection from run on another computer");
        }
    }
}
