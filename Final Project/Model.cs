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

        public Model(String databasePath)
        {
            InitializeDatabaseConnection(databasePath);
        }

        public OleDbDataAdapter GetAdapterForDataGridView(String command)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(command, connection);

            return adapter;
        }

        public void InsertMedia(IOrganize media)
        {
            try
            {
                command = new OleDbCommand();
                command.Connection = connection;

                String statement = $"INSERT INTO media (type_id, title, description, genre, length, artists, cost, date_released," +
                    $" publisher, location, format, [size]) VALUES" +
                    $" ('{media.TypeId}', '{media.Title}', '{media.Description}', '{media.Genre}', '{media.Length}', '{media.Artists}', " +
                    $"'{media.Cost}', '{media.DateReleased}', '{media.Publisher}', '{media.Location}', '{media.Format}', " +
                    $"'{media.Size}')";

                command.CommandText = statement;

                connection.Open();

                int result = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR inserting record {media.Title} into table: {ex}");

                throw new Exception("Could not store record. Please try again.");

            }
            finally
            {
                connection.Close();
            }

        }

        public IOrganize GetMedia(String id)
        {
            try
            {
                command = new OleDbCommand();
                command.Connection = connection;

                String statement = $"SELECT * FROM existing_media WHERE id = {id}";

                command.CommandText = statement;

                connection.Open();

                reader = command.ExecuteReader();

                IOrganize media = null;

                while (reader.Read())
                {
                    switch (reader.GetValue(1).ToString())
                    {
                        case "Game":
                            media = new Game();
                            break;
                        case "Movie":
                            media = new Movie();
                            break;
                        case "Music":
                            media = new Music();
                            break;
                        default:
                            throw new Exception("Invalid media type");
                    }

                    media.TypeId = reader.GetValue(1).ToString();
                    media.Title = reader.GetValue(2).ToString();
                    media.Description = reader.GetValue(3).ToString();
                    media.Genre = reader.GetValue(4).ToString();
                    media.Length = reader.GetValue(5).ToString();
                    media.Artists = reader.GetValue(6).ToString();
                    media.Cost = reader.GetValue(7).ToString();
                    media.DateReleased = reader.GetValue(8).ToString();
                    media.Publisher = reader.GetValue(9).ToString();
                    media.Location = reader.GetValue(10).ToString();
                    media.Format = reader.GetValue(11).ToString();
                    media.Size = reader.GetValue(12).ToString();

                    return media;
                }

                return media;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public IOrganize UdpateMedia(IOrganize media, String id)
        {
            try
            {
                String statement = $"UPDATE media SET " +
                    $"type_id = {media.TypeId}, " +
                    $"title = '{media.Title}', " +
                    $"description = '{media.Description}', " +
                    $"genre = '{media.Genre}', " +
                    $"length = '{media.Length}', " +
                    $"artists = '{media.Artists}', " +
                    $"cost = '{media.Cost}', " +
                    $"date_released = '{media.DateReleased}', " +
                    $"publisher = '{media.Publisher}', " +
                    $"location = '{media.Location}', " +
                    $"format = '{media.Format}', " +
                    $"[size] = '{media.Size}' WHERE id = {id}";


                command.CommandText = statement;

                connection.Open();

                int result = command.ExecuteNonQuery();

                connection.Close();

                return GetMedia(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        public void DeleteMedia(String id)
        {
            try
            {
                command = new OleDbCommand();
                command.Connection = connection;

                String statement = $"DELETE * FROM media WHERE id = {id} ";

                command.CommandText = statement;

                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
            }
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        private void InitializeDatabaseConnection(string databasePath)
        {
            connection = new OleDbConnection
            {
                ConnectionString = $"Provider = Microsoft.Jet.OLEDB.4.0;Data Source={databasePath};"
            };
        }
    }
}
