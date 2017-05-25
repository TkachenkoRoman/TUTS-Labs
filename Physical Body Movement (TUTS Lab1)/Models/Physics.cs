using System;
using System.Collections.Generic;

namespace Physical_Body_Movement__TUTS_Lab1_.Models
{
    public static class Physics
    {
        public static ChartData Calculate(double a, double k, int type, int funcNumber)
        {
            var x = new List<double>();
            var y = new List<double>();


            Func<double, double, double, double> func;
            if (type == 0) // Ланка підсилення
                switch (funcNumber)
                {
                    case 0: // F(t)
                        func = Functions.GainUnitF;
                        break;
                    case 1: // A(ω)
                        func = Functions.GainUnitA;
                        break;
                    default: // ϕ(ω)
                        func = Functions.GainUnitPhi;
                        break;
                }
            else // Аперіодична ланка
                switch (funcNumber)
                {
                    case 0: // F(t)
                        func = Functions.AperiodicUnitF;
                        break;
                    case 1: // A(ω)
                        func = Functions.AperiodicUnitA;
                        break;
                    default: // ϕ(ω)
                        func = Functions.AperiodicUnitPhi;
                        break;
                }


            for (double xx = 0.1; xx < 2 * Math.PI * 10; xx += .01)
            {
                x.Add(xx);
                y.Add(func(a, k, xx));
            }

            return new ChartData { X = x, Y = y, IsValid = true };
        }
    }
}