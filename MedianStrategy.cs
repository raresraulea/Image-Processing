using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class MedianStrategy : Strategy
    {

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);
            workImage.Lock();

            for (int r = 0; r < workImage.Width; r++)
            {
                for (int c = 0; c < workImage.Height; c++)
                {
                    List<int> R = new List<int>();
                    List<int> G = new List<int>();
                    List<int> B = new List<int>();
                    for (int row = r - 1; row <= r + 1; row++)
                    {
                        for (int col = c - 1; col <= c + 1; col++)
                        {
                            if(row >= 0 && row < workImage.Width && col >= 0 && col < workImage.Height)
                            {
                                color = workImage.GetPixel(row, col);
                                R.Add(color.R);
                                G.Add(color.G);
                                B.Add(color.B);
                            }
                        }
                    }
                    R.Sort();
                    G.Sort();
                    B.Sort();
                    color = Color.FromArgb((byte)R[R.Count/2], (byte)G[G.Count / 2], (byte)B[B.Count / 2]);
                    workImage.SetPixel(r, c, color);
                }
            }

            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
