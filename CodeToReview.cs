﻿using System;
using System.Collegctions.Generic;
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    //indendation of the class fields and methods should be corrected for readability.
    public class People
    {
        // Under16 can be declared const not readonly.
        /* 
         
            As this const Under16 will not be used if the single parameter constructor is removed,
            thus this can also be removed from the class.

        */
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
     public string Name { get; private set; }
     public DateTimeOffset DOB { get; private set; }
        // As this constructor is not being used in the code currently, therefore it can be removed.
     public People(string name) : this(name, Under16.Date) { }
     public People(string name, DateTime dob) {
         Name = name;
         DOB = dob;
     }}

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        /// This field can be made readonly 
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        /// The method name does not rightly suggests what it is doing,rename it to AddPeople
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a random Name
                    // The logic of determing the name can be moved to a separate method GetName() to follow SRP
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    // The calculation of determing a random DOB can be moved to a separate method, GetDOB()
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        //This unused method can be removed.
        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            //x.Name == "Bob" can be written as x.Name.Equals("Bob", StringComparison.InvariantCultureIgnoreCase)
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;

            // the entire condition can be re-written as 'return (p.Name + " " + lastName).Substring(0, 255);'
            // and if condition should be corrected to p.Name.Length + lastName.Length > 255
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}