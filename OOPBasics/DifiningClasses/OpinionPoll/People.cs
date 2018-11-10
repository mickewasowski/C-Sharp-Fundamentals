namespace OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class People
    {
        private List<Person> people;

        public People()
        {
            this.people = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new Exception();
            }

            this.people.Add(person);
        }
        public void GetPeopleOlderThan30()
        {
            foreach (var p in people.OrderBy(p => p.Name))
            {
                if (p.Age > 30)
                {
                    Console.WriteLine($"{p.Name} - {p.Age}");
                }
            }
        }
    }
}
