using System;

namespace ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            box.SurfaceArea(length, width, height);
            box.LateralSurfaceArea(length, width, height);
            box.Volume(length, width, height);
        }
    }
}
