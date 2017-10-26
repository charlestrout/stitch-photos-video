using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Animation
{
    public static class IO
    {
        public static void SaveVideo(this Video video, string filename)
        {
            VideoFileWriter writer = new VideoFileWriter();
            writer.Open(filename, video.Width, video.Height, 30, VideoCodec.H263P);
            video.RenderedFrames.ForEach(writer.WriteVideoFrame);
            writer.Close();
        }

        public static void SaveFrames(this Video video, string pattern)
        {
            var frames = video.RenderedFrames;
            for (var index = 0; index < frames.Count; index++)
                frames[index].Save(string.Format(pattern, index));
        }
    }
}
