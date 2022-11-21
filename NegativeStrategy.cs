using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class NegativeStrategy : Strategy
    {
        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    color = Color.FromArgb(255 - R, 255 - G, 255 - B);

                    workImage.SetPixel(i, j, color);
                }
            }

            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
