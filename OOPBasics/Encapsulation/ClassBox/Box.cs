using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public void SurfaceArea(double length, double width, double height)
        {
            //Surface Area = 2lw + 2lh + 2wh
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;

            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        }
        public void LateralSurfaceArea(double length, double width, double height)
        {
            //Lateral Surface Area = 2lh + 2wh
            double lateralSurfArea = 2 * length * height + 2 * width * height;

            Console.WriteLine($"Lateral Surface Area - {lateralSurfArea:f2}");
        }
        public void Volume(double length, double width, double height)
        {
            //Volume = lwh
            double volume = length * width * height;

            Console.WriteLine($"Volume - {volume:f2}");
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
        
    }
}
