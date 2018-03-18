using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using PhoneBookTestApp.Log;


namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        PhoneBookEntities dbObj = new PhoneBookEntities();

        public void addPerson(Person person)
        {
            try
            {
                dbObj.Persons.Add(person);
                dbObj.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Logger.Log(LoggerType.Console, "Adding new Person Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Adding new Person Failed!", ex.StackTrace);
                throw ex;
            }
        }

        public Person findPerson(string firstName, string lastName)
        {
            Person foundPerson = null;
            try
            {
                foundPerson = (from a in dbObj.Persons
                               where (a.firstName.ToLower() == firstName.ToLower()
                               && a.lastName.ToLower() == lastName.ToLower())
                               orderby a.firstName
                               select a).First();
                return foundPerson;
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Finding Person Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Finding Person Failed!", ex.StackTrace);
                throw ex;

            }
        }

        public List<Person> getAllPerson()
        {
            try
            {
                return (from x in dbObj.Persons
                        select x).ToList<Person>();
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "List all person failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "List all person failed!", ex.StackTrace);
                throw ex;
            }
        }
    }
}