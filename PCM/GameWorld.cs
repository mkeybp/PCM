using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Data.SQLite;
using System.Diagnostics;

namespace PCM
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public void DatabaseConnection()
        {
            var connection = new SQLiteConnection("Data Source=PCM.db;Version=3;New=True");

            connection.Open();

            var command = new SQLiteCommand("DROP TABLE riders", connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS riders (Id INTEGER PRIMARY KEY, Name VARCHAR(50));", connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("INSERT INTO riders (Name) VALUES ('Daenerys Targaryen');", connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("INSERT INTO riders (Name) VALUES ('Tyrion Lannister');", connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("INSERT INTO riders (Name) VALUES ('Jon Snow');", connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("SELECT * FROM riders", connection);
            var result = command.ExecuteReader();

            while (result.Read())
            {
                var id = result.GetInt32(0);
                var name = result.GetString(1);

                Debug.WriteLine($"Id: {id} Name: {name}");
            }

            connection.Close();

        }


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            DatabaseConnection();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
