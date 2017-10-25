using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Animation.Factory;

namespace Utility.Animation
{
    public class Timeline
    {
        private SortedList<int, Frame> frames { get; set; }
        public int Layer { get; set; }

        public Timeline()
        {
            frames = new SortedList<int,Frame>();
            Layer = 0;
        }

        public List<Frame> Frames
        {
            get
            {
                return frames.OrderBy(k => k.Key).Select(v => v.Value).ToList();
            }
        }

        public Frame GetFrame(int index) 
        {
            frames.TryGetValue(index, out Frame result);
            return result;
        }

        public void Add(Graphic graphic, int index)
        {
            frames.Add(index, new Frame(graphic));
        }
    }
}
