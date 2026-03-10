using System.Windows.Media;
using FactoryMethodStep.Models;

namespace FactoryMethodStep.Creators
{
    public class RedSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Colors.Red };
    }
}