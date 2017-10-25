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
        public float Alpha { get; set; }
        public Position Position { get; set; }
        public Position Offset { get; set; }

        public static Graphic FromImage(Image image, int layer = 0, float alpha = 1f)
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
