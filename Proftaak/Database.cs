using MySql.Data.MySqlClient;
using System;

namespace Proftaak
{
    internal class Database
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

        public void setScore(int game, int score)
        {
            getConnaction();
            query = "INSERT INTO scores (user_id, game_id, score) VALUES (" + user + "," + game + "," + score + ")";
            commandDatabase = new MySqlCommand(query, databaseConnection);

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception)
            {
            }
        }

        public int login(string u, string p)
        {
            getConnaction();
            query = "SELECT id, password FROM users WHERE username = '" + u + "'";
            commandDatabase = new MySqlCommand(query, databaseConnection);
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1)};
                        if (BCrypt.Net.BCrypt.Verify(p, row[1]))
                        {
                            return int.Parse(row[0]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }

                databaseConnection.Close();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
            return 0;
        }
    }
}