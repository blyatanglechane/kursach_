using System;
using System.IO;
using System.Windows.Forms;

namespace kursach_.FormGraphics
{
    public partial class Week : Form
    {
        private string[,] excelTable;

        public Week(string[,] table)
        {
            InitializeComponent();
            excelTable = table;
        }

        private void ButtonFCsEvent_Click(object sender, EventArgs e)
        {
            // Получаем ФИО из текстового поля
            string patient = FCsInput.Text;

            // Получаем данные для заданного ФИО
            var (avgProteins, avgFats, avgCarbohydrates, avgCalories) = GetWeeklyAveragesByName(patient);

            if (avgProteins == -1)
            {
                MessageBox.Show("Пациент не найден. Пожалуйста, введите корректное имя пациента.");
                return;
            }

            // Форматирование результата
            string result = $"Результат по пациенту {patient} за неделю:\nБелки: {avgProteins:F1}\nЖиры: {avgFats:F1}\nУглеводы: {avgCarbohydrates}\nКалории: {avgCalories:F1}";

            // Получаем средние значения за неделю по всем студентам
            var (overallAvgProteins, overallAvgFats, overallAvgCarbohydrates, overallAvgCalories) = GetWeeklyAveragesForAll();

            result += $"\n\nСреднее значение за неделю по всем студентам:\nБелки: {overallAvgProteins:F1}\nЖиры: {overallAvgFats:F1}\nУглеводы: {overallAvgCarbohydrates:F1}\nКалории: {overallAvgCalories:F1}";

            // Запись результата в файл weeklyFCs.txt
            string filePath = "weeklyFCs.txt";
            File.WriteAllText(filePath, result);

            // Показать сообщение об успешной записи
            MessageBox.Show("Результат записан в файл weeklyFCs.txt");
        }

        private (decimal avgProteins, decimal avgFats, decimal avgCarbohydrates, decimal avgCalories) GetWeeklyAveragesByName(string patient)
        {
            // Поиск строки, соответствующей заданному ФИО
            int rowIndex = -1;
            for (int i = 0; i < excelTable.GetLength(0); i++)
            {
                if (excelTable[i, 0].Equals(patient, StringComparison.OrdinalIgnoreCase)) // Предполагается, что ФИО находится в первом столбце (индекс 0)
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex == -1)
            {
                return (-1, -1, -1, -1); // Пациент не найден
            }

            // Индексы столбцов с данными
            int[] proteinIndices = { 35, 51, 67, 83, 99, 115, 131 };
            int[] fatIndices = { 36, 52, 68, 84, 100, 116, 132 };
            int[] carbIndices = { 37, 53, 69, 85, 101, 117, 133 };
            int[] calorieIndices = { 38, 54, 70, 86, 102, 118, 134 };

            decimal totalProteins = 0, totalFats = 0, totalCarbohydrates = 0, totalCalories = 0;
            int daysCount = 7;

            foreach (var index in proteinIndices)
            {
                if (excelTable[rowIndex, index] == "-")
                {
                    return (-1, -1, -1, -1); // Если хотя бы одно значение равно "-", пропускаем этого студента
                }
                totalProteins += Convert.ToDecimal(excelTable[rowIndex, index]);
            }
            foreach (var index in fatIndices)
            {
                if (excelTable[rowIndex, index] == "-")
                {
                    return (-1, -1, -1, -1);
                }
                totalFats += Convert.ToDecimal(excelTable[rowIndex, index]);
            }
            foreach (var index in carbIndices)
            {
                if (excelTable[rowIndex, index] == "-")
                {
                    return (-1, -1, -1, -1);
                }
                totalCarbohydrates += Convert.ToDecimal(excelTable[rowIndex, index]);
            }
            foreach (var index in calorieIndices)
            {
                if (excelTable[rowIndex, index] == "-")
                {
                    return (-1, -1, -1, -1);
                }
                totalCalories += Convert.ToDecimal(excelTable[rowIndex, index]);
            }

            return (totalProteins / daysCount, totalFats / daysCount, totalCarbohydrates / daysCount, totalCalories / daysCount);
        }

        private (decimal avgProteins, decimal avgFats, decimal avgCarbohydrates, decimal avgCalories) GetWeeklyAveragesForAll()
        {
            // Индексы столбцов с данными
            int[] proteinIndices = { 35, 51, 67, 83, 99, 115, 131 };
            int[] fatIndices = { 36, 52, 68, 84, 100, 116, 132 };
            int[] carbIndices = { 37, 53, 69, 85, 101, 117, 133 };
            int[] calorieIndices = { 38, 54, 70, 86, 102, 118, 134 };

            decimal totalProteins = 0, totalFats = 0, totalCarbohydrates = 0, totalCalories = 0;
            int validStudentCount = 0;

            for (int i = 1; i < excelTable.GetLength(0); i++)
            {
                decimal studentProteins = 0, studentFats = 0, studentCarbohydrates = 0, studentCalories = 0;
                bool validData = true;

                foreach (var index in proteinIndices)
                {
                    if (excelTable[i, index] == "-")
                    {
                        validData = false;
                        break;
                    }
                    studentProteins += Convert.ToDecimal(excelTable[i, index]);
                }

                if (!validData) continue;

                foreach (var index in fatIndices)
                {
                    if (excelTable[i, index] == "-")
                    {
                        validData = false;
                        break;
                    }
                    studentFats += Convert.ToDecimal(excelTable[i, index]);
                }

                if (!validData) continue;

                foreach (var index in carbIndices)
                {
                    if (excelTable[i, index] == "-")
                    {
                        validData = false;
                        break;
                    }
                    studentCarbohydrates += Convert.ToDecimal(excelTable[i, index]);
                }

                if (!validData) continue;

                foreach (var index in calorieIndices)
                {
                    if (excelTable[i, index] == "-")
                    {
                        validData = false;
                        break;
                    }
                    studentCalories += Convert.ToDecimal(excelTable[i, index]);
                }

                if (!validData) continue;

                totalProteins += studentProteins;
                totalFats += studentFats;
                totalCarbohydrates += studentCarbohydrates;
                totalCalories += studentCalories;
                validStudentCount++;
            }

            if (validStudentCount == 0)
            {
                return (0, 0, 0, 0);
            }

            int daysCount = 7;
            return (totalProteins / (validStudentCount * daysCount), totalFats / (validStudentCount * daysCount), totalCarbohydrates / (validStudentCount * daysCount), totalCalories / (validStudentCount * daysCount));
        }
    }
}
