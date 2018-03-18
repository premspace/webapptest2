using System;
using System.Data.SQLite;
using PhoneBookTestApp.Log;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        AbstractLogger cLogger = new ConsoleLogger();
        AbstractLogger fLogger = new FileLogger();

        public static void initializeDatabase()
        {
            var dbConnection = GetConnection();
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        Constant.SQL_CREATE_TABLE_PERSON,
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        Constant.SQL_INSERT_TABLE_PERSON_1,
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        Constant.SQL_INSERT_TABLE_PERSON_2,
                        dbConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "DB initialization Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "DB initialization Failed!", ex.StackTrace);
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            try
            {
                string dbConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["PhoneBookEntities"].ToString();
                var dbConnection = new SQLiteConnection(dbConnStr);

                return dbConnection;
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Create DB connection Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "Create DB connection Failed!", ex.StackTrace);
                throw ex;
            }
        }

        public static void CleanUp()
        {
            var dbConnection = GetConnection();
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(Constant.SQL_DROP_TABLE_PERSON,
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "DB Cleanup Failed!", ex.StackTrace);
                Logger.Log(LoggerType.File, "DB Cleanup Failed!", ex.StackTrace);
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}