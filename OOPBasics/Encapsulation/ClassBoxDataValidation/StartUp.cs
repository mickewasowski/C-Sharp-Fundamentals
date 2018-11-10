using System;

namespace ClassBoxDataValidation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            BoxDataValid box = new BoxDataValid(length, width, height);

            box.SurfaceArea(length, width, height);
            box.LateralSurfaceArea(length, width, height);
            box.Volume(length, width, height);
        }
    }
}
