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
        public double Alpha { get; set; }
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
                Position = new Position(0, 0, (int)(width * 1.2), (int)(height * 1.2)),
                Offset = new Position(0, 0, width, height)
            };

            return result;
        }

        public Graphic Clone()
        {
            var result = FromImage(Image);
            result.Position = new Position(this.Position.X, this.Position.Y, this.Position.Width, this.Position.Height);
            return result;
        }
    }
}
