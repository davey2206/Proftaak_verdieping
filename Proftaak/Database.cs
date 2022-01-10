using MySql.Data.MySqlClient;
using System;

namespace Proftaak
{
    class Database
    {
        private int user;
        private string conString = "datasource=192.168.158.168;port=3306;username=web;password=web;database=usertable;";
        private string query = "";
        private MySqlConnection databaseConnection;
        private MySqlCommand commandDatabase;
        private MySqlDataReader reader;

        public int User
        {
            get { return user; }
            set { user = value; }
        }

        public void getConnaction()
        {
            databaseConnection = new MySqlConnection(conString);
        }

        public string getUserScore(int game)
        {
            query = "SELECT score FROM scores WHERE user_id = " + user + " AND game_id = " + game;

            commandDatabase = new MySqlCommand(query, databaseConnection);
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0) };
                        return row[0];
                    }
                }
                else
                {
                    return null;
                }

                databaseConnection.Close();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return null;
        }

        public void setUserScore(int game)
        {
            query = "UPDATE scores SET score = score + 1 WHERE user_id = " + user + " AND game_id = " + game;
            commandDatabase = new MySqlCommand(query, databaseConnection);

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
