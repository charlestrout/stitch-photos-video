using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Animation;
using Utility.Animation.Factory;
using Utility.Animation.Render;

namespace Utility
{
    public class Scene
    {
        public void Setup()
        {
            var image1 = Image.FromFile("orig-1.jpg");

            var tl = new Timeline();
            for(var i = 0; i <= 60; i++)
                tl.Add(GraphicFactory.Create(image1), i);

            var video = new Video(tl);
            video.Save("test1.avi");
        }
    }
}
