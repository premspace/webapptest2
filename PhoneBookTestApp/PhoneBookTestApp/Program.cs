using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookTestApp.Log;
namespace PhoneBookTestApp
{
    class Program
    {
        private static PhoneBook phonebook = new PhoneBook();

        static void Main(string[] args)
        {
            bool quit = false;

            try
            {
                Logger.Log(LoggerType.File, "Main", "Program Started");
                try
                {
                    DatabaseUtil.initializeDatabase();
                }
                catch (Exception ex)
                {
                    Logger.Log(LoggerType.Console, "Database init", " Error Occurred" + ex.StackTrace);
                }
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                PersonUtil personUtil = new PersonUtil();

                Console.WriteLine("Print all phonebook contacts:");
                Console.WriteLine("====================================");
                phonebook.addPerson(personUtil.createPerson("John", "Smith", "(248) 123-4567", "1234 Sand Hill Dr, Royal Oak, MI"));
                phonebook.addPerson(personUtil.createPerson("Cynthia", "Smith", "(824) 128-8758", "875 Main St, Ann Arbor, MI"));

                // TODO: print the phone book out to System.out
                personUtil.printPhonebook(phonebook);

                // TODO: find Cynthia Smith and print out just her entry
                Console.WriteLine();
                Console.WriteLine("Search & Print Cynthia Smith details:");
                Console.WriteLine("====================================");
                personUtil.findPersonDetails(phonebook, "Cynthia Smith".Split(" ".ToCharArray())[0], "Cynthia Smith".Split(" ".ToCharArray())[1]);

                // TODO: insert the new person objects into the database
                Console.WriteLine();
                Console.WriteLine("Add new person into phonebook:");
                Console.WriteLine("====================================");
                personUtil.addNewPerson(phonebook);

                while (!quit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose a number from the list below:");
                    Console.WriteLine("1.PRINT PHONEBOOK 2.FIND A PERSON 3. ADD NEW PERSON 4. QUIT");
                    string option = Console.ReadLine();

                    switch (option)
                    {

                        case "1": //PRINT PHONEBOOK
                            try
                            {
                                personUtil.printPhonebook(phonebook);
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(LoggerType.Console, "Printing phone book Failed!", ex.StackTrace);
                                Logger.Log(LoggerType.File, "Printing phone book Failed!", ex.StackTrace);
                            }
                            break;
                        case "2": //FIND A PERSON
                            string fName = string.Empty, lName = string.Empty;
                            try
                            {
                                Console.WriteLine("Enter person First Name to find from phonebook:");
                                fName = Console.ReadLine();
                                Console.WriteLine("Enter person Last Name to find from phonebook:");
                                lName = Console.ReadLine();
                                personUtil.findPersonDetails(phonebook, fName, lName);
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(LoggerType.Console, "Finding: " + fName + " " + lName, "No Person find with this name.");
                                Logger.Log(LoggerType.File, "Finding: " + fName + " " + lName, ex.StackTrace);
                            }
                            break;
                        case "3": // ADD NEW PERSON
                            try
                            {
                                personUtil.addNewPerson(phonebook);
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(LoggerType.Console, "Adding new Person Failed!", ex.StackTrace);
                                Logger.Log(LoggerType.File, "Adding new Person Failed!", ex.StackTrace);

                            }
                            break;
                        default: //CLEAN UP
                            DatabaseUtil.CleanUp();
                            quit = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Main Program", ex.Message);
            }

            finally
            {
                if (!quit) DatabaseUtil.CleanUp();
                Console.Read();
                Logger.Log(LoggerType.File, "Main", "Program Ended.");
            }
        }


    }
}
