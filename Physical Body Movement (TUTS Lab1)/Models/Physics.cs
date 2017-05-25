using System;
using System.Collections.Generic;

namespace Physical_Body_Movement__TUTS_Lab1_.Models
{
    public static class Physics
    {
        public static ChartData Calculate(double tu, double tg, double t, double thetaCoefficient, double n, int type)
        {
            double Theta(int i) => thetaCoefficient;

            Func<int, double> func;
            if (type == 0)  // Пропорційно-інтегродиференціальний алгоритм
                func = i => (1 + tg / t) * Theta(i) - (1 - 2 * tg / t + t / tu) * Theta(i - 1) + tg / t * Theta(i - 2);
            else            // Пропорційно-інтегральний алгоритм
                func = i => Theta(i) - (t / tu - 1) * Theta(i - 1);

            var x = new List<double> { 0 };
            var y = new List<double> { func(0) };
            var theta = new List<double> { Theta(0) };
            for (var i = 1; i < n; i++)
            {
                x.Add(i);
                y.Add(y[i - 1] + func(i));
                theta.Add(Theta(i));
            }

            return new ChartData { X = x, Y = y, Theta = theta, IsValid = true };
        }
    }
}