using System;
using System.Collections.Generic;
using System.Text;

namespace Delegetes.Logic
{
    public class Circle : Shape
    {
        public static new double Perimeter(double length) => length;
    }
}
