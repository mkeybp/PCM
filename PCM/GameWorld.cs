using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        private static GameWorld instance;

        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }

                return instance;

            }
        }


        public GameState gamestate = new GameState();

        public List<GameObject> gameObjects = new List<GameObject>();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont text;
        private Texture2D background;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            position = new Vector2(graphics.GraphicsDevice.Viewport.
                 Width / 2,
                              graphics.GraphicsDevice.Viewport.
                              Height / 2);
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
        Vector2 position;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState state = Mouse.GetState();



            position.X = state.X;
            position.Y = state.Y;

            Rectangle mouseRectangle = new Rectangle(state.X, state.Y, 100, 100); //4-int instance


            if (mouseRectangle.Intersects(rectangle)) //if rt intersects another
            {

                Debug.WriteLine("hit");
            }


            Debug.WriteLine(position.X.ToString() +
                                    "," + position.Y.ToString());

            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                gamestate = GameState.Transfer;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.G))
                gamestate = GameState.Racing;



            if (Keyboard.GetState().IsKeyDown(Keys.M))


                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        Rectangle rectangle;


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);



           


            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 50, 20);

            Color[] data = new Color[50 * 20];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);

            Vector2 coor = new Vector2(10, 20);
       

            /// Make a rectangle that takes an Id from the table, which can be "Buy" or "Sell"
            /// and if the mouse's rectangle intersects with the Buy/sell AND mouse is clicked, then do something


            int place = 50;

            // Show only if game is in transfer state
            //if (gamestate == GameState.Transfer)
            //{

            for (int i = 0; i < Instance.gameObjects.Count; i++)
            {
                GameObject riders = Instance.gameObjects[i];

                //if (Instance.gameObjects[i].experince == 3)
                //{
                    place += 30;

                rectangle = new Rectangle(650, place, 50, 20);


                // Position skal ++ på y aksen, for hver spiller der bliver loopet ud
                spriteBatch.DrawString(text, Instance.gameObjects[i].name
                        + "         " +
                        Instance.gameObjects[i].stamina
                        + "         " +
                        Instance.gameObjects[i].speed
                        + "         " +
                        Instance.gameObjects[i].strength
                        + "         " +
                        Instance.gameObjects[i].weight
                        + "         " +
                        Instance.gameObjects[i].age
                        + "         " +
                        Instance.gameObjects[i].experince
                        + "         " +
                        Instance.gameObjects[i].price,
                                                        new Vector2(75, place),
                                                        Color.Red,
                                                       0,
                                                       Vector2.Zero,
                                                      1,
                                                        SpriteEffects.None,
                                                        1f);

                spriteBatch.Draw(rect, new Vector2(650,place), Color.White);



                //// STAMINA
                //spriteBatch.DrawString(text, Instance.gameObjects[i].stamina.ToString(),
                //                              new Vector2(200, 50),
                //                              Color.Red,
                //                             0,
                //                             Vector2.Zero,
                //                            1,
                //                              SpriteEffects.None,
                //                              1f);

                //// SPEED
                //spriteBatch.DrawString(text, Instance.gameObjects[i].speed.ToString(),
                //                          new Vector2(250, 50),
                //                              Color.Red,
                //                             0,
                //                             Vector2.Zero,
                //                            1,
                //                              SpriteEffects.None,
                //                              1f);

                //// STRENGHT
                //spriteBatch.DrawString(text, Instance.gameObjects[i].strength.ToString(),
                //                               new Vector2(300, 50),
                //                              Color.Red,
                //                             0,
                //                             Vector2.Zero,
                //                            1,
                //                              SpriteEffects.None,
                //                              1f);

                //// WEIGHT
                //spriteBatch.DrawString(text, Instance.gameObjects[i].weight.ToString(),
                //                              new Vector2(350, 50),
                //                             Color.Red,
                //                            0,
                //                            Vector2.Zero,
                //                           1,
                //                             SpriteEffects.None,
                //                             1f);

                //// AGE
                //spriteBatch.DrawString(text, Instance.gameObjects[i].age.ToString(),
                //                              new Vector2(400, 50),
                //                             Color.Red,
                //                            0,
                //                            Vector2.Zero,
                //                           1,
                //                             SpriteEffects.None,
                //                             1f);


                //// EXPERINCE
                //spriteBatch.DrawString(text, Instance.gameObjects[i].experince.ToString(),
                //                              new Vector2(450, 50),
                //                             Color.Red,
                //                            0,
                //                            Vector2.Zero,
                //                           1,
                //                             SpriteEffects.None,
                //                             1f);


                //// PRICE
                //spriteBatch.DrawString(text, Instance.gameObjects[i].price.ToString(),
                //                              new Vector2(500, 50),
                //                             Color.Red,
                //                            0,
                //                            Vector2.Zero,
                //                           1,
                //                             SpriteEffects.None,
                //                             1f);




                //}

            }
            // TODO: Add your drawing code here
            //}
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

