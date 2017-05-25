using System;

namespace Physical_Body_Movement__TUTS_Lab1_.Models
{
    public static class Functions
    {
        public static double GainUnitF(double a, double k, double t)
        {
            return -k * Math.Cos(t);
        }

        public static double GainUnitA(double a, double k, double ω)
        {
            return k / ω;
        }

        public static double GainUnitPhi(double a, double k, double ω)
        {
            return 3 * Math.PI / 2;
        }

        public static double AperiodicUnitF(double a, double k, double t)
        {
            return k * a * (Math.Sin(t) - a * Math.Cos(t)) / (1 + a * a) * .5;
        }

        public static double AperiodicUnitA(double a, double k, double ω)
        {
            return k / Math.Sqrt(1 + a * a + ω * ω);
        }

        public static double AperiodicUnitPhi(double a, double k, double ω)
        {
            return Math.Atan(-a * ω);
        }
    }
}
