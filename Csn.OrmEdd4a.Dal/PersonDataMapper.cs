﻿namespace Csn.OrmEdd4a.Dal
{
    using Csn.OrmEdd4a.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class PersonDataMapper
    {
        private readonly string _file;

        public PersonDataMapper()
        {
            _file = "Persons.csv";
        }

        public PersonDataMapper(string file)
        {
            _file = file;
        }

        public int GetNextId()
        {
            int id = 0;
            int maxId = 0;
            try
            {
                StreamReader reader = new StreamReader(_file);
                using(reader)
                {
                    string line = reader.ReadLine();
                    string[] separators = { "," };
                    string[] elements = new string[5];
                    while(line != null)
                    {
                        elements = line.Split(separators, StringSplitOptions.None);
                        line = reader.ReadLine();
                    }
                    id = int.Parse(elements[0]);
                    if (id > maxId) maxId = id;
                }
            }
            catch(FileNotFoundException)
            {
                Console.Error.WriteLine("The file {0} not found", _file);
            }
            catch(IOException e)
            {
                Console.Error.WriteLine("IOException {0}", e.Message);
            }

            // return ++id;
            return ++maxId;
        }

        public void Insert(Person person)
        {
            if (person.Id == 0) person.Id = GetNextId();
            try
            {
                StreamWriter writer = new StreamWriter(_file, true);
                using (writer)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4}",
                        person.Id,
                        person.Name,
                        person.FamilyName,
                        person.BirthDate.ToLongDateString(),
                        person.Address
                     );
                }
            }
            catch(IOException e)
            {
                Console.Error.WriteLine("IOException Message{0}", e.Message);
            }
            
        }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();

            try
            {
                StreamReader reader = new StreamReader(_file);
                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] separators = { "," };
                    string[] elements = new string[5];
                    while (line != null)
                    {
                        elements = line.Split(separators, StringSplitOptions.None);
                        Person person = new Person();
                        person.Id = int.Parse(elements[0]);
                        person.Name = elements[1];
                        person.FamilyName = elements[2];
                        person.BirthDate = DateTime.Parse(elements[3]);
                        person.Address = elements[4];
                        persons.Add(person);
                        line = reader.ReadLine();
                    }                  
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("The file {0} not found", _file);
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException {0}", e.Message);
            }

            return persons;
        }

        public void Update(Person person)
        {
            List<Person> persons = GetAll();
            foreach(Person personTemp in persons)
            {
                if (personTemp.Id == person.Id)
                {

                }
            }
        }
    }
}
