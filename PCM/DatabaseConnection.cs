using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{
    public class DatabaseConnection : GameObject
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



        public void DatabaseConnect()
        {
            connection = new SQLiteConnection("Data Source=Riders.db;Version=3;New=True");

            connection.Open();

    
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

                // To add team name to DB try this:
                //result.GetString(9) = GameWorld.Instance.listOfCharsForTeamNaming;


                GameWorld.Instance.gameObjects.Add(new Rider());

                // CREATE
                if (GameWorld.Instance.crud == CRUD.Create)
                {
                    command = new SQLiteCommand("INSERT INTO riders (Name, Stamina, Speed, Strength, Weight, Age, Experience, Price)" +
                        "Values ('HJEHEJE', 100, 100, 100, 100, 100, 100 ,1000000)", connection);
                    //command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                // UPDATE
                if (GameWorld.Instance.crud == CRUD.Update)
                {
                    command = new SQLiteCommand("UPDATE riders SET Name = 'ljahwdjh' WHERE Name = 'HJEHEJE'", connection);
                    //command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                // DELETE 
                if (GameWorld.Instance.crud == CRUD.Delete)
                {
                    // Delete from team table by id, if button "Sell" is pressed 
                    command = new SQLiteCommand("DELETE FROM riders WHERE Name='HJEHEJE'", connection);
                    //command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                // INSERT rider into players team db

                //:.

            }

            connection.Close();

        }
    }
}
