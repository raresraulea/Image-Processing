using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class FreiChenStrategy : Strategy
    {
        public double[,] F1 = new double[3, 3];
        public double[,] F2 = new double[3, 3];
        public double[,] F3 = new double[3, 3];
        public double[,] F4 = new double[3, 3];
        public double[,] F5 = new double[3, 3];
        public double[,] F6 = new double[3, 3];
        public double[,] F7 = new double[3, 3];
        public double[,] F8 = new double[3, 3];
        public double[,] F9 = new double[3, 3];
        public double[,,] matrices = new double[9, 3, 3];

        public FreiChenStrategy()
        {
            this.F1 = new double[3, 3]{
                {1, Math.Sqrt(2), 1 },
                {0, 0, 0 },
                {-1,-Math.Sqrt(2), -1 },
            };
            this.F2 = new double[3, 3]{
                {1, 0, -1 },
                {Math.Sqrt(2), 0, -Math.Sqrt(2) },
                {1,-0, -1 },
            };
            this.F3 = new double[3, 3]{
                {0, -1,Math.Sqrt(2) },
                {1, 0, -1 },
                {-Math.Sqrt(2), 1, 0 },
            };
            this.F4 = new double[3, 3]{
                {Math.Sqrt(2), -1, 0 },
                {-1, 0, 1 },
                {0, 1, -Math.Sqrt(2) },
            };
            this.F5 = new double[3, 3]{
                {0, 1, 0 },
                {-1, 0, -1 },
                {0, 1, 0 },
            };
            this.F6 = new double[3, 3]{
                {-1, 0, 1 },
                {0,0,0 },
                {1, 0, -1 },
            };
            this.F8 = new double[3, 3]{
                {-2, 1, -2},
                {1, 4, 1 },
                {-2, 1, -2 },
            };
            this.F7 = new double[3, 3]{
                {1, -2, 1 },
                {-2, 4, -2 },
                {1, -2, 1 },
            };
            this.F9 = new double[3, 3]{
                {1/9, 1/9, 1/9 },
                {1/9, 1/9, 1/9 },
                {1/9, 1/9, 1/9 },
            };

            this.matrices = new double[9, 3, 3]
            {
               {
                    {1, Math.Sqrt(2), 1 },
                    {0, 0, 0 },
                    {-1,-Math.Sqrt(2), -1 },
                },
               {
                    {1, 0, -1 },
                    {Math.Sqrt(2), 0, -Math.Sqrt(2) },
                    {1,-0, -1 },
                },
               {
                    {0, -1,Math.Sqrt(2) },
                    {1, 0, -1 },
                    {-Math.Sqrt(2), 1, 0 },
                },
               {
                    {Math.Sqrt(2), -1, 0 },
                    {-1, 0, 1 },
                    {0, 1, -Math.Sqrt(2) },
                },
               {
                    {0, 1, 0 },
                    {-1, 0, -1 },
                    {0, 1, 0 },
                },
               {
                    {-1, 0, 1 },
                    {0, 0, 0 },
                    {1, 0, -1 },
                },
               {
                    {1, -2, 1 },
                    {-2, 4, -2 },
                    {1, -2, 1 },
                },
               {
                    {-2, 1, -2},
                    {1, 4, 1 },
                    {-2, 1, -2 },
                },
               {
                    {1.0/9, 1.0/9, 1.0/9 },
                    {1.0/9, 1.0/9, 1.0/9 },
                    {1.0/9, 1.0/9, 1.0/9 },
                }
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
                    double[] Rs = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    double[] Gs = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    double[] Bs = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c - 1; col <= c + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            for (int i = 0; i < 9; i++)
                            {
                                Rs[i] = Rs[i] + color.R * matrices[i, row - r + 1, col - c + 1];
                                Gs[i] = Gs[i] + color.G * matrices[i, row - r + 1, col - c + 1];
                                Bs[i] = Bs[i] + color.B * matrices[i, row - r + 1, col - c + 1];
                            }

                        }
                    }

                    double sumR = 0;
                    double sumG = 0;
                    double sumB = 0;

                    double sumR9 = 0;
                    double sumG9 = 0;
                    double sumB9 = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        sumR += Rs[i] * Rs[i];
                        sumG += Gs[i] * Gs[i];
                        sumB += Bs[i] * Bs[i];
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        sumR9 += Rs[i] * Rs[i];
                        sumG9 += Gs[i] * Gs[i];
                        sumB9 += Bs[i] * Bs[i];
                    }

                    double finalSumR = Math.Sqrt(sumR / sumR9) * 255;
                    double finalSumG = Math.Sqrt(sumG / sumG9) * 255;
                    double finalSumB = Math.Sqrt(sumB / sumB9) * 255;

                    finalSumR = getNormalizedValue(finalSumR);
                    finalSumG = getNormalizedValue(finalSumG);
                    finalSumB = getNormalizedValue(finalSumB);

                    color = Color.FromArgb((byte)finalSumR, (byte)finalSumG, (byte)finalSumB);
                    workImage2.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            workImage2.Unlock();
            return workImage2.GetBitMap();

        }
    }
}
