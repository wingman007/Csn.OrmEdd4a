namespace Csn.OrmEdd4a.Console
{
    using Csn.OrmEdd4a.Dal;
    using Csn.OrmEdd4a.Models;
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            
            //Person person1 = new Person();
            //Console.Write("Please enter Name: ");
            //person1.Name = Console.ReadLine();
            //Console.WriteLine();
            //Console.Write("Please enter Family Name: ");
            //person1.FamilyName = Console.ReadLine();
            //Console.WriteLine();
            //Console.Write("Please enter Birth Date (YYYY-MM-DD): ");
            //person1.BirthDate = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine();
            //Console.Write("Please enter the Address: ");
            //person1.Address = Console.ReadLine();
            //Console.WriteLine();
            
            /*
            Person person1 = new Person() { 
                Name = "Stoyan",
                FamilyName = "Cheresharov",
                BirthDate = Convert.ToDateTime("1964-03-29"),
                Address = "7 Chernishevski str"
            };
            */
            //Console.WriteLine("The name of person 1 is {0}", person1.Name);

            PersonDataMapper personDm = new PersonDataMapper();
            // personDm.Insert(person1);

            Console.WriteLine(personDm.GetNextId());

            List<Person> persons = personDm.GetAll();
            foreach(Person person in persons)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Family: {2}, BirthDate {3}, Address: {4}",
                    person.Id,
                    person.Name,
                    person.FamilyName,
                    person.BirthDate.ToLongDateString(),
                    person.Address
                    );
            }
        }
    }
}
