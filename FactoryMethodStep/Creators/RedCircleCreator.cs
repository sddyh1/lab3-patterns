using System.Windows.Media;
using FactoryMethodStep.Models;

namespace FactoryMethodStep.Creators
{
    public class RedCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Colors.Red };
    }
}