﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PCM.Components
{
    class Button : Component
    {
        #region Fields

        private MouseState currentMouse;

        private SpriteFont buttonFont;

        private bool hovering;

        private MouseState previousMouse;

        private Texture2D buttonTexture;

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, buttonTexture.Width, buttonTexture.Height);
            }
        }

        public string Text { get; set; }

        #endregion

        #region Methods
        // dette er en constructer for at lave vores knapper til menuen. En knap indeholder en texture og en font.
        public Button(Texture2D texture, SpriteFont font)
        {
            buttonTexture = texture;

            buttonFont = font;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (hovering)
                colour = Color.Gray;

            spriteBatch.Draw(buttonTexture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (buttonFont.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (buttonFont.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(buttonFont, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            hovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                hovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }

            Debug.WriteLine(currentMouse.X);
        }




        #endregion
    }
}
