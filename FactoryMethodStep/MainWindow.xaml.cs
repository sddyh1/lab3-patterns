using System.Windows;
using System.Windows.Controls;
using FactoryMethodStep.Creators;
using FactoryMethodStep.Models;

namespace FactoryMethodStep
{
    public partial class MainWindow : Window
    {
        private CircleCreator _currentCircleCreator;
        private SquareCreator _currentSquareCreator;
        private TriangleCreator _currentTriangleCreator;

        public MainWindow()
        {
            InitializeComponent();
            UpdateCreatorsBasedOnColor("Красный");
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string colorName = selectedItem.Content.ToString();
                UpdateCreatorsBasedOnColor(colorName);
                // Проверяем, что FiguresPanel уже создан (инициализирован)
                if (FiguresPanel != null)
                {
                    FiguresPanel.Children.Clear();
                }
            }
        }

        private void UpdateCreatorsBasedOnColor(string colorName)
        {
            switch (colorName)
            {
                case "Красный":
                    _currentCircleCreator = new RedCircleCreator();
                    _currentSquareCreator = new RedSquareCreator();
                    _currentTriangleCreator = new RedTriangleCreator();
                    break;
                case "Синий":
                    _currentCircleCreator = new BlueCircleCreator();
                    _currentSquareCreator = new BlueSquareCreator();
                    _currentTriangleCreator = new BlueTriangleCreator();
                    break;
                case "Зелёный":
                    _currentCircleCreator = new GreenCircleCreator();
                    _currentSquareCreator = new GreenSquareCreator();
                    _currentTriangleCreator = new GreenTriangleCreator();
                    break;
                default:
                    _currentCircleCreator = null;
                    _currentSquareCreator = null;
                    _currentTriangleCreator = null;
                    break;
            }
        }

        private void BtnCircle_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCircleCreator == null) return;
            var circle = _currentCircleCreator.CreateCircle();
            FiguresPanel.Children.Add(circle.CreateUIElement());
        }

        private void BtnSquare_Click(object sender, RoutedEventArgs e)
        {
            if (_currentSquareCreator == null) return;
            var square = _currentSquareCreator.CreateSquare();
            FiguresPanel.Children.Add(square.CreateUIElement());
        }

        private void BtnTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTriangleCreator == null) return;
            var triangle = _currentTriangleCreator.CreateTriangle();
            FiguresPanel.Children.Add(triangle.CreateUIElement());
        }
    }
}