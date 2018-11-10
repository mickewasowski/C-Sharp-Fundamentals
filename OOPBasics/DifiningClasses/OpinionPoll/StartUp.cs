namespace OpinionPoll
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            People people = new People();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                people.AddPerson(person);
            }

            people.GetPeopleOlderThan30();
        }
    }
}
