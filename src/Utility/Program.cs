using System.Drawing;
using System.Drawing.Imaging;
using Utility.Animation;
using Utility.Animation.Tweens;

namespace Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            var image1 = Image.FromFile("orig-1.jpg");
            var image2 = Image.FromFile("orig-2.jpg");

            var tl = new Timeline();

            var g1 = Graphic.FromImage(image1);
            g1.Style.Scale(1.2f);

            var style1 = g1.Style.Clone();
            style1.X -= 100;
            style1.Y -= 100;

            tl.Add(new StyleTween(g1, 2, style1, Timing.Linear));

            g1.Style = style1;
            var style2 = style1.Clone();
            style2.Alpha = 0;

            tl.Add(new StyleTween(g1, 2, style2, Timing.Linear));

            var video = new Video(tl);
            video.SaveVideo("output\\test.avi");
            //video.SaveFrames("output\\frame{0}.jpg");
        }
        
    }
}
