using AForge.Video.FFMPEG;
using NDesk.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Utility.Animation;
using Utility.Animation.Tweens;

namespace Utility
{
    class Program
    {
        static void AddFile(Timeline tl, string filename)
        {
            var g1 = Graphic.FromImage(Image.FromFile(filename));
            g1.Style.Scale(1.2f).AlphaTo(0);

            var style1 = GraphicStyle.Copy(g1).MoveTo(-100).AlphaTo(1);
            tl.Add(new StyleTween(g1, 5, style1, Timing.Linear));

            var style2 = GraphicStyle.Copy(g1).MoveTo(-110).AlphaTo(0);
            tl.Add(new StyleTween(g1, 1, style2, Timing.Linear));
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: stitch [OPTIONS]");
            Console.WriteLine("Stitch a series of images together.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        static void Main(string[] args)
        {
            var input = new List<string>();
            var show_help = false;  
            string resolution = "800x600";
            var output = "";
            int bitrate = 1280000;
            int fps = 30;
            VideoCodec codec = VideoCodec.MPEG4;

            var p = new OptionSet() {
                { "i|input=", "image file to add.", v => input.Add (v) },
                { "o|output=", "output filename.", (string v) => output = v },
                { "r|resolution=", "video resolution. default 800x600", (string v) => resolution = v },
                { "b|bitrate=", "bitrate. default 1280000", (string v) => resolution = v },
                { "c|codec=", "codec: MPEG4 MPEG2 H263P", (string v) => VideoCodec.TryParse(v, out codec) },
                { "f|fps",  "frames per second. Default 30", (int v) => fps = v },
                { "h|help",  "show this message and exit", v => show_help = v != null },
            };

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("stitch: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `stitch --help' for more information.");
                return;
            }

            show_help = show_help || input.Count == 0 || string.IsNullOrEmpty(output);

            if (show_help)
            {
                ShowHelp(p);
                return;
            }

            var tl = new Timeline();
            input.ForEach(file => AddFile(tl, file));
            new Video(tl).SaveVideo(output, bitrate, codec, fps);
        }

    }
}
