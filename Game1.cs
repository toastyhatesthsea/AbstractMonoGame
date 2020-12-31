using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AbstractGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Sprite> spriteList;
        private Texture2D skullbull, heroTexture;
        private AutomatedSprite skullAnim1, skullAnim2, skullAnim3;

        private UserControlledSprite heroSprite;
        private int skullCollisionOffset;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = @"Content";

            IsMouseVisible = true;

            spriteList = new List<Sprite>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            skullCollisionOffset = 10;
            skullbull = Content.Load<Texture2D>(@"../Content/Images/skullball");
            heroTexture = Content.Load<Texture2D>(@"../Content/Images/cuteIdleHorz");


            skullAnim1 = new AutomatedSprite(skullbull, new Vector2(50, 150), new Point(skullbull.Width / 6, skullbull.Height / 8), skullCollisionOffset,
            new Point(0, 0), new Point(6, 8), new Vector2(1, 0), 50);
            skullAnim2 = new AutomatedSprite(skullbull, new Vector2(75, 75), new Point(skullbull.Width / 6, skullbull.Height / 8), skullCollisionOffset,
            new Point(0, 0), new Point(6, 8), new Vector2(1, 1), 60);
            skullAnim3 = new AutomatedSprite(skullbull, new Vector2(0, 75), new Point(skullbull.Width / 6, skullbull.Height / 8), skullCollisionOffset,
            new Point(0, 0), new Point(6, 8), new Vector2(1, 2), 30);

            heroSprite = new UserControlledSprite(heroTexture, new Vector2(0, 30), new Point(heroTexture.Width / 16, heroTexture.Height),
            skullCollisionOffset, new Point(0, 0), new Point(16, 0), new Vector2(2, 2));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            skullAnim1.Update(gameTime, Window.ClientBounds);
            skullAnim2.Update(gameTime, Window.ClientBounds);
            skullAnim3.Update(gameTime, Window.ClientBounds);
            heroSprite.Update(gameTime, Window.ClientBounds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // TODO: Add your drawing code here
            skullAnim1.Draw(gameTime, _spriteBatch);
            skullAnim2.Draw(gameTime, _spriteBatch);
            skullAnim3.Draw(gameTime, _spriteBatch);
            heroSprite.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
