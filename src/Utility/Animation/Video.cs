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

        public Timeline Timeline { get; private set; }

        public Video(Timeline timeline)
        {
            Timeline = timeline;
            Width = 800;
            Height = 600;
        }
    }
}
