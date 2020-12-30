using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AbstractGame
{
    abstract class Sprite
    {
        Texture2D textureImage;
        protected Vector2 position, speed;
        protected Point frameSize, currentFrame, sheetSize;
        protected int collisionOffset, timeSinceLastFrame, millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;

        public Sprite(Texture2D aTextureImage, Vector2 aPos, Point aFrameSize,
            int aCollisionOffset, Point aCurrentFrame, Point aSheetSize,
            Vector2 aSpeed)
        {
            this.textureImage = aTextureImage;
            position = aPos;
            speed = aSpeed;
            collisionOffset = aCollisionOffset;
            currentFrame = aCurrentFrame;
            sheetSize = aSheetSize;
            frameSize = aFrameSize;
            millisecondsPerFrame = defaultMillisecondsPerFrame;
        }

        public Sprite(Texture2D textureImage, Vector2 position, 
            Point frameSize, int collisionOffset, Point currentFrame, 
            Point sheetSize, Vector2 speed, int millisecondsPerFrame) 
        { 
            this.textureImage = textureImage; 
            this.position = position; 
            this.frameSize = frameSize; 
            this.collisionOffset = collisionOffset; 
            this.currentFrame = currentFrame; 
            this.sheetSize = sheetSize; 
            this.speed = speed; 
            this.millisecondsPerFrame = millisecondsPerFrame; 
        }

        protected Sprite()
        {
        }

        virtual public void Update(GameTime aGameTime, Rectangle aRect)
        {
            timeSinceLastFrame = +aGameTime.ElapsedGameTime.Milliseconds;
            if(timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                currentFrame.X++;
                if(currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if(currentFrame.Y >= sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }
            }
        }

        public void Draw(GameTime aGameTime, SpriteBatch aBatch)
        {
            aBatch.Draw(textureImage, position, new Rectangle(currentFrame.X * frameSize.X,
                currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White,
                0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }

        public abstract Vector2 direction
        {
            get;
        }

        public Rectangle rectCollision()
        {
            return new Rectangle((int)position.X + collisionOffset, (int)position.Y + collisionOffset,
                frameSize.X - collisionOffset, frameSize.Y - collisionOffset);
        }
        
    }
}
