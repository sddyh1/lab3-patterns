using FactoryMethodStep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FactoryMethodStep.Creators
{
    public class BlueTriangleCreator : TriangleCreator
    {
        public override Triangle CreateTriangle() => new Triangle { Color = Colors.Blue };
    }
}
