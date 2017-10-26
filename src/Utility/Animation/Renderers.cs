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
                new ColorMatrix { Matrix33 = (float)graphic.Alpha },
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            result.FillRectangle(Brushes.Black, new Rectangle(0, 0, graphic.Position.Width, graphic.Position.Height));

            result.DrawImage(graphic.Image,
                graphic.Position.AsRectangle,
                graphic.Offset.X, graphic.Offset.Y, graphic.Offset.Width, graphic.Offset.Height,
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
    }
}
