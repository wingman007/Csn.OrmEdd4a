namespace Csn.OrmEdd4a.Models
{
    using System;
    using System.Collections.Generic;
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
