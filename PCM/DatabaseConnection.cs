using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM
{

    public class DatabaseConnection : GameObject
    {

        public string teamNameArray;
        public CRUD crud = new CRUD();

        public GameState gamestate = new GameState();

        private static DatabaseConnection instance;
        private string txtQuery;


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



            }

            connection.Close();

        }


        public void CRUDDb()
        {
            // Cast's the listOfCharsForTeamNaming to an array to post it to the db in a single string
            KeyboardState kbState = Keyboard.GetState();


            connection.Open();
            //command = new SQLiteCommand("DROP TABLE teams");
            /// if teamname is > than 0, insert to a new table.
            /// Then insert riders that is picked into the team
            command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS teams (Id INTEGER PRIMARY KEY, TeamName VARCHAR(50));", connection);


            if (kbState.IsKeyDown(Keys.Enter) && GameWorld.Instance.previousKBState.IsKeyUp(Keys.Enter) && gamestate == GameState.StartScreen)
            {
                command = connection.CreateCommand();

                teamNameArray = new string(GameWorld.Instance.listOfCharsForTeamNaming.ToArray());
                command.CommandText = txtQuery = "INSERT INTO teams (TeamName) values ('" + teamNameArray + "');";
            }
            Debug.WriteLine(teamNameArray);



            command.ExecuteNonQuery();


            // CREATE
            // Add RiderID
            if (crud == CRUD.Create)
            //if (true)
            {
                command = new SQLiteCommand("INSERT INTO riders (Name, Stamina, Speed, Strength, Weight, Age, Experience, Price)" +
                "Values ('HJEHEJE', 100, 100, 100, 100, 100, 100 ,1000000)", connection);
                //command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }


            // UPDATE
            if (false)
            {
                command = new SQLiteCommand("UPDATE riders SET Name = 'ljahwdjh' WHERE Name = 'HJEHEJE'", connection);
                //command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }

            // DELETE 
            if (false)
            {
                // Delete from team table by id, if button "Sell" is pressed 
                command = new SQLiteCommand("DELETE FROM riders WHERE Name='ljahwdjh'", connection);
                //command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }

            // INSERT rider into players team db
            //:.


            if (kbState.IsKeyDown(Keys.C) && GameWorld.Instance.previousKBState.IsKeyUp(Keys.C))
            {

                crud = CRUD.Create;
            }

            if (kbState.IsKeyDown(Keys.U) && GameWorld.Instance.previousKBState.IsKeyUp(Keys.U))
            {

                crud = CRUD.Update;
            }

            if (kbState.IsKeyDown(Keys.D) && GameWorld.Instance.previousKBState.IsKeyUp(Keys.D))
            {

                crud = CRUD.Delete;
            }
            GameWorld.Instance.previousKBState = kbState;

            connection.Close();
        }
    }
}
