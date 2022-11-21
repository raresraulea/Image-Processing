using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class FTSStrategy : Strategy
    {

        public int[,] H = new int[3, 3];

        public FTSStrategy()
        {
            this.H = new int[3, 3]{
                {0, -1, 0 },
                {-1, 5, -1 },
                {0, -1, 0 },
            };
        }

        private int getCheckedValue(int value, int delta)
        {

            if (value + delta > 255) return 255;

            if (value + delta < 0) return 0;

            return value + delta;
        }

        private double getNormalizedValue(double value)
        {

            if (value > 255) return 255;

            if (value < 0) return 0;

            return value;
        }

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var image2 = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            var workImage2 = new FastImage(image2);
            workImage.Lock();
            workImage2.Lock();

            for (int r = 1; r <= workImage.Width - 2; r++)
            {
                for (int c = 1; c <= workImage.Height - 2; c++)
                {
                    double sR = 0;
                    double sG = 0;
                    double sB = 0;
                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c - 1; col <= c + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            sR = sR + color.R * this.H[row - r + 1, col - c + 1];
                            sG = sG + color.G * this.H[row - r + 1, col - c + 1];
                            sB = sB + color.B * this.H[row - r + 1, col - c + 1];
                        }
                    }
                    sR = getNormalizedValue(sR);
                    sG = getNormalizedValue(sG);
                    sB = getNormalizedValue(sB);

                    color = Color.FromArgb((byte)sR, (byte)sG, (byte)sB);
                    workImage2.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            workImage2.Unlock();
            return workImage2.GetBitMap();

        }
    }
}
