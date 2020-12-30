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
            Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame) :
            base(textureImage, aPosition, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame)
        {

        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame,
        Point sheetSize, Vector2 speed) : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed)
        {

        }

        public override void Update(GameTime aGameTime, Rectangle aRect)
        {
            position += direction;

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