using System.IO;
using System.Globalization;
namespace Converter
{
    public partial class Form1 : Form
    {
        // Словник для зберігання коефіцієнтів одиниць вимірювання
        Dictionary<string, double> units = new Dictionary<string, double>();

        public Form1()
        {
            InitializeComponent();

            // Заповнюємо категорії при запуску програми
            // Назви мають точно збігатися з назвами файлів txt
            comboBox1.Items.AddRange(new string[] { "length", "mass", "volume" });
        }

        // Подія при зміні категорії (маса, довжина або об'єм)
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Формуємо ім'я файлу на основі вибору
            string fileName = comboBox1.SelectedItem.ToString() + ".txt";
            if (File.Exists(fileName))
            {
                units.Clear();
                comboBox2.Items.Clear(); // Список "З яких одиниць"
                comboBox3.Items.Clear(); // Список "У які одиниці"

                // Читаємо всі рядки з файлу
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        // Використовуємо InvariantCulture, щоб крапка в файлі завжди зчитувалася правильно
                        double value = double.Parse(parts[1], CultureInfo.InvariantCulture);

                        units.Add(name, value);
                        comboBox2.Items.Add(name);
                        comboBox3.Items.Add(name);
                    }
                }

                // Автоматично обираємо перші елементи у списках
                if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;
                if (comboBox3.Items.Count > 0) comboBox3.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Error: File not found! Please check for the existence of..." + fileName, "File Error");
            }
        }

        // Подія при натисканні на кнопку розрахунку
        private void button1_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи ввів користувач число
            if (double.TryParse(textBox1.Text, out double inputVal))
            {
                // Перевіряємо, чи обрані одиниці вимірювання
                if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                {
                    double fromCoeff = units[comboBox2.SelectedItem.ToString()];
                    double toCoeff = units[comboBox3.SelectedItem.ToString()];

                    // Основна формула конвертації
                    double result = (inputVal * fromCoeff) / toCoeff;

                    // Виведення результату в лейбл (4 знаки після коми)
                    label1.Text = result.ToString("F4");
                }
                else
                {
                    MessageBox.Show("Please select the units of measurement!", "Warning");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric value!", "Input Error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
