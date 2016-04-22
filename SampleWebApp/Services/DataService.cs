using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Services
{
    public class DataService
    {
        public List<Person> GetPersons()
        {
            var p = new List<Person>();
            p.Add(new Person() { PersonId = 1, FirstName = "Jef", LastName = "Jones", Department = "Deparment 1", BirthDate = DateTime.Parse("5/1/1970") });
            p.Add(new Person() { PersonId = 1, FirstName = "Tony", LastName = "Spencer", Department = "Deparment 2", BirthDate = DateTime.Parse("1/4/1969") });
            p.Add(new Person() { PersonId = 1, FirstName = "Tom", LastName = "Maravilla", Department = "Deparment 1", BirthDate = DateTime.Parse("3/15/1971") });
            p.Add(new Person() { PersonId = 1, FirstName = "Jim", LastName = "Byer", Department = "Deparment 2", BirthDate = DateTime.Parse("11/21/1965") });
            p.Add(new Person() { PersonId = 1, FirstName = "Troy", LastName = "Miller", Department = "Deparment 3", BirthDate = DateTime.Parse("4/18/1972") });
            p.Add(new Person() { PersonId = 1, FirstName = "Mike", LastName = "Gibby", Department = "Deparment 2", BirthDate = DateTime.Parse("2/11/1968") });
            p.Add(new Person() { PersonId = 1, FirstName = "Jared", LastName = "Roper", Department = "Deparment 3", BirthDate = DateTime.Parse("6/8/1971") });
            p.Add(new Person() { PersonId = 1, FirstName = "Kiara", LastName = "Spencer", Department = "Deparment 4", BirthDate = DateTime.Parse("3/17/1999") });

            return p;
        }

    }

    public class Person
    {
        public Person()
        {

        }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}