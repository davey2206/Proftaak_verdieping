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
            query = "";
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