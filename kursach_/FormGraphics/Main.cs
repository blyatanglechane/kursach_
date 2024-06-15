using kursach_.FormGraphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_
{
    public partial class Main : Form
    {
        DataBase dataBase = new DataBase();

        public Main()
        {
            InitializeComponent();
        }

        private void Graphic1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы
            FormGraphics.Day formGraphics1 = new FormGraphics.Day();

            // Отображаем форму
            formGraphics1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Graphic2_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы
            Week formGraphics2 = new Week();

            // Отображаем форму
            formGraphics2.Show();
        }

        private void MainLogo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы
            Comparison formComparison = new Comparison();

            // Отображаем форму
            formComparison.Show();
        }
    }
}
