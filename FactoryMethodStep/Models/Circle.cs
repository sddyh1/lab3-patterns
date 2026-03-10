using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FactoryMethodStep.Models
{
    public class Circle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
        }
    }
}