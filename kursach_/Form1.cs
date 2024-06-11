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
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void Graphic1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы
            FormGraphics1 formGraphics1 = new FormGraphics1();

            // Отображаем форму
            formGraphics1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Graphic2_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр новой формы
            FormGraphics2 formGraphics2 = new FormGraphics2();

            // Отображаем форму
            formGraphics2.Show();
        }


    }
}
