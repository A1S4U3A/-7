using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace пр7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Конструктор класса MainWindow
        // Вызывается при создании нового окна
        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов интерфейса
        }

        // Метод для запуска решения задачи
        private void StartButton_Click(object sender, RoutedEventArgs e)// Срабатывает при нажатии кнопки "Запустить"
        {
            ResultTextBlock.Text = ""; // Очистить предыдущие результаты для нового запуска

            if (int.TryParse(DisksInput.Text, out int diskCount) && diskCount > 0)// Проверка, что вводимое значение является числом и больше 0
            {
                // Запустить рекурсивный алгоритм и отобразить результат
                SolveHanoi(diskCount, 'A', 'C', 'B');// A - источник, C - целевой, B - вспомогательный
            }
            else
            {
                MessageBox.Show("Введите корректное количество дисков!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);// Если ввод неверный, показать сообщение об ошибке
            }
        }

        private void SolveHanoi(int n, char source, char target, char auxiliary)// Рекурсивный метод для решения задачи Ха-нойской башни
        {
            if (n == 1)// Базовый случай: если n == 1, просто переместите диск
            {
                // Вывод информации о перемещении первого диска с источника на цель
                ResultTextBlock.Text += $"Переместите диск 1 с {source} на {target}\n"; // Вывод результата
                return; // Завершить выполнение функции
            }

            // Рекурсивный шаг 1: переместить n-1 дисков с source на auxiliary
            // Это делается с использованием целевого стержня как вспомогательного
            SolveHanoi(n - 1, source, auxiliary, target);

            // Перемещение n-го диска на целевой стержень
            // Вывод информации о перемещении n-го диска
            ResultTextBlock.Text += $"Переместите диск {n} с {source} на {target}\n"; // Вывод результата

            // Рекурсивный шаг 2: переместить n-1 дисков с auxiliary на target
            // Теперь целевой стержень является местом, куда нужно переместить диски
            SolveHanoi(n - 1, auxiliary, target, source);
        }
    }
}
