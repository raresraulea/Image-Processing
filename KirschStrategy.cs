using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class KirschStrategy : Strategy
    {
        public int[,] H1 = new int[3,3];
        public int[,] H2 = new int[3,3];
        public int[,] H3 = new int[3,3];
        public int[,] H4 = new int[3,3];

        public KirschStrategy()
        {
            this.H1 = new int[3, 3]{
                {-1, 0, 1 },
                {-1, 0, 1 },
                {-1, 0, 1 },
            };
            this.H2 = new int[3, 3]{
                {1, 1, 1 },
                {0, 0, 0 },
                {-1, -1, -1 },
            };
            this.H3 = new int[3, 3]{
                {0, 1, 1 },
                {-1, 0, 1 },
                {-1, -1, 0 },
            };
            this.H4 = new int[3, 3]{
                {1, 1, 0 },
                {1, 0, -1 },
                {0, -1, -1 },
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

                    double sR3 = 0;
                    double sG3 = 0;
                    double sB3 = 0;

                    double sR4 = 0;
                    double sG4 = 0;
                    double sB4 = 0;

                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c -1; col <= c + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            sR1 = sR1 + color.R * this.H1[row - r + 1, col - c + 1];
                            sG1 = sG1 + color.G * this.H1[row - r + 1, col - c + 1];
                            sB1 = sB1 + color.B * this.H1[row - r + 1, col - c + 1];

                            sR2= sR2+ color.R * this.H2[row - r + 1, col - c + 1];
                            sG2= sG2+ color.G * this.H2[row - r + 1, col - c + 1];
                            sB2= sB2+ color.B * this.H2[row - r + 1, col - c + 1];

                            sR3= sR3+ color.R * this.H3[row - r + 1, col - c + 1];
                            sG3= sG3+ color.G * this.H3[row - r + 1, col - c + 1];
                            sB3= sB3+ color.B * this.H3[row - r + 1, col - c + 1];

                            sR4= sR4+ color.R * this.H4[row - r + 1, col - c + 1];
                            sG4= sG4+ color.G * this.H4[row - r + 1, col - c + 1];
                            sB4= sB4+ color.B * this.H4[row - r + 1, col - c + 1];

                        }
                    }

                    double[] potentialMaxArrayR = { sR1, sR2, sR3, sR4 };
                    double[] potentialMaxArrayG = { sG1, sG2, sG3, sG4 };
                    double[] potentialMaxArrayB = { sB1, sB2, sB3, sB4 };

                    double maxR = sR1;
                    double maxG = sG1;
                    double maxB = sB1;

                    for(int i = 0; i < 4; i++)
                    {
                        maxR = Math.Max(maxR, potentialMaxArrayR[i]);
                        maxG = Math.Max(maxG, potentialMaxArrayG[i]);
                        maxB = Math.Max(maxB, potentialMaxArrayB[i]);
                    }

                    maxR = getNormalizedValue(maxR);
                    maxG = getNormalizedValue(maxG);
                    maxB = getNormalizedValue(maxB);

                    color = Color.FromArgb((byte)maxR, (byte)maxG, (byte)maxB);
                    workImage2.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            workImage2.Unlock();
            return workImage2.GetBitMap();
            
        }
    }
}
