using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class PrewittStrategy : Strategy
    {
        public int[,] P = new int[3, 3];
        public int[,] Q = new int[3, 3];

        public PrewittStrategy()
        {
            this.Q = new int[3, 3]{
                {-1, 0, 1 },
                {-1, 0, 1 },
                {-1, 0, 1 },
            };
            this.P = new int[3, 3]{
                {-1, -1, -1 },
                {0, 0, 0 },
                {1, 1, 1 },
            };
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
            var workImage = new FastImage(image);

            var image2 = new Bitmap(workImagePath);
            var workImage2 = new FastImage(image2);
            workImage.Lock();
            workImage2.Lock();

            for (int r = 1; r <= workImage.Width - 2; r++)
            {
                for (int c = 1; c <= workImage.Height - 2; c++)
                {
                    double sR1 = 0;
                    double sG1 = 0;
                    double sB1 = 0;

                    double sR2 = 0;
                    double sG2 = 0;
                    double sB2 = 0;

                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c -1; col <= c + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            sR1 = sR1 + color.R * this.P[row - r + 1, col - c + 1];
                            sG1 = sG1 + color.G * this.P[row - r + 1, col - c + 1];
                            sB1 = sB1 + color.B * this.P[row - r + 1, col - c + 1];

                            sR2= sR2+ color.R * this.Q[row - r + 1, col - c + 1];
                            sG2= sG2+ color.G * this.Q[row - r + 1, col - c + 1];
                            sB2= sB2+ color.B * this.Q[row - r + 1, col - c + 1];

                        }
                    }

                    double sR = Math.Sqrt((sR1 + sR1) * (sR2 + sR2));
                    double sG = Math.Sqrt((sG1 + sG1) * (sG2 + sG2));
                    double sB = Math.Sqrt((sB1 + sB1) * (sB2 + sB2));

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
