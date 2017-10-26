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
        IEnumerable<GraphicStyle> Styles { get; }
    }

    public class StyleTween : ITween
    {
        public IEnumerable<Frame> Results { get; private set; }
        public IEnumerable<GraphicStyle> Styles { get; private set; }

        public StyleTween(Graphic graphic, int duration, GraphicStyle to, Func<float, float> ease)
        {
            Styles = Tween(graphic, to, duration, ease);
            Results = Styles.Select(style => new Frame(graphic.Copy(style)));
        }

        private IEnumerable<GraphicStyle> Tween(Graphic graphic, GraphicStyle to, int duration, Func<float, float> ease)
        {
            var x = Timing.Tween(graphic.Style.X, to.X, duration, ease).ToArray();
            var y = Timing.Tween(graphic.Style.Y, to.Y, duration, ease).ToArray();
            var a = Timing.Tween(graphic.Style.Alpha, to.Alpha, duration, ease).ToArray();

            return x.Select((v, i) => new GraphicStyle
            {
                X = (int)v,
                Y = (int)y[i],
                Alpha = Math.Round(a[i],2),

                Width = graphic.Style.Width,
                Height = graphic.Style.Height,
            });
        }
    }
}
