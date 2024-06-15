using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kursach_.FormGraphics
{
    public partial class Day : Form
    {
        public Day()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка корректности введённых данных
            if (!int.TryParse(DayIdInput.Text, out int id) || id < 1 || id > 457)
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для ID в диапазоне от 1 до 457.");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите день недели.");
                return;
            }

            string selectedDay = comboBox1.SelectedItem.ToString();
            string tableName = "";
            string proteinsColumn = "";
            string fatsColumn = "";
            string carbohydratesColumn = "";
            string caloriesColumn = "";

            switch (selectedDay)
            {
                case "понедельник":
                    tableName = "MONDayWeek";
                    proteinsColumn = "MONProteins";
                    fatsColumn = "MONFats";
                    carbohydratesColumn = "MONCarbohydrates";
                    caloriesColumn = "MONCalories";
                    break;
                case "вторник":
                    tableName = "TUESDayWeek";
                    proteinsColumn = "TUESProteins";
                    fatsColumn = "TUESFats";
                    carbohydratesColumn = "TUESCarbohydrates";
                    caloriesColumn = "TUESCalories";
                    break;
                case "среда":
                    tableName = "WEDDayWeek";
                    proteinsColumn = "WEDProteins";
                    fatsColumn = "WEDFats";
                    carbohydratesColumn = "WEDCarbohydrates";
                    caloriesColumn = "WEDCalories";
                    break;
                case "четверг":
                    tableName = "THURSDayWeek";
                    proteinsColumn = "THURSProteins";
                    fatsColumn = "THURSFats";
                    carbohydratesColumn = "THURSCarbohydrates";
                    caloriesColumn = "THURSCalories";
                    break;
                case "пятница":
                    tableName = "FRIDayWeek";
                    proteinsColumn = "FRIProteins";
                    fatsColumn = "FRIFats";
                    carbohydratesColumn = "FRICarbohydrates";
                    caloriesColumn = "FRICalories";
                    break;
                case "суббота":
                    tableName = "SATDayWeek";
                    proteinsColumn = "SATProteins";
                    fatsColumn = "SATFats";
                    carbohydratesColumn = "SATCarbohydrates";
                    caloriesColumn = "SATCalories";
                    break;
                case "воскресенье":
                    tableName = "SUNDayWeek";
                    proteinsColumn = "SUNProteins";
                    fatsColumn = "SUNFats";
                    carbohydratesColumn = "SUNCarbohydrates";
                    caloriesColumn = "SUNCalories";
                    break;
                default:
                    MessageBox.Show("Неверный день недели.");
                    return;
            }

            string connectionString = "Data Source=.;Initial Catalog=DBBIA;Integrated Security=True";
            string query = $@"
        SELECT 
            ISNULL({proteinsColumn}, 0) AS Proteins,
            ISNULL({fatsColumn}, 0) AS Fats,
            ISNULL({carbohydratesColumn}, 0) AS Carbohydrates,
            ISNULL({caloriesColumn}, 0) AS Calories
        FROM {tableName}
        WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal proteins = reader.GetDecimal(0);
                                decimal fats = reader.GetDecimal(1);
                                decimal carbohydrates = reader.GetDecimal(2);
                                decimal calories = reader.GetDecimal(3);

                                string output = $@"
Дневная выгрузка по ID {id}:
{selectedDay}:
Жиры - {fats};
Углеводы - {carbohydrates};
Белки - {proteins};
Калории - {calories};";

                                MessageBox.Show(output);

                                // Запись в текстовый файл
                                string filePath = "DayReport.txt";
                                File.WriteAllText(filePath, output);

                                MessageBox.Show($"Результаты записаны в файл {filePath}");
                            }
                            else
                            {
                                MessageBox.Show("Нет данных для указанного ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
