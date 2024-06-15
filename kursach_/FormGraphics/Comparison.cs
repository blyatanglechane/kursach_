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
        public Comparison()
        {
            InitializeComponent();
        }

        private void ButtonIDEvent_Click(object sender, EventArgs e)
        {
            // Переменная для хранения ИД студента
            int id;

            // Проверка корректности введённых данных
            if (!int.TryParse(IDInputFood.Text, out id) || id < 1 || id > 457)
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для ID в диапазоне от 1 до 457.");
                return;
            }

            // Строка подключения к базе данных (замените на свою)
            string connectionString = "Data Source=.;Initial Catalog=DBBIA;Integrated Security=True";

            // SQL запросы для получения пола, возраста, роста и веса студента
            string queryGender = "SELECT gender FROM BIAStudent WHERE id = @id";
            string queryAge = "SELECT age FROM BIAStudent WHERE id = @id";
            string queryHeight = "SELECT height FROM BIAStudent WHERE id = @id";
            string queryWeight = "SELECT Weight FROM BIAStudent WHERE id = @id";
            string queryBMIassessment = "SELECT BMIassessment FROM BIAStudent WHERE id = @id";

            // SQL запросы для получения данных по жирам, углеводам и белкам для каждого дня недели
            string[] queries = {
        "SELECT MONProteins, MONFats, MONCarbohydrates FROM MONDayWeek WHERE id = @id",
        "SELECT TUESProteins, TUESFats, TUESCarbohydrates FROM TUESDayWeek WHERE id = @id",
        "SELECT WEDProteins, WEDFats, WEDCarbohydrates FROM WEDDayWeek WHERE id = @id",
        "SELECT THURSProteins, THURSFats, THURSCarbohydrates FROM THURSDayWeek WHERE id = @id",
        "SELECT FRIProteins, FRIFats, FRICarbohydrates FROM FRIDayWeek WHERE id = @id",
        "SELECT SATProteins, SATFats, SATCarbohydrates FROM SATDayWeek WHERE id = @id",
        "SELECT SUNProteins, SUNFats, SUNCarbohydrates FROM SUNDayWeek WHERE id = @id"
    };

            // SQL запросы для проверки активности за каждый день недели и получения калорий
            string[] queries2 = {
        "SELECT MONTheTypeOfTraining, MONCalories FROM MONDayWeek WHERE id = @id",
        "SELECT TUESTheTypeOfTraining, TUESCalories FROM TUESDayWeek WHERE id = @id",
        "SELECT WEDTheTypeOfTraining, WEDCalories FROM WEDDayWeek WHERE id = @id",
        "SELECT THURSTheTypeOfTraining, THURSCalories FROM THURSDayWeek WHERE id = @id",
        "SELECT FRITheTypeOfTraining, FRICalories FROM FRIDayWeek WHERE id = @id",
        "SELECT SATTheTypeOfTraining, SATCalories FROM SATDayWeek WHERE id = @id",
        "SELECT SUNTheTypeOfTraining, SUNCalories FROM SUNDayWeek WHERE id = @id"
    };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Получаем пол, возраст, рост и вес
                    string gender;
                    int age;
                    decimal height;
                    decimal weight;
                    string BMIassessment;

                    using (SqlCommand command = new SqlCommand(queryGender, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        gender = command.ExecuteScalar().ToString();
                    }
                    using (SqlCommand command = new SqlCommand(queryAge, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        age = (int)command.ExecuteScalar();
                    }
                    using (SqlCommand command = new SqlCommand(queryHeight, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        height = (decimal)command.ExecuteScalar();
                    }
                    using (SqlCommand command = new SqlCommand(queryWeight, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        weight = (decimal)command.ExecuteScalar();
                    }
                    using (SqlCommand command = new SqlCommand(queryBMIassessment, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        BMIassessment = command.ExecuteScalar().ToString();
                    }

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

                    // Получаем количество активных дней и калории
                    List<decimal[]> macronutrients = new List<decimal[]>();

                    // Запросы для получения данных по жирам, углеводам и белкам для каждого дня недели
                    for (int i = 0; i < queries.Length; i++)
                    {
                        using (SqlCommand command = new SqlCommand(queries[i], connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    decimal proteins = reader.GetDecimal(0);
                                    decimal fats = reader.GetDecimal(1);
                                    decimal carbohydrates = reader.GetDecimal(2);

                                    // Сохраняем данные по жирам, углеводам и белкам для каждого дня недели
                                    macronutrients.Add(new decimal[] { proteins, fats, carbohydrates });
                                }
                            }
                        }
                    }

                    // Получаем количество активных дней и калории
                    int totalActiveDays = 0;
                    decimal[] dailyCalories = new decimal[7];
                    string[] days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресение" };

                    for (int i = 0; i < queries2.Length; i++)
                    {
                        using (SqlCommand command = new SqlCommand(queries2[i], connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string activity = reader.GetString(0); // Получаем значение столбца с типом активности
                                    dailyCalories[i] = reader.GetDecimal(1); // Получаем калории
                                    if (activity != "0")
                                    {
                                        totalActiveDays++;
                                    }
                                }
                            }
                        }
                    }

                    // Применяем коэффициент активности к BMR
                    double activityFactor = 0;
                    if (totalActiveDays == 0) activityFactor = 1.2;
                    else if (totalActiveDays >= 1 && totalActiveDays <= 3) activityFactor = 1.375;
                    else if (totalActiveDays >= 4 && totalActiveDays <= 5) activityFactor = 1.55;
                    else if (totalActiveDays == 6) activityFactor = 1.725;
                    else if (totalActiveDays == 7) activityFactor = 1.9;

                    BMR *= activityFactor;

                    // Формируем результат
                    StringBuilder result = new StringBuilder();
                    result.AppendLine($"Сравнение фактического и оптимального употребления для ID {id} по жирам, углеводам и белкам:");

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
                            else if(proteinsPercentage > 35)
                                verdict += "нужно меньше белков, ";

                            if (fatsPercentage < 25)
                                verdict += "нужно больше жиров, ";
                            else if(fatsPercentage > 35)
                                verdict += "нужно меньше жиров, ";

                            if (carbohydratesPercentage < 30)
                                verdict += "нужно больше углеводов, ";
                            else if(carbohydratesPercentage > 50)
                                verdict += "нужно меньше углеводов, ";
                        }
                        else if (BMIassessment == "избыточная МТ" || BMIassessment == "ожирение I ст." || BMIassessment == "ожирение II ст." || BMIassessment == "ожирение III ст.")
                        {
                            if (proteinsPercentage < 40)
                                verdict += "нужно больше белков, ";
                            else if(proteinsPercentage > 50)
                                verdict += "нужно меньше белков, ";

                            if (fatsPercentage < 30)
                                verdict += "нужно больше жиров, ";
                            else if(fatsPercentage > 40)
                                verdict += "нужно меньше жиров, ";

                            if (carbohydratesPercentage < 30)
                                verdict += "нужно больше углеводов, ";
                            else if(carbohydratesPercentage > 50)
                                verdict += "нужно меньше углеводов, ";
                        }

                        // Убираем лишнюю запятую в конце строки
                        if (verdict.EndsWith(", "))
                            verdict = verdict.Substring(0, verdict.Length - 2);
                        if (verdict == "")
                            verdict = "норма";

                        result.AppendLine($"{days[i]}: белки - {proteins}, жиры - {fats}, углеводы - {carbohydrates}. {proteinsPercentage}%/{fatsPercentage}%/{carbohydratesPercentage}%. Вердикт: {verdict}.");
                    }
                    // Добавляем информацию о BMIassessment в конец файла
                    result.AppendLine();
                    result.AppendLine($"Результат анализа BMIassessment: {BMIassessment}");

                    result.AppendLine($"Сравнение фактического и оптимального употребления каллорий для ID {id}:\n");

                    for (int i = 0; i < days.Length; i++)
                    {
                        double difference = (double)dailyCalories[i] - BMR;
                        result.AppendLine($"{days[i]}: фактическое - {dailyCalories[i].ToString("0.##", CultureInfo.InvariantCulture)}, оптимальное - {BMR.ToString("0.##", CultureInfo.InvariantCulture)}, Разница: {difference.ToString("0.##", CultureInfo.InvariantCulture)}");
                    }

                    // Запись результата в файл
                    string filePath = "comparison.txt";
                    File.WriteAllText(filePath, result.ToString());

                    // Показать сообщение об успешной записи
                    MessageBox.Show("Результат записан в файл comparison.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

    }
}
