using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class ContrastStrategy : Strategy
    {
        public int delta;

        public ContrastStrategy(int delta)
        {
            this.delta = delta;
        }

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            int minR = 255;
            int minG = 255;
            int minB = 255;
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    minR = Math.Min(minR, R);
                    minG = Math.Min(minG, G);
                    minB = Math.Min(minB, B);
                    maxR = Math.Max(maxR, R);
                    maxG = Math.Max(maxG, G);
                    maxB = Math.Max(maxB, B);
                }
            }


            int aR = minR - delta;
            int bR = maxR + delta;
            int aG = minG - delta;
            int bG = maxG + delta;
            int aB = minB - delta;
            int bB = maxB + delta;
            Console.WriteLine(aR + " " + bR);

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    int newR = Math.Min(255, (bR - aR) * (R - minR) / (maxR - minR) + aR);
                    newR = Math.Max(0, newR);
                    int newG = Math.Min(255, (bG - aG)  * (G - minG) / (maxG - minG) + aG);
                    newG = Math.Max(0, newG);
                    int newB = Math.Min(255, (bB - aB) * (B - minB) / (maxB - minB) + aB);
                    newB = Math.Max(0, newB);

                    color = Color.FromArgb((byte)newR, (byte)newG, (byte)newB);

                    workImage.SetPixel(i, j, color);
                }
            }


            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
