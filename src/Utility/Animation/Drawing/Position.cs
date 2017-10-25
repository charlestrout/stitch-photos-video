using System.Drawing;

namespace Utility.Animation
{
    public interface IDimension
    {
        int Width { get; set; }
        int Height { get; set; }
    }


    /// <summary>
    /// The position and size of an element
    /// </summary>
    public class Position : IDimension
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Position(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Return a Rectangle object
        /// </summary>
        public Rectangle AsRectangle
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }
    }
}
