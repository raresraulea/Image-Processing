using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    public class MarkovStrategy : Strategy
    {
        public bool Salt_Pepper(int row, int col, FastImage workImage)
        {
            Color color = workImage.GetPixel(row, col);
            byte R = color.R;
            byte G = color.G;
            byte B = color.B;

            byte average = (byte)((R + G + B) / 3);

            return average == 255 || average == 0;
        }

        public int SAD(int x1, int y1, int x2, int y2, FastImage img)
        {
            int S = 0;
            int CS = 3;

            for (int i = -CS/2; 
                (i < CS/2) && 
                (i + x1 >= 0) && 
                (i + x1 < img.Width) && 
                (i + x2 >= 0) && 
                (i + x2 < img.Width); 
            i++)
            {
                for (int j = -CS/2; 
                    (j < CS/2) && 
                    (j + y1 >= 0) && 
                    (j + y1 < img.Height) && 
                    (j + y2 >= 0) && 
                    (j + y2 < img.Height); 
                j++)
                {
                    if (i == 0 && j == 0 ) continue;

                    Color color1 = img.GetPixel(i + x1, j + y1);
                    byte R1 = color1.R;
                    byte G1 = color1.G;
                    byte B1 = color1.B;
                    var average1 = (byte)(R1 + G1 + B1) / 3;

                    Color color2 = img.GetPixel(i + x2, j + y2);
                    byte R2 = color2.R;
                    byte G2 = color2.G;
                    byte B2 = color2.B;
                    var average2 = (byte)(R2 + G2 + B2) / 3;

                    S += Math.Abs(average1 - average2);
                        
                }
            }

            return S;
        }

        public Color CBP(int x, int y, FastImage img) {
            int SR = 4;
            int T = 500;

            int startX = Math.Max(0, x - SR);
            int endX = Math.Min(img.Width, x + SR);
            int startY = Math.Max(0, y - SR);
            int endY = Math.Min(img.Height, y + SR);

            Dictionary<Color, int> Q = new Dictionary<Color, int>();

            for(int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    if (i == x && j == y) continue;

                    if(SAD(x, y, i, j, img) < T && Salt_Pepper(i, j, img) == false)
                    {
                        Color color = img.GetPixel(i, j);

                        if(Q.ContainsKey(color)) Q[color]++;
                        else Q.Add(color, 1);
                    }
                }
            }


            var max = new KeyValuePair<Color, int>(new Color(), 0);
            foreach (var kvp in Q)
                if (kvp.Value > max.Value)
                    max = kvp;

            return max.Key;
        } 

        public override Bitmap ProcessImage(string workImagePath)
        {
            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            workImage.Lock();

            for (int r = 0; r < workImage.Width; r++)
            {
                for (int c = 0; c < workImage.Height; c++)
                {
                    if(Salt_Pepper(r, c, workImage))
                    {
                        workImage.SetPixel(r, c, CBP(r, c, workImage));
                    }
                }
            }

            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
