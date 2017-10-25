using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation.Tweens
{
    public interface ITween
    {
        List<Frame> Results { get; }
    }

    public class StaticTween : ITween
    {
        private readonly decimal Duration;
        private readonly Graphic Graphic;
        public StaticTween(Graphic graphic, decimal duration)
        {
            Duration = duration;
            Graphic = graphic;
        }

        /// <summary>
        /// Run the tween and calculate the individual frames
        /// </summary>
        public List<Frame> Results => Enumerable.Range(0, Timing.FrameCount(Duration)).Select(_ => new Frame(Graphic)).ToList();
    }
}
