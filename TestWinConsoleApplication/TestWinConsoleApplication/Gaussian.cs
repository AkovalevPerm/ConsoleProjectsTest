using System;

namespace TestWinConsoleApplication
{
    public static class Gaussian
    {
        private static bool uselast = true;
        private static double next_gaussian;
        private static readonly Random random = new Random();

        private static bool haveNextNextGaussian;
        private static double nextNextGaussian;

        public static double BoxMuller()
        {
            if (uselast)
            {
                uselast = false;
                return next_gaussian;
            }
            double v1, v2, s;
            do
            {
                v1 = 2.0*random.NextDouble() - 1.0;
                v2 = 2.0*random.NextDouble() - 1.0;
                s = v1*v1 + v2*v2;
            } while (s >= 1.0 || s == 0);

            s = Math.Sqrt(-2.0*Math.Log(s)/s);

            next_gaussian = v2*s;
            uselast = true;
            return v1*s;
        }

        public static double BoxMuller(double mean, double standard_deviation)
        {
            return mean + BoxMuller()*standard_deviation;
        }

        public static int Next(int min, int max)
        {
            return (int) BoxMuller(min + (max - min)/2.0, 1.0);
        }

        public static double gaussianInRange(double from, double mean, double to)
        {
            if (!(from < mean && mean < to))
                throw new ArgumentOutOfRangeException();

            var p = Convert.ToInt32(random.NextDouble()*100);
            double retval;
            if (p < mean*Math.Abs(@from - to))
            {
                var interval1 = NextGaussian()*(mean - @from);
                retval = from + (float) interval1;
            }
            else
            {
                var interval2 = NextGaussian()*(to - mean);
                retval = mean + (float) interval2;
            }
            while (retval < from || retval > to)
            {
                if (retval < from)
                    retval = @from - retval + from;
                if (retval > to)
                    retval = to - (retval - to);
            }
            return retval;
        }

        private static double NextGaussian()
        {
            if (haveNextNextGaussian)
            {
                haveNextNextGaussian = false;
                return nextNextGaussian;
            }
            double v1, v2, s;
            do
            {
                v1 = 2*random.NextDouble() - 1;
                v2 = 2*random.NextDouble() - 1;
                s = v1*v1 + v2*v2;
            } while (s >= 1 || s == 0);
            var multiplier = Math.Sqrt(-2*Math.Log(s)/s);
            nextNextGaussian = v2*multiplier;
            haveNextNextGaussian = true;
            return v1*multiplier;
        }
    }
}