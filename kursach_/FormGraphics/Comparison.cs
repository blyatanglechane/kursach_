using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace kursach_.FormGraphics
{
    public partial class Comparison : Form
    {
        private string[,] excelTable;

        public Comparison(string[,] table)
        {
            InitializeComponent();
            excelTable = table;
        }

        private void ButtonIDEvent_Click(object sender, EventArgs e)
        {
            // Получаем ФИО из текстового поля
            string patient = IDInputFood.Text;

            // Поиск строки, соответствующей заданному ФИО
            int rowIndex = -1;
            for (int i = 0; i < excelTable.GetLength(0); i++)
            {
                if (excelTable[i, 0]?.Equals(patient, StringComparison.OrdinalIgnoreCase) ?? false)
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex == -1)
            {
                MessageBox.Show("Пациент не найден. Пожалуйста, введите корректное имя пациента.");
                return;
            }

            // Получаем данные студента
            string gender = excelTable[rowIndex, 1] ?? "";
            int age = int.TryParse(excelTable[rowIndex, 2], out int parsedAge) ? parsedAge : 0;
            decimal height = decimal.TryParse(excelTable[rowIndex, 3], out decimal parsedHeight) ? parsedHeight : 0;
            decimal weight = decimal.TryParse(excelTable[rowIndex, 4], out decimal parsedWeight) ? parsedWeight : 0;
            string BMIassessment = excelTable[rowIndex, 6] ?? "";

            // Рассчитываем BMR
            double BMR = 0;
            if (gender == "М")
            {
                BMR = 10 * (double)weight + 6.25 * (double)height - 5 * age + 5;
            }
            else if (gender == "Ж")
            {
                BMR = 10 * (double)weight + 6.25 * (double)height - 5 * age - 161;
            }

            // Индексы столбцов с данными для каждого дня недели
            int[] proteinIndices = { 35, 51, 67, 83, 99, 115, 131 };
            int[] fatIndices = { 36, 52, 68, 84, 100, 116, 132 };
            int[] carbIndices = { 37, 53, 69, 85, 101, 117, 133 };
            int[] calorieIndices = { 38, 54, 70, 86, 102, 118, 134 };
            int[] activityIndices = { 44, 60, 76, 92, 108, 124, 140 };

            // Получаем количество активных дней и калории
            int totalActiveDays = 0;
            decimal[] dailyCalories = new decimal[7];
            string[] days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресение" };

            decimal[][] macronutrients = new decimal[7][];
            for (int i = 0; i < 7; i++)
            {
                macronutrients[i] = new decimal[3];
                macronutrients[i][0] = decimal.TryParse(excelTable[rowIndex, proteinIndices[i]], out decimal parsedProteins) ? parsedProteins : 0;
                macronutrients[i][1] = decimal.TryParse(excelTable[rowIndex, fatIndices[i]], out decimal parsedFats) ? parsedFats : 0;
                macronutrients[i][2] = decimal.TryParse(excelTable[rowIndex, carbIndices[i]], out decimal parsedCarbs) ? parsedCarbs : 0;
                dailyCalories[i] = decimal.TryParse(excelTable[rowIndex, calorieIndices[i]], out decimal parsedCalories) ? parsedCalories : 0;

                string activity = excelTable[rowIndex, activityIndices[i]] ?? "";
                if (!string.IsNullOrEmpty(activity) && activity != "0")
                {
                    totalActiveDays++;
                }
            }

            // Применяем коэффициент активности к BMR для каждого дня
            double[] dailyBMR = new double[7];
            for (int i = 0; i < 7; i++)
            {
                string activity = excelTable[rowIndex, activityIndices[i]] ?? "";
                double activityFactor = 1.2; // Базовый коэффициент для низкой активности

                if (!string.IsNullOrEmpty(activity) && activity != "0")
                {
                    if (totalActiveDays == 1 || totalActiveDays == 2 || totalActiveDays == 3)
                    {
                        activityFactor = 1.375; // Легкая активность
                    }
                    else if (totalActiveDays == 4 || totalActiveDays == 5)
                    {
                        activityFactor = 1.55; // Средняя активность
                    }
                    else if (totalActiveDays == 6)
                    {
                        activityFactor = 1.725; // Высокая активность
                    }
                    else if (totalActiveDays == 7)
                    {
                        activityFactor = 1.9; // Очень высокая активность
                    }
                }

                dailyBMR[i] = BMR * activityFactor;
            }

            // Формируем результат для сравнения макронутриентов
            StringBuilder resultMacros = new StringBuilder();
            resultMacros.AppendLine($"Сравнение фактического и оптимального употребления для {patient} по жирам, углеводам и белкам:\n");

            for (int i = 0; i < days.Length; i++)
            {
                decimal proteins = macronutrients[i][0];
                decimal fats = macronutrients[i][1];
                decimal carbohydrates = macronutrients[i][2];

                // Расчет процентного соотношения
                decimal total = proteins + fats + carbohydrates;
                int proteinsPercentage = (int)((proteins / total) * 100);
                int fatsPercentage = (int)((fats / total) * 100);
                int carbohydratesPercentage = 100 - proteinsPercentage - fatsPercentage;

                // Нахождение минимального значения среди белков, жиров и углеводов
                decimal minMacronutrient = Math.Min(proteins, Math.Min(fats, carbohydrates));

                // Расчет соотношения макронутриентов относительно минимального значения
                decimal proteinRatio = Math.Round(proteins / minMacronutrient, 1);
                decimal fatRatio = Math.Round(fats / minMacronutrient, 1);
                decimal carbRatio = Math.Round(carbohydrates / minMacronutrient, 1);

                // Формирование строки вывода с вердиктом
                string verdict = "";
                if (BMIassessment == "дефицит МТ")
                {
                    if (proteinsPercentage < 25)
                        verdict += "нужно больше белков, ";
                    else if (proteinsPercentage > 35)
                        verdict += "нужно меньше белков, ";

                    if (fatsPercentage < 15)
                        verdict += "нужно больше жиров, ";
                    else if (fatsPercentage > 25)
                        verdict += "нужно меньше жиров, ";

                    if (carbohydratesPercentage < 40)
                        verdict += "нужно больше углеводов, ";
                    else if (carbohydratesPercentage > 60)
                        verdict += "нужно меньше углеводов, ";
                }
                else if (BMIassessment == "норма")
                {
                    if (proteinsPercentage < 25)
                        verdict += "нужно больше белков, ";
                    else if (proteinsPercentage > 35)
                        verdict += "нужно меньше белков, ";

                    if (fatsPercentage < 25)
                        verdict += "нужно больше жиров, ";
                    else if (fatsPercentage > 35)
                        verdict += "нужно меньше жиров, ";

                    if (carbohydratesPercentage < 30)
                        verdict += "нужно больше углеводов, ";
                    else if (carbohydratesPercentage > 50)
                        verdict += "нужно меньше углеводов, ";
                }
                else if (BMIassessment == "избыточная МТ" || BMIassessment == "ожирение I ст." || BMIassessment == "ожирение II ст." || BMIassessment == "ожирение III ст.")
                {
                    if (proteinsPercentage < 40)
                        verdict += "нужно больше белков, ";
                    else if (proteinsPercentage > 50)
                        verdict += "нужно меньше белков, ";

                    if (fatsPercentage < 30)
                        verdict += "нужно больше жиров, ";
                    else if (fatsPercentage > 40)
                        verdict += "нужно меньше жиров, ";

                    if (carbohydratesPercentage < 30)
                        verdict += "нужно больше углеводов, ";
                    else if (carbohydratesPercentage > 50)
                        verdict += "нужно меньше углеводов, ";
                }

                // Убираем лишнюю запятую в конце строки
                if (verdict.EndsWith(", "))
                    verdict = verdict.Substring(0, verdict.Length - 2);
                if (verdict == "")
                    verdict = "норма";

                resultMacros.AppendLine($"{days[i]}: белки - {proteins} г, жиры - {fats} г, углеводы - {carbohydrates} г.\n{proteinsPercentage}%/{fatsPercentage}%/{carbohydratesPercentage}%. \nСоотношение: {proteinRatio}:{fatRatio}:{carbRatio}. \nВердикт: {verdict}\n");
            }

            // Формируем результат для сравнения калорий
            StringBuilder resultCalories = new StringBuilder();
            resultCalories.AppendLine($"Результат анализа BMIassessment: {BMIassessment}\n");
            resultCalories.AppendLine($"Сравнение фактического и оптимального употребления калорий для {patient}:\n");

            // Итоговые калории за неделю
            decimal totalActualCalories = 0;
            decimal totalOptimalCalories = 0;

            for (int i = 0; i < days.Length; i++)
            {
                decimal actualCalories = dailyCalories[i];
                decimal optimalCalories = (decimal)dailyBMR[i];
                totalActualCalories += actualCalories;
                totalOptimalCalories += optimalCalories;
                decimal percentageDifference = ((actualCalories - optimalCalories) / optimalCalories) * 100;
                resultCalories.AppendLine($"{days[i]}: фактическое - {actualCalories}, оптимальное - {optimalCalories}, Отклонение: {Math.Abs(percentageDifference):F2}%");
            }

            // Добавляем итоговое сравнение калорий за неделю
            decimal totalCaloriesPercentageDifference = ((totalActualCalories - totalOptimalCalories) / totalOptimalCalories) * 100;
            resultCalories.AppendLine($"\nИтог за неделю: фактическое - {totalActualCalories}, оптимальное - {totalOptimalCalories}, Отклонение: {Math.Abs(totalCaloriesPercentageDifference):F2}%");

            // Запись результатов в файл "comparison.txt" в папке "Документы"
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "comparison.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(resultMacros.ToString());
                    writer.WriteLine(resultCalories.ToString());
                }
                MessageBox.Show("Результаты сравнения успешно записаны в файл comparison.txt в папке 'Документы'.", "Успешная запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comparison_Load(object sender, EventArgs e)
        {
            // Код, который нужно выполнить при загрузке формы
        }
    }
}
