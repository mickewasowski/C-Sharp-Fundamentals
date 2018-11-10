using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person p1 = new Person(2);
            Person p2 = new Person("Pesho", 3);
        }
    }
}
