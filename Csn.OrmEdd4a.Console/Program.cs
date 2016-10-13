namespace Csn.OrmEdd4a.Console
{
    using System;
    using System.Linq;
    using Csn.OrmEdd4a.Models;
    using System.Globalization;
    using System.Collections.Generic;
    using Csn.OrmEdd4a.Dal.DataMappers;
    using Csn.OrmEdd4a.Services;


    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            do {
                Console.Clear();
                Console.WriteLine("Please, make your choice:");
                Console.WriteLine("1. List all items");
                Console.WriteLine("2. Insert");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        List();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                }
            }while(choice != 5);

            
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

            //PersonDataMapper personDm = new PersonDataMapper();
            //// personDm.Insert(person1);

            //Console.WriteLine(personDm.GetNextId());

            //List<Person> persons = personDm.GetAll();
            //foreach(Person person in persons)
            //{
            //    Console.WriteLine(person);
                //Console.WriteLine("Id: {0}, Name: {1}, Family: {2}, BirthDate {3}, Address: {4}",
                //    person.Id,
                //    person.Name,
                //    person.FamilyName,
                //    person.BirthDate.ToLongDateString(),
                //    person.Address
                //    );
            }
    
        static void List()
        {
            // View
            Console.Clear();
            Console.WriteLine("Press enter to go back.");

            //IDataMapper<Person> personDm = new PersonDataMapper();
            //List<Person> persons = personDm.GetAll();

            IServices<Person> personServics = new PersonServices();
            List<Person> persons = personServics.GetAll();

            //// you need using System.Linq
            //var result = from p in persons
            //             where p.Id > 10
            //             orderby p.Name
            //             select new { Name = p.Name, Family = p.FamilyName };
            //             // select p;

            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }

            // view
            Console.ReadLine();
        }

        static void Insert()
        {
            Person person = new Person();
            CultureInfo provider = CultureInfo.InvariantCulture;

            // view
            Console.Clear();
            Console.Write("Name: ");
            person.Name = Console.ReadLine();
            Console.Write("Family Name: ");
            person.FamilyName = Console.ReadLine();
            Console.Write("Birthdate (yyyy-MM-dd): ");
            person.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Address: ");
            person.Address = Console.ReadLine();

            IDataMapper<Person> personDm = new PersonDataMapper();
            personDm.Insert(person);
        }

        static void Update()
        {
            int id = 0;
            do
            {
                Console.Clear();
                Console.Write("Please enter the id of a record to Update");
            } while (!int.TryParse(Console.ReadLine(), out id));

            IDataMapper<Person> personDm = new PersonDataMapper();
            Person person = personDm.Get(id);

            // view
            Console.Clear();
            Console.Write("Name ({0}): ", person.Name);
            person.Name = Console.ReadLine();
            Console.Write("Family Name ({0}): ",person.FamilyName);
            person.FamilyName = Console.ReadLine();
            Console.Write("Birthdate ({0}): ", person.BirthDate.ToString("yyyy-MM-dd"));
            person.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Address ({0}): ", person.Address);
            person.Address = Console.ReadLine();

            personDm.Update(person);
        }

        static void Delete()
        {
            int id = 0;
            do
            {
                Console.Clear();
                Console.Write("Please enter the id of a record to Delete: ");
            } while (!int.TryParse(Console.ReadLine(), out id));

            IDataMapper<Person> personDm = new PersonDataMapper();
            personDm.Delete(id);
        }
    }
}
