using System.Drawing;

namespace Utility.Animation
{

    /// <summary>
    /// A graphic element to be drawn onto a frame
    /// </summary>
    public class Graphic
    {
        public int Layer { get; set; }
        public Image Image { get; set; }
        public GraphicStyle Style { get; set; }

        public static Graphic FromImage(Image image, int layer = 0)
        {
            return new Graphic
            {
                Layer = layer,
                Image = image,
                Style = GraphicStyle.Default(image.Width, image.Height)
            };
        }

        public Graphic Copy(GraphicStyle style = null)
        {
            var result = FromImage(Image);
            result.Style = style != null ? style : result.Style.Clone();
            return result;
        }
    }
}
