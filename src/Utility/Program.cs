using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //g1.Position = new Position(-100,-100, image1.Width, image1.Height);
            //g1.Offset = new Position(50, 50, 100, 100);
            //tl.Add(new StaticTween(g1, 0.5M));
            //tl.Add(new StaticTween(Graphic.FromImage(image2), 0.5M));
            tl.Add(new MoveTween(g1, 1, -100, -100, 0, 0));
            
            var video = new Video(tl);

            video.SaveVideo("output\\test.avi");
            video.SaveFrames("output\\frame{0}.jpg");
        }
    }
}
