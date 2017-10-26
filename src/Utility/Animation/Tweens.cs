using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility.Animation.Tweens
{
    public interface ITween
    {
        int Id { get; }
        GraphicStyle From { get; set; }
        GraphicStyle To { get; }
        IEnumerable<Frame> Results { get;}
    }

    public class StyleTween : ITween
    {
        public int Id { get; private set; }
        public GraphicStyle From { get; set; }
        public GraphicStyle To { get; set; }

        private readonly Graphic graphic;
        private readonly int duration;
        private readonly Func<float, float> ease;

        public IEnumerable<Frame> Results => Tween().Select(s => new Frame(Graphic.FromGraphic(this.graphic, s)));

        public StyleTween(Graphic graphic, int duration, GraphicStyle to, Func<float, float> ease)
        {
            this.Id = graphic.GetHashCode();
            this.graphic = graphic;
            this.duration = duration;
            this.To = to;
            this.ease = ease;
            this.From = graphic.Style;
        }

        private IEnumerable<GraphicStyle> Tween()
        {
            var x = Timing.Tween(From.X, To.X, duration, ease).ToArray();
            var y = Timing.Tween(From.Y, To.Y, duration, ease).ToArray();
            var a = Timing.Tween(From.Alpha, To.Alpha, duration, ease).ToArray();

            return x.Select((v, i) => new GraphicStyle
            {
                X = (int)v,
                Y = (int)y[i],
                Alpha = (float)Math.Round(a[i], 2),
                Width = From.Width,
                Height = From.Height,
            })
            
            //skip the first one since it's zero and that's were the element already is
            .Skip(1);
        }
    }
}
