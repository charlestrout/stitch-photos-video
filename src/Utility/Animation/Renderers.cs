using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation
{
    public static class Renderer
    {
        public static void Render(this Graphics result, Graphic graphic)
        {
            var attr = new ImageAttributes();
            attr.SetColorMatrix(
                new ColorMatrix { Matrix33 = (float)graphic.Style.Alpha },
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            result.FillRectangle(Brushes.Black, new Rectangle(0, 0, graphic.Style.Width, graphic.Style.Height));

            result.DrawImage(graphic.Image,
                graphic.Style.AsRectangle,
                0,0,graphic.Image.Width, graphic.Image.Height, //draw entire image
                GraphicsUnit.Pixel, attr);
        }

        public static Bitmap Render(this Frame frame, int width, int height)
        {
            var result = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(result))
            {
                frame.Graphics.ForEach(graphics.Render);
            }
            return result;
        }

        public static List<Bitmap> Render(this Video video)
        {
            var results = video.Timeline.Tweens.SelectMany(tween =>
            {
                var frames = tween.Results.ToArray();
                

                return tween.Styles.Select((style, index) =>
               {
                   return new
                   {
                       Style = style,
                       Frame = frames[index]
                   };
               });
            });

            return results.Select(r => r.Frame.Render(video.Width, video.Height)).ToList();

        }
    }
}
