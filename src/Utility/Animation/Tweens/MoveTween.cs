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

        private Graphic _graphic;

        public MoveTween(Graphic graphic, decimal duration, int x1, int y1, int x2, int y2)
        {
            _graphic = graphic;

            var dx = Timing.EaseLinear(x1, x2, duration);
            var dy = Timing.EaseLinear(y1, y2, duration);
            Deltas = dx.Select((v, i) => new Delta { X = v, Y = dy[i] }).ToList();
        }

        public List<Frame> Results => Deltas.Select(d =>
        {
            var graphic = Graphic.FromImage(_graphic.Image);
            graphic.Position = new Position(d.X, d.Y, _graphic.Image.Width, _graphic.Image.Height);
            return new Frame(graphic);

        }).ToList();
    }
}
