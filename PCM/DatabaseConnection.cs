using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{
    public class DatabaseConnection
    {
        private static DatabaseConnection instance;

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }

                return instance;

            }
        }

        public SQLiteDataReader result;
        public SQLiteConnection connection;
        public SQLiteCommand command;
        public int id;
        public string name;
        public float stamina;
        public float speed;
        public float strength;
        public float weight;
        public float age;
        public float experince;
        public float price;


        public void DatabaseConnect()
        {
            connection = new SQLiteConnection("Data Source=Riders.db;Version=3;New=True");

            connection.Open();

            //command = new SQLiteCommand("DROP TABLE riders", connection);
            //command.ExecuteNonQuery();

            //command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS riders (Id INTEGER PRIMARY KEY, Name VARCHAR(50));", connection);
            //command.ExecuteNonQuery();

            //command = new SQLiteCommand("INSERT INTO riders (Name) VALUES ('Daenerys Targaryen');", connection);
            //command.ExecuteNonQuery();

            //command = new SQLiteCommand("INSERT INTO riders (Name) VALUES ('Tyrion Lannister');", connection);
            //command.ExecuteNonQuery();

            //command = new SQLiteCommand("INSERT INTO riders (Name) VALUES ('Jon Snow');", connection);
            //command.ExecuteNonQuery();

            command = new SQLiteCommand("SELECT * FROM riders", connection);
            result = command.ExecuteReader();

            while (result.Read())
            {
                id = result.GetInt32(0);
                name = result.GetString(1);
                stamina = result.GetFloat(2);
                speed = result.GetFloat(3);
                strength = result.GetFloat(4);
                weight = result.GetFloat(5);
                age = result.GetInt32(6);
                experince = result.GetFloat(7);
                price = result.GetFloat(8);


                Debug.WriteLine($"Id: {id} Name: {name}");
            }

            connection.Close();

        }
    }
}
