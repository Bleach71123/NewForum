using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Forum
{
    class PostButton
    {
        Texture2D t;
        Rectangle r;
        SpriteFont font;
        Color color = Color.LightGray;
        bool clickReleaseReady;

        public PostButton(GraphicsDevice g, SpriteFont font)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            r = new Rectangle(10, 10, 70, 25);
            this.font = font;
            clickReleaseReady = false;
        }

        public void Update(GameTime gt)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Mouse.GetState().X > 10 && Mouse.GetState().X < 80 && Mouse.GetState().Y > 10 && Mouse.GetState().Y < 35)
                {
                    color = Color.Gray;
                    clickReleaseReady = true;
                }   
            }
            else
            {
                color = Color.LightGray;
                clickReleaseReady = false;
            }
            
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, r, color);
            b.DrawString(font, "Post", new Vector2(27, 13), Color.Black);
        }

        public bool NewPost()
        {
            if (clickReleaseReady && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                if (Mouse.GetState().X > 10 && Mouse.GetState().X < 80 && Mouse.GetState().Y > 10 && Mouse.GetState().Y < 35)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
