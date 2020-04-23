using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Data.SQLite;
using System.Diagnostics;

namespace PCM
{
    public enum GameState { StartScreen, Transfer, Racing }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {

        public GameState gamestate = new GameState();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont text;
        private Texture2D background;

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


            DatabaseConnection.Instance.DatabaseConnect();

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
            text = Content.Load<SpriteFont>("Text");
            background = Content.Load<Texture2D>("Background");


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


            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                gamestate = GameState.Transfer;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.G))
                gamestate = GameState.Racing;

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
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);


            // Position skal ++ på y aksen


            //while (DatabaseConnection.Instance.result.Read())
            //{
            //    DatabaseConnection.Instance.id = DatabaseConnection.Instance.result.GetInt32(0);
            //    DatabaseConnection.Instance.name = DatabaseConnection.Instance.result.GetString(1);

            //    Debug.WriteLine($"Id: {DatabaseConnection.Instance.id} Name: {DatabaseConnection.Instance.name}");


            //}


            if (gamestate == GameState.Transfer)
            {

                // NAME
                spriteBatch.DrawString(text, DatabaseConnection.Instance.name,
                                                new Vector2(50, 50),
                                                Color.Red,
                                               0,
                                               Vector2.Zero,
                                              1,
                                                SpriteEffects.None,
                                                1f);
                // STAMINA
                spriteBatch.DrawString(text, DatabaseConnection.Instance.stamina.ToString(),
                                              new Vector2(200, 50),
                                              Color.Red,
                                             0,
                                             Vector2.Zero,
                                            1,
                                              SpriteEffects.None,
                                              1f);

                // SPEED
                spriteBatch.DrawString(text, DatabaseConnection.Instance.speed.ToString(),
                                          new Vector2(250, 50),
                                              Color.Red,
                                             0,
                                             Vector2.Zero,
                                            1,
                                              SpriteEffects.None,
                                              1f);

                // STRENGHT
                spriteBatch.DrawString(text, DatabaseConnection.Instance.strength.ToString(),
                                               new Vector2(300, 50),
                                              Color.Red,
                                             0,
                                             Vector2.Zero,
                                            1,
                                              SpriteEffects.None,
                                              1f);

                // WEIGHT
                spriteBatch.DrawString(text, DatabaseConnection.Instance.weight.ToString(),
                                              new Vector2(350, 50),
                                             Color.Red,
                                            0,
                                            Vector2.Zero,
                                           1,
                                             SpriteEffects.None,
                                             1f);

                // AGE
                spriteBatch.DrawString(text, DatabaseConnection.Instance.age.ToString(),
                                              new Vector2(400, 50),
                                             Color.Red,
                                            0,
                                            Vector2.Zero,
                                           1,
                                             SpriteEffects.None,
                                             1f);


                // EXPERINCE
                spriteBatch.DrawString(text, DatabaseConnection.Instance.experince.ToString(),
                                              new Vector2(450, 50),
                                             Color.Red,
                                            0,
                                            Vector2.Zero,
                                           1,
                                             SpriteEffects.None,
                                             1f);


                // PRICE
                spriteBatch.DrawString(text, DatabaseConnection.Instance.price.ToString(),
                                              new Vector2(500, 50),
                                             Color.Red,
                                            0,
                                            Vector2.Zero,
                                           1,
                                             SpriteEffects.None,
                                             1f);

            }



            // TODO: Add your drawing code here

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
