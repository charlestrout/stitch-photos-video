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
    }
}
