using System;
using System.Collections.Generic;
using System.Text;

namespace Delegetes.Logic
{
    public class Square : Shape
    {
        public static new double Perimeter(double length) => 4 * length;
    }
}
