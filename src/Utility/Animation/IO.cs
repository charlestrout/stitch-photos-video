using AForge.Video.FFMPEG;

namespace Utility.Animation
{
    public static class IO
    {
        public static void SaveVideo(this Video video, string filename)
        {
            VideoFileWriter writer = new VideoFileWriter();
            writer.Open(filename, video.Width, video.Height, 30, VideoCodec.H263P, 1280000);
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
