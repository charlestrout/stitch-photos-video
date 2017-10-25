using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Animation.Render;

namespace Utility.Animation
{
    public class Video : IDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Timeline Timeline { get; set; }

        public Video(Timeline timeline)
        {
            Timeline = timeline;
            Width = 800;
            Height = 600;
        }

        private Bitmap RenderFrame(Frame frame)
        {
            var result = new Bitmap(Width, Height);
            using (var graphics = Graphics.FromImage(result))
            {
                frame.Graphics.ForEach(graphics.DrawGraphicFrame);
            }
            return result;
        }

        private void SaveFile(Bitmap file)
        {
            file.Save(string.Format("{0}.jpg", Guid.NewGuid()));
        }

        public void Save(string filename)
        {
            VideoFileWriter writer = new VideoFileWriter();
            writer.Open(filename, Width, Height, 30, VideoCodec.H263P, 4000000);

            Timeline.Frames
                .Select(RenderFrame).ToList()
                .ForEach(writer.WriteVideoFrame);

            writer.Close();
        }
    }
}
