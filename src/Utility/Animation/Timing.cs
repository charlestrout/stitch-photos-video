using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility.Animation
{
    public static class Timing
    {
        public static int FPS = 30;

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

        public static IEnumerable<float> Tween(float min, float max, int duration, Func<float,float> ease)
        {
            //calculate the amount we are changing
            var delta = max - min;

            //return an enumeration that steps from min to max
            return Ease(ease, duration).Select((v, i) => min + (delta * v));
        }

    }
}
