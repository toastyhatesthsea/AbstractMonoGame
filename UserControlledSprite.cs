using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractGame
{
    class UserControlledSprite : Sprite
    {

        MouseState prevState;

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 aSpeed) :
            base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, aSpeed)
        {
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, float scale) :
            base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, scale)
        {
        }

        public override Vector2 direction
        {
            get
            {
                Vector2 answer = new Vector2();

                KeyboardState keyState = Keyboard.GetState();

                if (keyState.IsKeyDown(Keys.Down))
                {
                    answer.Y += 1;
                }
                if (keyState.IsKeyDown(Keys.Up))
                {
                    answer.Y -= 1;
                }
                if (keyState.IsKeyDown(Keys.Left))
                {
                    answer.X -= 1;
                }
                if (keyState.IsKeyDown(Keys.Right))
                {
                    answer.X += 1;
                }

                return answer * speed;
            }
        }

        public override void Update(GameTime aGameTime, Rectangle aRect)
        {
            //Position is changed by Direction variable
            position += direction;

            MouseState someMouseState = Mouse.GetState();
            if (someMouseState.X != prevState.X || someMouseState.Y !=
                prevState.Y)
            {
                position = new Vector2(someMouseState.X, someMouseState.Y);
            }
            prevState = someMouseState;

            /*
                        if(position.X < 0 + frameSize.X/2)
                        {
                            position.X = frameSize.X / 2;
                        }
                        if(position.X > aRect.X - frameSize.X)
                        {
                            position.X = aRect.X - frameSize.X; 
                        }
                        if(position.Y < 0 + frameSize.Y/2)
                        {
                            position.Y = frameSize.Y / 2;
                        }
                        if(position.Y > aRect.Y - frameSize.Y/2)
                        {
                            position.Y = frameSize.Y / 2;
                        }

            */
            base.Update(aGameTime, aRect);
        }
    }
}
