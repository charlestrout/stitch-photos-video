using System.Drawing;

namespace Utility.Animation
{

    /// <summary>
    /// A graphic element to be drawn onto a frame
    /// </summary>
    public class Graphic
    {
        public Image Image { get; set; }
        public GraphicStyle Style { get; set; }


        public static Graphic FromImage(Image image, GraphicStyle style)
        {
            return new Graphic { Image = image, Style = style };
        }

        public static Graphic FromImage(Image image)
        {
            return FromImage(image, GraphicStyle.Default(image.Width, image.Height));
        }

        public static Graphic FromGraphic(Graphic graphic)
        {
            return FromImage(graphic.Image, graphic.Style);
        }

        public static Graphic FromGraphic(Graphic graphic, GraphicStyle style)
        {
            return FromImage(graphic.Image, style);
        }

    }
}
