using NUnit.Framework;
using PhoneBookTestApp;
using System.Data.Entity;
using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.Data.Entity.Validation;


namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        PhoneBook book = new PhoneBookTestApp.PhoneBook();
        Person person = new PhoneBookTestApp.Person();

        [Test]
        public void addPerson()
        {
            try
            {
                createSamplePerson();
                book.addPerson(person);
                Person fPerson = book.findPerson(person.firstName, person.lastName);
                Assert.AreEqual(fPerson.phoneNumber, person.phoneNumber);
            }
            catch (DbEntityValidationException ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void findPerson()
        {
            Assert.AreEqual(book.findPerson(person.firstName, person.lastName).address, "test_address 123");
        }

        private void createSamplePerson()
        {
            person.firstName = "John";
            person.lastName = "Smith";
            person.phoneNumber = "111 111 1111";
            person.address = "test_address 123";

        }
    }

    // ReSharper restore InconsistentNaming 
}