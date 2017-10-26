using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation.Tweens
{
    public class Delta
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class MoveTween : ITween
    {
        private List<Delta> Deltas = new List<Delta>();
        public Graphic Graphic { get; set; }

        public MoveTween(Graphic graphic, int duration, int x1, int y1, int x2, int y2)
        {
            Graphic = graphic;

            var dx = Timing.EaseLinear(x1, x2, duration);
            var dy = Timing.EaseLinear(y1, y2, duration);
            Deltas = dx.Select( (v, i) => new Delta {
                X = (int)v,
                Y = (int)dy[i]
            }).ToList();
        }

        public List<Frame> Results => Deltas.Select(d =>
        {
            var graphic = Graphic.Clone();
            graphic.Position.X = d.X;
            graphic.Position.Y = d.Y;

            return new Frame(graphic);
        }).ToList();
    }
}
