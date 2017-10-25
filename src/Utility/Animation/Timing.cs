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

        public static int FrameCount(decimal duration)
        {
            return (int)(duration * FPS);
        }

        public static int[] EaseLinear(int min, int max, decimal duration)
        {
            var count = FrameCount(duration);
            var delta = (max - min) / count;

            var results = new Aggregator();
            Enumerable.Range(0, count).Select(_ => delta).Aggregate(min, results.Capture);

            return results.Results.ToArray();
        }
    }

    public class Aggregator
    {
        public List<int> Results = new List<int>();
        public int Capture(int a, int b)
        {
            Results.Add(a);
            return a + b;
        }
    }
}
