using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation.Tweens
{
    public interface ITween
    {
        IEnumerable<Frame> Results { get; }
        Graphic graphic { get; }
    }

    public class StaticTween : ITween
    {
        private readonly int Duration;
        public Graphic graphic { get; private set; }

        public StaticTween(Graphic graphic, int duration)
        {
            Duration = duration;
            this.graphic = graphic;
        }

        /// <summary>
        /// Run the tween and calculate the individual frames
        /// </summary>
        public IEnumerable<Frame> Results => Timing.Generate(() => { return new Frame(graphic); }, Timing.FrameCount(Duration));
    }

    public class StyleTween : ITween
    {
        private readonly IEnumerable<GraphicStyle> tween;
        public Graphic graphic { get; private set; }

        public StyleTween(Graphic graphic, int duration, GraphicStyle to, Func<float, float> ease)
        {
            this.graphic = graphic;
            this.tween = Tween(to, duration, ease);
        }

        private IEnumerable<GraphicStyle> Tween(GraphicStyle to, int duration, Func<float, float> ease)
        {
            var x = Timing.Tween(graphic.Style.X, to.X, duration, ease).ToArray();
            var y = Timing.Tween(graphic.Style.Y, to.Y, duration, ease).ToArray();
            var a = Timing.Tween(graphic.Style.Alpha, to.Alpha, duration, ease).ToArray();

            return x.Select((v, i) => new GraphicStyle
            {
                X = (int)v,
                Y = (int)y[i],
                Alpha = (int)a[i],

                Width = graphic.Style.Width,
                Height = graphic.Style.Height,
                Scale = graphic.Style.Scale
            });
        }

        public IEnumerable<Frame> Results => tween.Select(style => {
            var g = this.graphic.Clone();
            g.Style = style;
            return new Frame(g);
        });


    }

}
