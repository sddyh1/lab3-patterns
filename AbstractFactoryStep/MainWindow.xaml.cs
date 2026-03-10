using System.Windows;
using System.Windows.Controls;
using AbstractFactoryStep.Factories;
using AbstractFactoryStep.Models;

namespace AbstractFactoryStep
{
    public partial class MainWindow : Window
    {
        // Ссылка на абстрактную фабрику (инициализируется в конструкторе или при выборе цвета)
        private IFigureFactory _currentFactory = null!;

        public MainWindow()
        {
            InitializeComponent();
            // Устанавливаем начальную фабрику (красную)
            UpdateFactoryBasedOnColor("Красный");
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string colorName = selectedItem.Content.ToString();
                UpdateFactoryBasedOnColor(colorName);
                // Очищаем панель фигур, если она уже проинициализирована
                FiguresPanel?.Children.Clear();
            }
        }

        private void UpdateFactoryBasedOnColor(string colorName)
        {
            switch (colorName)
            {
                case "Красный":
                    _currentFactory = new RedFactory();
                    break;
                case "Синий":
                    _currentFactory = new BlueFactory();
                    break;
                case "Зелёный":
                    _currentFactory = new GreenFactory();
                    break;
                default:
                    _currentFactory = new RedFactory(); // или null, но тогда нужны доп. проверки
                    break;
            }
        }

        private void BtnCircle_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFactory == null) return;
            var circle = _currentFactory.CreateCircle();
            FiguresPanel?.Children.Add(circle.CreateUIElement());
        }

        private void BtnSquare_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFactory == null) return;
            var square = _currentFactory.CreateSquare();
            FiguresPanel?.Children.Add(square.CreateUIElement());
        }

        private void BtnTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFactory == null) return;
            var triangle = _currentFactory.CreateTriangle();
            FiguresPanel?.Children.Add(triangle.CreateUIElement());
        }
    }
}