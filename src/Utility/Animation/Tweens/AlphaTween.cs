using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation.Tweens
{
    public class AlphaTween : ITween
    {
        public Graphic Graphic { get; set; }
        private double[] _deltas;

        public AlphaTween(Graphic graphic, int duration, int alpha1, int alpha2)
        {
            Graphic = graphic;
            _deltas = Timing.EaseLinear(alpha1, alpha2, duration);
        }

        public List<Frame> Results => _deltas.Select( (d,i) =>
        {
            var g = Graphic.Clone();
            g.Alpha = d;

            return new Frame(g);
        }).ToList();
    }
}
