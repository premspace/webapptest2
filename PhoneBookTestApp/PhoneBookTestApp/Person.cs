using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using PhoneBookTestApp.Log;

namespace PhoneBookTestApp
{

    public class Person
    {
        [Key]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
    }

    public class PersonUtil
    {
        public Person createPerson(string fName, string lName, string phoneNumber, string address)
        {
            try
            {
                Person newPerson = new Person();
                newPerson.firstName = String.IsNullOrEmpty(fName) ? string.Empty : fName;
                newPerson.lastName = String.IsNullOrEmpty(lName) ? string.Empty : lName;
                newPerson.address = String.IsNullOrEmpty(address) ? string.Empty : address;
                newPerson.phoneNumber = String.IsNullOrEmpty(phoneNumber) ? "(000) 000 0000" : phoneNumber;
                return newPerson;
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Create Person object Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Create Person object Failed!", ex.StackTrace);
                throw ex;
            }
        }

        public void printPhonebook(PhoneBook book)
        {
            try
            {
                foreach (Person person in book.getAllPerson())
                {
                    printPersonDetails(person);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Printing phonebook Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Printing phonebook Failed!", ex.StackTrace);
                throw ex;
            }

        }

        public void findPersonDetails(PhoneBook book, string firstName, string lastName)
        {
            try
            {
                Person foundPerson = book.findPerson(firstName, lastName);
                if (foundPerson != null)
                {
                    printPersonDetails(foundPerson);
                }
                else
                {
                    throw new Exception(string.Format("No Person found with the name: '{0} {1}'",
                                                                        firstName, lastName));
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Find & Print Person object Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Find & Print Person object Failed!", ex.StackTrace);
                throw ex;
            }
        }

        private void printPersonDetails(Person person)
        {
            Console.WriteLine(string.Concat(person.firstName + " " + person.lastName, " | ", person.phoneNumber, " | ", person.address));
        }

        public void addNewPerson(PhoneBook book)
        {
            try
            {
                Console.Write("Enter Person First Name: ");
                string pFName = Console.ReadLine();
                Console.Write("Enter Person Last Name: ");
                string pLName = Console.ReadLine();
                Console.Write("Enter Person Phone: ");
                string pPhone = Console.ReadLine();
                Console.Write("Enter Person Address: ");
                string pAddress = Console.ReadLine();

                book.addPerson(createPerson(pFName, pLName, pPhone, pAddress));
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Adding Person object into phonebook Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Adding Person object into phonebook Failed!", ex.StackTrace);
                throw ex;
            }
        }
    }
}