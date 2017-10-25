using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Animation;

namespace Utility.Animation.Render
{
    public static class GraphicRenderer
    {
        public static void DrawGraphicFrame(this Graphics result, Graphic graphic)
        {
            var attr = new ImageAttributes();
            attr.SetColorMatrix(new ColorMatrix { Matrix33 = graphic.Alpha });

            result.DrawImage(graphic.Image,
                graphic.Position.AsRectangle,
                graphic.Offset.X, graphic.Offset.Y, graphic.Offset.Width, graphic.Offset.Height,
                GraphicsUnit.Pixel, attr);
        }
    }
}
