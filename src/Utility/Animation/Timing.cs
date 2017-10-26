using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation
{
    public static class Timing
    {
        public static int FPS = 30;

        public static int FrameCount(int duration)
        {
            return duration * FPS;
        }

        public static double[] EaseLinear(double min, double max, int duration)
        {
            var count = FrameCount(duration);
            var delta = (max - min) / count;

            var results = new Aggregator();
            Enumerable.Range(0, count + 1).Select(_ => delta).Aggregate(min, results.Capture);

            return results.Results.Skip(1).ToArray();
        }
    }

    public class Aggregator
    {
        public List<double> Results = new List<double>();
        public double Capture(double a, double b)
        {
            Results.Add(a);
            return a + b;
        }
    }
}
