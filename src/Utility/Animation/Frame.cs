using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Animation;

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
