using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractGame
{
    class AutomatedSprite : Sprite
    {
        public AutomatedSprite(Texture2D textureImage, Vector2 aPosition, Point frameSize, int collisionOffset,
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, float scale) :
            base(textureImage, aPosition, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, scale)
        {

        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame,
        Point sheetSize, Vector2 speed) : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed)
        {

        }

        public override void Update(GameTime aGameTime, Rectangle aRect)
        {
            position += direction;

            if (position.X > aRect.Width - frameSize.X / 2)
            {
                base.speed.X = direction.X * -1;
            }
            if (position.X < 0 - frameSize.X / 2)
            {
                speed.X = direction.X * -1;
            }
            if (position.Y > aRect.Height - frameSize.Y / 2)
            {
                speed.Y = direction.Y * -1;
            }
            if (position.Y < 0 - frameSize.Y / 2)
            {
                speed.Y = direction.Y * -1;
            }

            base.Update(aGameTime, aRect);
        }


        public override Vector2 direction
        {
            get
            {
                return base.speed;
            }

        }
    }



}