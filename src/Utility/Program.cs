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
            var tl = new Timeline();

            var g1 = Graphic.FromImage(Image.FromFile("orig-1.jpg"));
            g1.Style.Scale(1.2f);

            var style1 = GraphicStyle.Copy(g1).MoveTo(-100);
            tl.Add(new StyleTween(g1, 5, style1, Timing.Linear));

            var style2 = GraphicStyle.Copy(g1).MoveTo(-110).AlphaTo(0);
            tl.Add(new StyleTween(g1, 1, style2, Timing.Linear));


            var g2 = Graphic.FromImage(Image.FromFile("orig-2.jpg"));
            g2.Style.Scale(1.2f).MoveTo(-120).AlphaTo(0);

            var style3 = GraphicStyle.Copy(g2).MoveTo(-20).AlphaTo(1);
            tl.Add(new StyleTween(g2, 5, style3, Timing.Linear));

            var style4 = GraphicStyle.Copy(g2).MoveTo(0).AlphaTo(0);
            tl.Add(new StyleTween(g2, 1, style4, Timing.Linear));


            var video = new Video(tl);
            video.SaveVideo("output\\test.avi");
            //video.SaveFrames("output\\frame{0}.jpg");
        }
        
    }
}
