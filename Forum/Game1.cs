using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Forum
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        PostButton postButton;
        ArrayList posts;
        //DeleteButton deleteButton;
        int numberPost;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            font = Content.Load<SpriteFont>("Font");
            postButton = new PostButton(GraphicsDevice, font);
            //deleteButton = new DeleteButton(GraphicsDevice, font);
            posts = new ArrayList();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F11))
                graphics.ToggleFullScreen();

            postButton.Update(gameTime);
            if (postButton.NewPost())
            {
                posts.Add(new Post(GraphicsDevice, "BLeach", "This is my first post. This is my first post. This is my first post. This is my first post. This is my first post.", font, postButton.getNewColor(), numberPost));
                numberPost++;
            }
            foreach (Post post in posts)
            {
                post.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MintCream);

            spriteBatch.Begin();
            postButton.Draw(spriteBatch);

            //deleteButton.Draw(spriteBatch);

            foreach (Post post in posts)
            {
                post.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
