using System.Drawing;

namespace Utility.Animation
{
    public class GraphicStyle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Alpha { get; set; }

        public Rectangle AsRectangle => new Rectangle(X, Y, Width, Height);

        public static GraphicStyle Default(int width, int height)
        {
            return new GraphicStyle { X = 0, Y = 0, Alpha = 1, Height = height, Width = width };
        }

        public GraphicStyle AlphaTo(float value)
        {
            this.Alpha = value;
            return this;
        }

        public GraphicStyle Scale(float value)
        {
            Width = (int)(Width * value);
            Height = (int)(Height * value);
            return this;
        }

        public GraphicStyle MoveTo(int? x = null, int? y = null)
        {
            if (x.HasValue) this.X = x.Value;
            if (y.HasValue) this.Y = y.Value;
            return this;
        }

        public static GraphicStyle Copy(Graphic graphic)
        {
            return graphic.Style.Clone();
        }

        public static GraphicStyle Copy(GraphicStyle style)
        {
            return style.Clone();
        }

        private GraphicStyle Clone()
        {
            return (GraphicStyle)this.MemberwiseClone();
        }

    }
}
