using System;
using System.Collections.Generic;
using System.Text;

namespace Delegetes.Logic
{
    public class Shape
    {
        public double Length { get; set; }

        public static double Perimeter(double length) => length;
    }
}
