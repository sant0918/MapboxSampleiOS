using System;
using System.Collections.Generic;
using System.Text;

namespace MapboxSampleiOS.Models
{
    public class Distance
    {

        public Meters Meters;
        public Distance(Tuple<double, double> meters)
        {

            Meters.X = meters.Item1;
            Meters.Y = meters.Item2;
        }
    }

    public struct Meters
    {
        public double X;
        public double Y;
    }
}
