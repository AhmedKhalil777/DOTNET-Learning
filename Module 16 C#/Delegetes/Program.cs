using Delegetes.Logic;
using System;

namespace Delegetes
{
    class Program
    {
        public delegate double CalcPremiter();
        static void Main(string[] args)
        {
            CalcPremiter circleCalc = Circle.Perimeter(3);
          
        }
    }

}
