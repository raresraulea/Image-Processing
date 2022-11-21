using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class GaborStrategy : Strategy
    {
        public int[,] P = new int[3, 3];
        public int[,] Q = new int[3, 3];

        double sigma = 0.66;
        double omega = 1.5;

        public GaborStrategy()
        {
            this.Q = new int[3, 3]{
                {-1, 0, 1 },
                {-1, 0, 1 },
                {-1, 0, 1 },
            };
            this.P = new int[3, 3]{
                {1, 1, 1 },
                {0, 0, 0 },
                {-1, -1, -1 },
            };
        }

        private double getNormalizedValue(double value)
        {

            if (value > 255) return 255;

            if (value < 0) return 0;

            return value;
        }

        private double getU(double sumaP, double sumaQ)
        {

            if (sumaQ == 0)
            {
                if (sumaP >= 0) return 1.0 * Math.PI / 2;
                return -1.0 * Math.PI / 2;
            }
            else
            {
                double u = Math.Atan(sumaP / sumaQ);
                if (sumaQ < 0) u = u + Math.PI;

                return u;
            }
        }

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;
            var uR = Math.PI;
            var uG = Math.PI;
            var uB = Math.PI;

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

                    uR = getU(sR1, sR2) + Math.PI / 2;
                    uG = getU(sG1, sG2) + Math.PI / 2;
                    uB = getU(sB1, sB2) + Math.PI / 2;

                    double sumaR = 0;
                    double sumaG = 0;
                    double sumaB = 0;

                    for (int row = r - 1, pozR = 0; row <= r + 1; row++, pozR++)
                    {
                        for (int col = c - 1, pozC = 0; col <= c + 1; col++, pozC++)
                        {
                            color = workImage.GetPixel(row, col);

                            double scaleR = Math.Exp(-(pozR * pozR + pozC * pozC) / (2 * sigma * sigma))*Math.Sin(omega*(pozR*Math.Cos(uR + pozC * Math.Sin(uR))));
                            double scaleG = Math.Exp(-(pozR * pozR + pozC * pozC) / (2 * sigma * sigma))*Math.Sin(omega*(pozR*Math.Cos(uG + pozC * Math.Sin(uG))));
                            double scaleB = Math.Exp(-(pozR * pozR + pozC * pozC) / (2 * sigma * sigma))*Math.Sin(omega*(pozR*Math.Cos(uB + pozC * Math.Sin(uB))));

                            sumaR = sumaR + color.R * scaleR;
                            sumaG = sumaG + color.G * scaleB;
                            sumaB = sumaB + color.B * scaleG;

                        }
                    }

                    sumaR = getNormalizedValue(sumaR);
                    sumaG = getNormalizedValue(sumaG);
                    sumaB = getNormalizedValue(sumaB);

                    color = Color.FromArgb((byte)sumaR, (byte)sumaG, (byte)sumaB);
                    workImage2.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            workImage2.Unlock();
            return workImage2.GetBitMap();
            
        }
    }
}
