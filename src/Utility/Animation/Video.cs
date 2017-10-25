using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Utility.Animation
{
    public class Video : IDimension
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
                return _timeline.Tweens.SelectMany(tween => tween.Results.Select(f => f.Render(Width, Height))).ToList();
            }
        }
        
    }
}
