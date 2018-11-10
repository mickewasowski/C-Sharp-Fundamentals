using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxDataValidation
{
    public class BoxDataValid
    {
        private double length;
        private double width;
        private double height;

        public BoxDataValid(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public void SurfaceArea(double length, double width, double height)
        {
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;

            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        }
        public void LateralSurfaceArea(double length, double width, double height)
        {
            double lateralSurfArea = 2 * length * height + 2 * width * height;

            Console.WriteLine($"Lateral Surface Area - {lateralSurfArea:f2}");
        }
        public void Volume(double length, double width, double height)
        {
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
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(1);
                }
                else
                {
                    this.length = value;
                }
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
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(1);
                }
                else
                {
                    this.width = value;
                }
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
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(1);
                }
                else
                {
                    this.height = value;
                }
            }
        }
    }
}
