using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation.Factory
{
    public static class GraphicFactory
    {
        public static Graphic Create(Image image, int layer = 0, float alpha = 1f)
        {
            var width = image.Width;
            var height = image.Height;

            var result = new Graphic
            {
                Layer = layer,
                Image = image,
                Alpha = alpha,
                Position = new Position(0, 0, width, height),
                Offset = new Position(0, 0, width, height)
            };

            return result;
        }
    }
}
