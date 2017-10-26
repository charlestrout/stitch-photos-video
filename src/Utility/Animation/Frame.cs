using System.Collections.Generic;

namespace Utility.Animation
{
    /// <summary>
    /// A frame of the animation with a collection of graphics
    /// </summary>
    public class Frame
    {
        public List<Graphic> Graphics { get; set; }

        public Frame(List<Graphic> graphics)
        {
            Graphics = graphics;
        }

        public Frame(Graphic graphic)
        {
            Graphics = new List<Graphic> { graphic };
        }
    }
}
