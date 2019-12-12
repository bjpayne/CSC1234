using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Final_Project
{
    class Model
    {
        private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataReader reader;

        public Model(string databasePath)
        {
            InitializeDatabaseConnection(databasePath);
        }

        public void InsertMedia(IOrganize media)
        {
            //TODO: Add logic to validate fields
            try
            {
                command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO GAMES (title, publisher, location) VALUES" +
                    $" ('{media.Title}', '{media.Publisher}', '{media.Location}')";
                connection.Open();
                int result = command.ExecuteNonQuery();
                

                //here for troubleshooting/logging
                if(result > 0)
                {
                    Console.WriteLine($"INSERT {media.Title} into GAMES Table");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR inserting record {media.Title} into table: {ex}");
            }
            finally
            {
                connection.Close();
            }

        }

        private void InitializeDatabaseConnection(string databasePath)
        {
            connection = new OleDbConnection
            {
                ConnectionString = $"Provider = Microsoft.ACE.OleDB.12.0;Data Source = {databasePath};"
            };
        }
    }
}
