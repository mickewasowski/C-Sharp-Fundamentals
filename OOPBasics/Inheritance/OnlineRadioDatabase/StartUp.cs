using OnlineRadioDatabase.Core;
using System;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
