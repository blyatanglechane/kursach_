using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace kursach_.FormGraphics
{
    public partial class Day : Form
    {
        private string[,] excelTable;

        public Day(string[,] table)
        {
            InitializeComponent();
            excelTable = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка корректности введённых данных
            string name = DayIdInput.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите корректное имя.");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите день недели.");
                return;
            }

            string selectedDay = comboBox1.SelectedItem.ToString();
            int dayColumnOffset;

            switch (selectedDay)
            {
                case "понедельник":
                    dayColumnOffset = 35;
                    break;
                case "вторник":
                    dayColumnOffset = 51;
                    break;
                case "среда":
                    dayColumnOffset = 67;
                    break;
                case "четверг":
                    dayColumnOffset = 83;
                    break;
                case "пятница":
                    dayColumnOffset = 99;
                    break;
                case "суббота":
                    dayColumnOffset = 115;
                    break;
                case "воскресенье":
                    dayColumnOffset = 131;
                    break;
                default:
                    MessageBox.Show("Неверный день недели.");
                    return;
            }

            try
            {
                // Найдем строку для заданного имени
                string[] studentData = null;
                for (int i = 0; i < excelTable.GetLength(0); i++)
                {
                    if (excelTable[i, 0].Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        studentData = new string[excelTable.GetLength(1)];
                        for (int j = 0; j < excelTable.GetLength(1); j++)
                        {
                            studentData[j] = excelTable[i, j];
                        }
                        break;
                    }
                }

                if (studentData == null)
                {
                    MessageBox.Show("Нет данных для указанного имени.");
                    return;
                }

                // Извлечение данных
                decimal proteins = decimal.Parse(studentData[dayColumnOffset]);
                decimal fats = decimal.Parse(studentData[dayColumnOffset + 1]);
                decimal carbohydrates = decimal.Parse(studentData[dayColumnOffset + 2]);
                decimal calories = decimal.Parse(studentData[dayColumnOffset + 3]);

                string output = $@"Дневная выгрузка для {name}:
{selectedDay}:
Жиры - {fats:F1};
Углеводы - {carbohydrates:F1};
Белки - {proteins:F1};
Калории - {calories:F1};
";

                // Рассчитываем средние значения БЖУК по всем студентам
                decimal totalProteins = 0;
                decimal totalFats = 0;
                decimal totalCarbohydrates = 0;
                decimal totalCalories = 0;
                int studentCount = 0;

                for (int i = 0; i < excelTable.GetLength(0); i++)
                {
                    // Проверка на наличие знака "-"
                    if (excelTable[i, dayColumnOffset] == "-" ||
                        excelTable[i, dayColumnOffset + 1] == "-" ||
                        excelTable[i, dayColumnOffset + 2] == "-" ||
                        excelTable[i, dayColumnOffset + 3] == "-")
                    {
                        continue;
                    }

                    if (decimal.TryParse(excelTable[i, dayColumnOffset], out decimal p) &&
                        decimal.TryParse(excelTable[i, dayColumnOffset + 1], out decimal f) &&
                        decimal.TryParse(excelTable[i, dayColumnOffset + 2], out decimal c) &&
                        decimal.TryParse(excelTable[i, dayColumnOffset + 3], out decimal cal))
                    {
                        totalProteins += p;
                        totalFats += f;
                        totalCarbohydrates += c;
                        totalCalories += cal;
                        studentCount++;
                    }
                }

                if (studentCount > 0)
                {
                    decimal avgProteins = totalProteins / studentCount;
                    decimal avgFats = totalFats / studentCount;
                    decimal avgCarbohydrates = totalCarbohydrates / studentCount;
                    decimal avgCalories = totalCalories / studentCount;

                    output += $@"
Среднее значение БЖУК по всем студентам:
Белки - {avgProteins:F1};
Жиры - {avgFats:F1};
Углеводы - {avgCarbohydrates:F1};
Калории - {avgCalories:F1};";
                }
                else
                {
                    output += "\nНет данных для расчета средних значений.";
                }

                // Запись в текстовый файл в папке "Документы"
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DayReport.txt");
                File.WriteAllText(filePath, output);
                MessageBox.Show($"Результаты записаны в файл {filePath}", "Успешная запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
