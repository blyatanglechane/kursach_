using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kursach_.FormGraphics
{
    public partial class FormGraphics2 : Form
    {
        DataBase database = new DataBase();

        public FormGraphics2()
        {
            InitializeComponent();
        }
        private void ButtonIDEvent_Click(object sender, EventArgs e)
        {
            // Проверка корректности введённых данных
            if (!int.TryParse(IDInput.Text, out int id) || id < 1 || id > 457)
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для ID в диапазоне от 1 до 457.");
                return;
            }

            // Строка подключения к базе данных (замените на свою)
            string connectionString = "Data Source=.;Initial Catalog=DBBIA;Integrated Security=True";

            // SQL запрос для суммирования белков
            string queryProteins = @"SELECT ISNULL(MON.MONProteins, 0) + ISNULL(TUE.TUESProteins, 0) + ISNULL(WED.WEDProteins, 0) + ISNULL(THU.THURSProteins, 0) + ISNULL(FRI.FRIProteins, 0) + ISNULL(SAT.SATProteins, 0) + ISNULL(SUN.SUNProteins, 0) AS TotalProteins 
                                 FROM BIAStudent S 
                                 LEFT JOIN MONDayWeek MON ON S.id = MON.id
                                 LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
                                 LEFT JOIN WEDDayWeek WED ON S.id = WED.id
                                 LEFT JOIN THURSDayWeek THU ON S.id = THU.id
                                 LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
                                 LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
                                 LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
                                 WHERE S.id = @id";

            // SQL запрос для суммирования жиров
            string queryFats = @"SELECT ISNULL(MON.MONFats, 0) + ISNULL(TUE.TUESFats, 0) + ISNULL(WED.WEDFats, 0) + ISNULL(THU.THURSFats, 0) + ISNULL(FRI.FRIFats, 0) + ISNULL(SAT.SATFats, 0) + ISNULL(SUN.SUNFats, 0) AS TotalFats 
                             FROM BIAStudent S 
                             LEFT JOIN MONDayWeek MON ON S.id = MON.id
                             LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
                             LEFT JOIN WEDDayWeek WED ON S.id = WED.id
                             LEFT JOIN THURSDayWeek THU ON S.id = THU.id
                             LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
                             LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
                             LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
                             WHERE S.id = @id";
            string queryCarbohydrates = @"SELECT ISNULL(MON.MONCarbohydrates, 0) + ISNULL(TUE.TUESCarbohydrates, 0) + ISNULL(WED.WEDCarbohydrates, 0) + ISNULL(THU.THURSCarbohydrates, 0) + ISNULL(FRI.FRICarbohydrates, 0) + ISNULL(SAT.SATCarbohydrates, 0) + ISNULL(SUN.SUNCarbohydrates, 0) AS TotalCarbohydrates FROM BIAStudent S LEFT JOIN MONDayWeek MON ON S.id = MON.id
            LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
            LEFT JOIN WEDDayWeek WED ON S.id = WED.id
            LEFT JOIN THURSDayWeek THU ON S.id = THU.id
            LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
            LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
            LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
            WHERE S.id = @id";

            string queryCalories = @"SELECT ISNULL(MON.MONCalories, 0) + ISNULL(TUE.TUESCalories, 0) + ISNULL(WED.WEDCalories, 0) + ISNULL(THU.THURSCalories, 0) + ISNULL(FRI.FRICalories, 0) + ISNULL(SAT.SATCalories, 0) + ISNULL(SUN.SUNCalories, 0) AS TotalCalories FROM BIAStudent S LEFT JOIN MONDayWeek MON ON S.id = MON.id
            LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
            LEFT JOIN WEDDayWeek WED ON S.id = WED.id
            LEFT JOIN THURSDayWeek THU ON S.id = THU.id
            LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
            LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
            LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
            WHERE S.id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Выполнение первого запроса (Белки)
                    SqlCommand commandProteins = new SqlCommand(queryProteins, connection);
                    commandProteins.Parameters.AddWithValue("@id", id);
                    decimal totalProteins = (decimal)commandProteins.ExecuteScalar();

                    // Выполнение второго запроса (Жиры)
                    SqlCommand commandFats = new SqlCommand(queryFats, connection);
                    commandFats.Parameters.AddWithValue("@id", id);
                    decimal totalFats = (decimal)commandFats.ExecuteScalar();

                    // Выполнение третьего запроса (Углеводы)
                    SqlCommand commandCarbohydrates = new SqlCommand(queryCarbohydrates, connection);
                    commandCarbohydrates.Parameters.AddWithValue("@id", id);
                    decimal totalCarbohydrates = (decimal)commandCarbohydrates.ExecuteScalar();

                    // Выполнение четвёртого запроса (Калории)
                    SqlCommand commandCalories = new SqlCommand(queryCalories, connection);
                    commandCalories.Parameters.AddWithValue("@id", id);
                    decimal totalCalories = (decimal)commandCalories.ExecuteScalar();

                    // Форматирование результата
                    string result = $"Результат по ID {id} за неделю:\nБелки: {totalProteins}\nЖиры: {totalFats}\nУглеводы: {totalCarbohydrates}\nКалории: {totalCalories}";

                    // Запись результата в файл input.txt
                    string filePath = "weeklyID.txt";
                    File.WriteAllText(filePath, result);

                    // Показать сообщение об успешной записи
                    MessageBox.Show("Результат записан в файл weeklyID.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void ButtonFCsEvent_Click(object sender, EventArgs e)
        {
            // Получаем ID из текстового поля
            string patient = FCsInput.Text;

            // Строка подключения к базе данных (замените на свою)
            string connectionString = "Data Source=.;Initial Catalog=DBBIA;Integrated Security=True";

            // SQL запрос для проверки наличия пациента
            string queryCheckPatient = "SELECT COUNT(*) FROM BIAStudent WHERE patient = @patient";

            // SQL запрос для суммирования белков
            string queryProteins = @"SELECT ISNULL(MON.MONProteins, 0) + ISNULL(TUE.TUESProteins, 0) + ISNULL(WED.WEDProteins, 0) + ISNULL(THU.THURSProteins, 0) + ISNULL(FRI.FRIProteins, 0) + ISNULL(SAT.SATProteins, 0) + ISNULL(SUN.SUNProteins, 0) AS TotalProteins 
                                 FROM BIAStudent S 
                                 LEFT JOIN MONDayWeek MON ON S.id = MON.id
                                 LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
                                 LEFT JOIN WEDDayWeek WED ON S.id = WED.id
                                 LEFT JOIN THURSDayWeek THU ON S.id = THU.id
                                 LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
                                 LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
                                 LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
                                 WHERE S.patient = @patient";

            // SQL запрос для суммирования жиров
            string queryFats = @"SELECT ISNULL(MON.MONFats, 0) + ISNULL(TUE.TUESFats, 0) + ISNULL(WED.WEDFats, 0) + ISNULL(THU.THURSFats, 0) + ISNULL(FRI.FRIFats, 0) + ISNULL(SAT.SATFats, 0) + ISNULL(SUN.SUNFats, 0) AS TotalFats 
                             FROM BIAStudent S 
                             LEFT JOIN MONDayWeek MON ON S.id = MON.id
                             LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
                             LEFT JOIN WEDDayWeek WED ON S.id = WED.id
                             LEFT JOIN THURSDayWeek THU ON S.id = THU.id
                             LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
                             LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
                             LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
                             WHERE S.patient = @patient";

            string queryCarbohydrates = @"SELECT ISNULL(MON.MONCarbohydrates, 0) + ISNULL(TUE.TUESCarbohydrates, 0) + ISNULL(WED.WEDCarbohydrates, 0) + ISNULL(THU.THURSCarbohydrates, 0) + ISNULL(FRI.FRICarbohydrates, 0) + ISNULL(SAT.SATCarbohydrates, 0) + ISNULL(SUN.SUNCarbohydrates, 0) AS TotalCarbohydrates FROM BIAStudent S LEFT JOIN MONDayWeek MON ON S.id = MON.id
            LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
            LEFT JOIN WEDDayWeek WED ON S.id = WED.id
            LEFT JOIN THURSDayWeek THU ON S.id = THU.id
            LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
            LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
            LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
            WHERE S.patient = @patient";

            string queryCalories = @"SELECT ISNULL(MON.MONCalories, 0) + ISNULL(TUE.TUESCalories, 0) + ISNULL(WED.WEDCalories, 0) + ISNULL(THU.THURSCalories, 0) + ISNULL(FRI.FRICalories, 0) + ISNULL(SAT.SATCalories, 0) + ISNULL(SUN.SUNCalories, 0) AS TotalCalories FROM BIAStudent S LEFT JOIN MONDayWeek MON ON S.id = MON.id
            LEFT JOIN TUESDayWeek TUE ON S.id = TUE.id
            LEFT JOIN WEDDayWeek WED ON S.id = WED.id
            LEFT JOIN THURSDayWeek THU ON S.id = THU.id
            LEFT JOIN FRIDayWeek FRI ON S.id = FRI.id
            LEFT JOIN SATDayWeek SAT ON S.id = SAT.id
            LEFT JOIN SUNDayWeek SUN ON S.id = SUN.id
            WHERE S.patient = @patient";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверка наличия пациента
                    SqlCommand commandCheckPatient = new SqlCommand(queryCheckPatient, connection);
                    commandCheckPatient.Parameters.AddWithValue("@patient", patient);
                    int patientCount = (int)commandCheckPatient.ExecuteScalar();

                    if (patientCount == 0)
                    {
                        MessageBox.Show("Пациент не найден. Пожалуйста, введите корректное имя пациента.");
                        return;
                    }

                    // Выполнение первого запроса (Белки)
                    SqlCommand commandProteins = new SqlCommand(queryProteins, connection);
                    commandProteins.Parameters.AddWithValue("@patient", patient);
                    decimal totalProteins = (decimal)commandProteins.ExecuteScalar();

                    // Выполнение второго запроса (Жиры)
                    SqlCommand commandFats = new SqlCommand(queryFats, connection);
                    commandFats.Parameters.AddWithValue("@patient", patient);
                    decimal totalFats = (decimal)commandFats.ExecuteScalar();

                    // Выполнение третьего запроса (Углеводы)
                    SqlCommand commandCarbohydrates = new SqlCommand(queryCarbohydrates, connection);
                    commandCarbohydrates.Parameters.AddWithValue("@patient", patient);
                    decimal totalCarbohydrates = (decimal)commandCarbohydrates.ExecuteScalar();

                    // Выполнение четвёртого запроса (Калории)
                    SqlCommand commandCalories = new SqlCommand(queryCalories, connection);
                    commandCalories.Parameters.AddWithValue("@patient", patient);
                    decimal totalCalories = (decimal)commandCalories.ExecuteScalar();

                    // Форматирование результата
                    string result = $"Результат по пациенту {patient} за неделю:\nБелки: {totalProteins}\nЖиры: {totalFats}\nУглеводы: {totalCarbohydrates}\nКалории: {totalCalories}";

                    // Запись результата в файл weeklyFCs.txt
                    string filePath = "weeklyFCs.txt";
                    File.WriteAllText(filePath, result);

                    // Показать сообщение об успешной записи
                    MessageBox.Show("Результат записан в файл weeklyFCs.txt");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
