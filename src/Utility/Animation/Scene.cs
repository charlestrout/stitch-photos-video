using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Animation;
using Utility.Animation.Factory;
using Utility.Animation.Render;
using Utility.Animation.Tweens;

namespace Utility
{
    public class Scene
    {
        public void Setup()
        {
            var image1 = Image.FromFile("orig-1.jpg");

            var tl = new Timeline();
            tl.Add(new StaticTween(GraphicFactory.Create(image1), 10));

            var video = new Video(tl);
            video.Save("test1.avi");
        }
    }
}
