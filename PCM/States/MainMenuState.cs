using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PCM.Components;

namespace PCM.States
{
   public class MainMenuState : State
    {
        private List<Component> components;

        public MainMenuState(GameWorld game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            var buttonTexture = content.Load<Texture2D>("ACyclist1");
            var buttonFont = content.Load<SpriteFont>("Text");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            components = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();

            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            //spriteBatch.End();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new Gamestate(game, graphicsDevice, content));
        }



        public override void PostUpdate(GameTime gameTime)
        {
         
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            game.Exit();
        }

    }
}
