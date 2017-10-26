using System.Drawing;

namespace Utility.Animation
{
    public class GraphicStyle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Alpha { get; set; }
        public double Scale { get; set; }

        public Rectangle AsRectangle => new Rectangle(X, Y, Width, Height);

        public static GraphicStyle Default(int width, int height)
        {
            return new GraphicStyle { X = 0, Y = 0, Alpha = 1, Height = height, Scale = 1, Width = width };
        }

        public GraphicStyle Clone()
        {
            return (GraphicStyle)this.MemberwiseClone();
        }

    }
}
