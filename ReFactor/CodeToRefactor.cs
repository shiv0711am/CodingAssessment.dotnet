using System;
using System.Collections.Generic;

namespace CodingAssessment.Refactor
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        public People(string name) : this(name, Under16.Date)
        {
        }

        public People(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private readonly List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int numberOfPeople)
        {
            for (int j = 0; j < numberOfPeople; j++)
            {
                try
                {
                    // Creates a random Name
                    var name = GetName();
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(new Random().Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation", e);
                }
            }
            return _people;
        }

        //This method should be removed as it is not used in the code but commenting this method for review purpose.
        //private IEnumerable<People> GetBobs(bool olderThan30)
        //{
        //    return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        //}

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test") || string.IsNullOrEmpty(lastName))
                return p.Name.Substring(0, p.Name.Length > 255 ? 255 : p.Name.Length);

            var fullName = string.Concat(p.Name, lastName);
            if (fullName.Length > 255)
            {
                return (p.Name + " " + lastName).Substring(0, 255);
            }

            
            return p.Name + " " + lastName;
        }

        private string GetName()
        {
            var name = string.Empty;
            var random = new Random();
            if (random.Next(0, 1) == 0)
            {
                name = "Bob";
            }
            else
            {
                name = "Betty";
            }
            return name;
        }
    }
}