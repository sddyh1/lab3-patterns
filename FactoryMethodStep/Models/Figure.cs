using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FactoryMethodStep.Models
{
    public abstract class Figure
    {
        public Color Color { get; set; }

        public abstract UIElement CreateUIElement(double size = 50);
    }
}