using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class FTJStrategy : Strategy
    {
        public int n;
        public int[,] H = new int[3,3];

        public FTJStrategy(int n)
        {
            this.n = n;
            this.H = new int[3, 3]{
                {1, n, 1 },
                {n, n*n, n },
                {1, n, 1 },
            };
        }

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            workImage.Lock();

            for (int r = 1; r <= workImage.Width - 2; r++)
            {
                for (int c = 1; c <= workImage.Height - 2; c++)
                {
                    double sR = 0;
                    double sG = 0;
                    double sB = 0;
                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c -1; col <= c + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            sR = sR + color.R * this.H[row - r + 1, col - c + 1];
                            sG = sG + color.G * this.H[row - r + 1, col - c + 1];
                            sB = sB + color.B * this.H[row - r + 1, col - c + 1];

                        }
                    }
                    sR = sR / ((n + 2) * (n + 2));
                    sG = sG / ((n + 2) * (n + 2));
                    sB = sB / ((n + 2) * (n + 2));
                    color = Color.FromArgb((byte)sR, (byte)sG, (byte)sB);
                    workImage.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
