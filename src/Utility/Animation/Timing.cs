using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation
{
    public static class AggregateExtension
    {
        public static double[] Cumulate(this IEnumerable<double> query, double seed)
        {
            var list = query.ToList();
            var count = list.Count;
            var result = new double[count];
            var value = seed;

            for (var i = 0; i < count; i++)
            {
                result[i] = value + list[i];
            }

            return result;
        }
    }

    public static class Timing
    {
        public static int FPS = 30;

        public static IEnumerable<T> Generate<T>(Func<T> func, int count)
        {
            var index = 0;
            while (index < count)
            {
                yield return func();
                index++;
            }
        }

        public static int FrameCount(int duration) {
            return duration * FPS;
        }

        public static void Animate(double min, double max, int duration)
        {
            var frameCount = (max - min) / FrameCount(duration);

        }

        public static float Linear(float value)
        {
            return value;
        }

        public static IEnumerable<float> Ease(Func<float,float> func, int duration)
        {
            if (duration <= 0) throw new ArgumentOutOfRangeException("Invalid duration {0}. Duration in seconds must be a positive integer.");

            var max = duration * FPS;
            for (float i = 0; i <= max; i++) yield return func(i / max);
        }

        public static IEnumerable<double> Tween(double min, double max, int duration, Func<float,float> ease)
        {
            //calculate the amount we are changing
            var delta = max - min;

            //return an enumeration that steps from min to max
            return Ease(ease, duration).Select((v, i) => min + (delta * v));
        }

    }
}
