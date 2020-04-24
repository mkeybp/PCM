using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.State
{
    public abstract class State
    {
        #region Fields
        protected ContentManager stContent;

        protected GameWorld stGameWorld;

        protected GraphicsDevice stGraphics;

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content)
        {
            stGameWorld = gameWorld;
            stGraphics = graphicsDevice;
            stContent = content;
        }

        public abstract void Update(GameTime gameTime);

        #endregion
    }
}
