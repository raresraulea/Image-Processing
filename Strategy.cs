using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ComputerVision
{
    public abstract class Strategy
    {
        public abstract Bitmap ProcessImage(string workImagePath);
    }
}
