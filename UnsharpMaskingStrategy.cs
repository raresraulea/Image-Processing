using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    public class UnsharpMaskingStrategy : Strategy
    {
        public int n;
        public double c1 = 0.6;
        public int[,] H = new int[3,3];

        public UnsharpMaskingStrategy(int n = 2)
        {
            this.n = n;
            this.H = new int[3, 3]{
                {1, n, 1 },
                {n, n*n, n },
                {1, n, 1 },
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

            int R, G, B;

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
                            R = color.R;
                            G = color.G;
                            B = color.B;
                            sR = sR + R * this.H[row - r + 1, col - c + 1];
                            sG = sG + G * this.H[row - r + 1, col - c + 1];
                            sB = sB + B * this.H[row - r + 1, col - c + 1];
                        }
                    }
                    sR = sR / ((n + 2) * (n + 2));
                    sG = sG / ((n + 2) * (n + 2));
                    sB = sB / ((n + 2) * (n + 2));

                    color = workImage.GetPixel(r, c);
                    R = color.R;
                    G = color.G;
                    B = color.B;

                    double GR = c1 / (2 * c1 - 1) * R - (1 - c1) / (2 * c1 - 1) * sR;
                    double GG = c1 / (2 * c1 - 1) * G - (1 - c1) / (2 * c1 - 1) * sG;
                    double GB = c1 / (2 * c1 - 1) * B - (1 - c1) / (2 * c1 - 1) * sB;

                    GR = getNormalizedValue(GR);
                    GG = getNormalizedValue(GG);
                    GB = getNormalizedValue(GB);

                    color = Color.FromArgb((int)GR, (int)GG, (int)GB);
                    workImage2.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            workImage2.Unlock();

            return workImage2.GetBitMap();
            
        }
    }
}
