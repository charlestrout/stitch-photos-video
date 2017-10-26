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
            tl.Add(new AlphaTween(g1, 1, 0, 1));
            tl.Add(new MoveTween(g1, 3, 0,0,-50,-50));
            tl.Add(new AlphaTween(g1, 1, 1, 0));

            var g2 = Graphic.FromImage(image2);
            tl.Add(new AlphaTween(g2, 1, 0, 1));
            tl.Add(new MoveTween(g2, 3, 0, 0, -50, -50));
            tl.Add(new AlphaTween(g2, 1, 1, 0));


            var video = new Video(tl);

            video.SaveVideo("output\\test.avi");
            //video.SaveFrames("output\\frame{0}.jpg");

            Test();
        }


        public static void Test()
        {
            var image1 = Image.FromFile("orig-1.jpg");

            var result = new Bitmap(800,600);

            using (var graphics = Graphics.FromImage(result))
            {
                var attr = new ImageAttributes();
                attr.SetColorMatrix(new ColorMatrix { Matrix33 = 0.5f });

                graphics.DrawImage(image1,
                    new Rectangle(0,0,image1.Width,image1.Height),
                    0,0,image1.Width,image1.Height,
                    GraphicsUnit.Pixel, attr);

            }

            result.Save("dump.jpg");
            

        }
    }
}
