using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Utility.Animation
{
    public class Video
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly Timeline _timeline;

        public Video(Timeline timeline)
        {
            _timeline = timeline;
            Width = 800;
            Height = 600;
        }

        public List<Bitmap> RenderedFrames
        {
            get
            {
                var pos = new Dictionary<int, GraphicStyle>();


                var x = _timeline.Tweens.SelectMany(tween =>
                {
                    var hash = tween.graphic.GetHashCode();

                    if (pos.ContainsKey(hash))
                    {
                        var p = pos[tween.graphic.GetHashCode()];

                        tween.graphic.Style = p;
                    }

                    var tweenResults = tween.Results;
                    pos[hash] = tweenResults.LastOrDefault().Graphics.FirstOrDefault().Style;

                    return tweenResults.Select(f => f.Render(Width, Height)).ToList();

                });

                return x.ToList();

                //return _timeline.Tweens.SelectMany(tween => tween.Results.Select(f => f.Render(Width, Height))).ToList();
            }
        }
        
    }
}
