using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class EgalizareStrategy : Strategy
    {
        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            workImage.Lock();

            int[] hist = new int[256];
            int[] histc = new int[256];
            int[] transf = new int[256];

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    int average = (R + G + B) / 3;
                    hist[average] = hist[average] + 1;
                }
            }

            histc[0] = hist[0];

            for (int i = 1; i < 255; i++) {
                histc[i] = histc[i - 1] + hist[i];
            }

            for (int i = 1; i < 255; i++)
            {
                transf[i] = (histc[i] * 255) / (workImage.Width * workImage.Height);
            }

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte average = (byte)((R + G + B) / 3);

                    color = Color.FromArgb(transf[average], transf[average], transf[average]);

                    workImage.SetPixel(i, j, color);
                }
            }


            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
