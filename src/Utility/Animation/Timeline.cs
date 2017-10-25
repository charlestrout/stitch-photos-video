using System.Collections.Generic;
using System.Linq;
using Utility.Animation.Tweens;

namespace Utility.Animation
{
    public class Timeline
    {
        private SortedList<int, ITween> _tweens;

        public List<ITween> Tweens
        {
            get
            {
                return _tweens.OrderBy(k => k.Key).Select(v => v.Value).ToList();
            }
        }
        public int Layer { get; set; }

        private int Index = 0;

        public Timeline()
        {
            _tweens = new SortedList<int, ITween>();
            Layer = 0;
        }

        public void Add(ITween tween)
        {
            _tweens.Add(Index, tween);
            Index++;
        }
    }
}
