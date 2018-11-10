using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;
        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string type = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                if (type == "Private")
                {
                    //create
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    //create
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, salary,tokens);
                }
                else if (type == "Engineer")
                {
                    //create
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = GetEngineer(id, firstName, lastName, salary, tokens);
                }
                else if (type == "Commando")
                {
                    //create
                    decimal salary = decimal.Parse(tokens[4]);
                    soldier = GetCommando(id, firstName, lastName, salary, tokens);
                }
                else if (type == "Spy")
                {
                    //create
                    int codeNumber = int.Parse(tokens[4]);
                    soldier = GetSpy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }


                input = Console.ReadLine();
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            string corpsAsString = tokens[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary,corps);

            for (int i = 6; i < tokens.Length; i+=2)
            {
                string codeName = tokens[i];
                string stateAsString = tokens[i + 1];

                if (!Enum.TryParse(stateAsString,out State state))
                {
                    continue;
                }
                IMission mission = new Mission(codeName, state);

                commando.Missions.Add(mission);
            }
            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            string corpsAsString = tokens[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < tokens.Length; i+=2)
            {
                string partName = tokens[i];
                int workedHours = int.Parse(tokens[i + 1]);

                IRepair repair = new Repair(partName, workedHours);

                engineer.Repairs.Add(repair);
            }
            return engineer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] tokens)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < tokens.Length; i++)
            {
                int privateId = int.Parse(tokens[i]);
                IPrivate privateSoldier = (IPrivate) this.soldiers.FirstOrDefault(x => x.Id == privateId);

                lieutenantGeneral.Privates.Add(privateSoldier);
            }
            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            return privateSoldier;
        }
    }
}
