using FactoryMethodStep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FactoryMethodStep.Creators
{
    public class GreenSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Colors.Green };

    }
}
