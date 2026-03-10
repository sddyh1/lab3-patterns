using System.Windows.Media;
using AbstractFactoryStep.Models;

namespace AbstractFactoryStep.Factories
{
    public class RedFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Red };
        public Square CreateSquare() => new Square { Color = Colors.Red };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Red };
    }
}