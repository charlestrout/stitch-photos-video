using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation.Tweens
{
    public interface ITween
    {
        List<Frame> Run();
    }

    public class StaticTween : ITween 
    {
        private readonly int Duration;
        private readonly Graphic Graphic;
        public StaticTween(Graphic graphic, int duration)
        {
            Duration = duration;
            Graphic = graphic;
        }

        /// <summary>
        /// Returns a series of frames of the static graphic
        /// </summary>
        /// <returns></returns>
        public List<Frame> Run()
        {
            return Enumerable.Range(0, Duration * 30).Select(_ => new Frame(Graphic)).ToList();
        }
    }
}
