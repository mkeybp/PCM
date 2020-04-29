using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.States
{
    public abstract class State
    {
        #region Fields

        protected ContentManager content;

        protected GraphicsDevice graphicsDevice;

        protected GameWorld game;

        #endregion
        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(GameWorld stGame, GraphicsDevice stGraphicsDevice, ContentManager stContent)
        {
            game = stGame;

            graphicsDevice = stGraphicsDevice;

            content = stContent;
        }

        public abstract void Update(GameTime gameTime);

        #endregion

    }
}
