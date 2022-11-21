using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    internal class ReflexieStrategy : Strategy
    {
        public string reflectionStrategy = "Orizontala";

        public ReflexieStrategy(string reflectionStrategy)
        {
            this.reflectionStrategy = reflectionStrategy;
        }

        public override Bitmap ProcessImage(string workImagePath)
        {
            Color color;

            var image = new Bitmap(workImagePath);
            var workImage = new FastImage(image);

            var imageCopy = new Bitmap(workImage.Width, workImage.Height);
            var workImageCopy = new FastImage(imageCopy);


            //Orizontala
            workImage.Lock();
            workImageCopy.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);

                    var newX = i;
                    var newY = -j + workImage.Height;

                    newY = Math.Max(0, newY);
                    newY = Math.Min(workImage.Height - 1, newY);

                    workImageCopy.SetPixel(newX, newY, color);
                }
            }

            workImage.Unlock();
            workImageCopy.Unlock();

            return workImageCopy.GetBitMap();

        }
    }
}
