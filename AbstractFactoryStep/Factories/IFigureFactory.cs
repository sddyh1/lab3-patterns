using AbstractFactoryStep.Models;

namespace AbstractFactoryStep.Factories
{
    public interface IFigureFactory
    {
        Circle CreateCircle();
        Square CreateSquare();
        Triangle CreateTriangle();
    }
}