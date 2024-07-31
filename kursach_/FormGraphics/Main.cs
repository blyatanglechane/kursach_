using kursach_.FormGraphics;
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
using OfficeOpenXml;

namespace kursach_
{
    public partial class Main : Form
    {
        // двумерный массив для хранения данных из таблицы
        private string[,] excelTable;

        // общее количество строк
        private int totalRows = 0;

        // общее количество столбцов
        private int totalColumns = 0;

        // логическая переменная для проверки загрузки файла
        private bool isFileLoaded = false;

        public Main()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // покажем пользователю openFileDialog и запишем результат пользователя в res
                DialogResult res = openFileDialog1.ShowDialog();

                // если файл выбранный пользователем корректен и был принят
                if (res == DialogResult.OK)
                {
                    // установка контекста лицензии
                    OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    // excelFile представляет наш excel файл
                    using (var excelFile = new ExcelPackage(new FileInfo(openFileDialog1.FileName)))
                    {
                        if (excelFile.Workbook.Worksheets.Count == 0)
                        {
                            throw new Exception("Файл не содержит рабочих листов!");
                        }

                        // найдем лист с именем "Лист1"
                        // worksheet - это ссылка на найденный рабочий лист в Excel
                        ExcelWorksheet worksheet = excelFile.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Лист1");
                        if (worksheet == null)
                        {
                            throw new Exception("Лист с именем 'Лист1' не найден!");
                        }

                        // получаем общее количество строк и столбцов в нашем листе excel файла
                        totalRows = worksheet.Dimension?.End.Row ?? 0;
                        totalColumns = worksheet.Dimension?.End.Column ?? 0;

                        if (totalRows == 0 || totalColumns == 0)
                        {
                            throw new Exception("Лист пустой или не имеет данных!");
                        }

                        // временный список для хранения строк
                        List<List<string>> tempTable = new List<List<string>>();

                        // перебираем все строки
                        for (int rowIndex = 1; rowIndex <= totalRows; rowIndex++)
                        {
                            // временный список для текущей строки
                            List<string> row = new List<string>();

                            bool isRowEmpty = true;

                            // перебираем все столбцы в текущей строке
                            for (int colIndex = 1; colIndex <= totalColumns; colIndex++)
                            {
                                // получаем значение ячейки
                                object cellValue = worksheet.Cells[rowIndex, colIndex].Value;

                                // заменяем пустые ячейки на "-"
                                string cellText = cellValue == null ? "-" : cellValue.ToString().Replace('.', ',');

                                // добавляем значение в текущую строку
                                row.Add(cellText);

                                // проверяем, есть ли непустая ячейка
                                if (cellValue != null)
                                {
                                    isRowEmpty = false;
                                }
                            }

                            // добавляем строку в таблицу, если она не пустая
                            if (!isRowEmpty)
                            {
                                tempTable.Add(row);
                            }
                        }

                        // вычисляем итоговое количество строк и столбцов
                        totalRows = tempTable.Count;
                        totalColumns = tempTable.Max(row => row.Count);

                        // инициализируем массив
                        excelTable = new string[totalRows, totalColumns];

                        // заполняем двумерный массив
                        for (int i = 0; i < totalRows; i++)
                        {
                            for (int j = 0; j < totalColumns; j++)
                            {
                                // заполняем массив, заменяя отсутствующие значения на "-"
                                excelTable[i, j] = j < tempTable[i].Count ? tempTable[i][j] : "-";
                            }
                        }

                        // устанавливаем флаг, что файл был успешно загружен
                        isFileLoaded = true;
                    }
                }
                // если пользователь не выбрал файл
                else
                {
                    throw new Exception("Файл не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteArrayToTxtFile(string filePath)
        {
            try
            {
                // создаем или перезаписываем файл
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // перебираем все строки и столбцы двумерного массива
                    for (int i = 0; i < totalRows; i++)
                    {
                        for (int j = 0; j < totalColumns; j++)
                        {
                            // записываем значение в файл
                            writer.Write(excelTable[i, j]);

                            // добавляем разделитель (табуляция) между значениями
                            writer.Write(j < totalColumns - 1 ? "\t" : Environment.NewLine);
                        }
                    }
                }

                MessageBox.Show($"Данные были успешно записаны в файл {filePath}", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи данных в файл: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Graphic1_Click(object sender, EventArgs e)
        {
            // проверяем, загружен ли файл
            if (!isFileLoaded)
            {
                MessageBox.Show("Пожалуйста, загрузите файл Excel перед выполнением этой операции.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // создаем экземпляр новой формы
            FormGraphics.Day formGraphics1 = new FormGraphics.Day(excelTable);

            // отображаем форму
            formGraphics1.Show();
        }

        private void Graphic2_Click(object sender, EventArgs e)
        {
            // проверяем, загружен ли файл
            if (!isFileLoaded)
            {
                MessageBox.Show("Пожалуйста, загрузите файл Excel перед выполнением этой операции.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // создаем экземпляр новой формы
            Week formGraphics2 = new Week(excelTable);

            // отображаем форму
            formGraphics2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // проверяем, загружен ли файл
            if (!isFileLoaded)
            {
                MessageBox.Show("Пожалуйста, загрузите файл Excel перед выполнением этой операции.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // создаем экземпляр новой формы
            Comparison formComparison = new Comparison(excelTable);

            // отображаем форму
            formComparison.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // проверяем, загружен ли файл
            if (!isFileLoaded)
            {
                MessageBox.Show("Пожалуйста, загрузите файл Excel перед выполнением этой операции.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // создаем экземпляр новой формы
            Comparison formComparison = new Comparison(excelTable);

            // отображаем форму
            formComparison.Show();
        }
    }
}