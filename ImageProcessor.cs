using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    public class ImageProcessor
    {
        Strategy strategy;
        private string workImagePath;

        // Constructor

        public ImageProcessor(Strategy strategy, string workImagePath)
        {
            this.strategy = strategy;
            this.workImagePath = workImagePath;
        }

        public Bitmap ProcessImage()
        {
            return strategy.ProcessImage(workImagePath);
        }
    }
}
