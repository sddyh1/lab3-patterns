using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AbstractFactoryStep.Models
{
    public abstract class Figure
    {
        public Color Color { get; set; }

        // Метод, создающий визуальный элемент для отображения в интерфейсе
        public abstract UIElement CreateUIElement(double size = 50);
    }
}