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
            double BMR = 0;

            // Проверка корректности введённых данных
            if (!int.TryParse(IDInputFood.Text, out int id) || id < 1 || id > 457)
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

            // SQL запросы для проверки активности за каждый день недели и получения калорий
            string[] queries = {
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

                    // Рассчитываем BMR
                    if (gender == "М")
                    {
                        BMR = 10 * (double)weight + 6.25 * (double)height - 5 * age + 5;
                    }
                    else if (gender == "Ж")
                    {
                        BMR = 10 * (double)weight + 6.25 * (double)height - 5 * age - 161;
                    }

                    // Получаем количество активных дней и калории
                    int totalActiveDays = 0;
                    decimal[] dailyCalories = new decimal[7];
                    string[] days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

                    for (int i = 0; i < queries.Length; i++)
                    {
                        using (SqlCommand command = new SqlCommand(queries[i], connection))
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

                    // Применяем коэффициент активности
                    if (totalActiveDays == 0) BMR *= 1.2;
                    else if (totalActiveDays >= 1 && totalActiveDays <= 3) BMR *= 1.375;
                    else if (totalActiveDays >= 4 && totalActiveDays <= 5) BMR *= 1.55;
                    else if (totalActiveDays == 6) BMR *= 1.725;
                    else if (totalActiveDays == 7) BMR *= 1.9;

                    // Формируем результат
                    string result = $"Сравнение фактического и оптимального употребления для ID {id}:\n";
                    for (int i = 0; i < days.Length; i++)
                    {
                        double difference = (double)dailyCalories[i] - BMR;
                        result += $"{days[i]}: фактическое - {dailyCalories[i].ToString("0.##", CultureInfo.InvariantCulture)}, оптимальное - {BMR.ToString("0.##", CultureInfo.InvariantCulture)}, Разница: {difference.ToString("0.##", CultureInfo.InvariantCulture)}\n";
                    }

                    // Запись результата в файл
                    string filePath = "comparison.txt";
                    File.WriteAllText(filePath, result);

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
