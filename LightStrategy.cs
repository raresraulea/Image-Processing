using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class LightStrategy : Strategy
    {
        public int delta;

        public LightStrategy(int delta)
        {
            this.delta = delta;
        }

        private int getCheckedValue(int value, int delta)
        {

            if (value + delta > 255) return 255;

            if (value + delta < 0) return 0;

            return value + delta;
        }

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    var newR = getCheckedValue((int)R, delta);
                    var newG = getCheckedValue((int)G, delta);
                    var newB = getCheckedValue((int)B, delta);

                    color = Color.FromArgb(newR, newG, newB);

                    workImage.SetPixel(i, j, color);
                }
            }

            workImage.Unlock();
            return workImage.GetBitMap();
            
        }
    }
}
