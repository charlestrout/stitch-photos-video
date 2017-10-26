using AForge.Video.FFMPEG;
using Utility.Animation;

namespace Utility
{
    public static class IO
    {
        public static void SaveVideo(this Video video, string filename, int bitrate, VideoCodec codec, int fps)
        {
            VideoFileWriter writer = new VideoFileWriter();
            writer.Open(filename, video.Width, video.Height, fps, codec, bitrate);
            video.Render().ForEach(writer.WriteVideoFrame);
            writer.Close();
        }

        public static void SaveFrames(this Video video, string pattern)
        {
            var frames = video.Render();
            for (var index = 0; index < frames.Count; index++)
                frames[index].Save(string.Format(pattern, index));
        }
    }
}
