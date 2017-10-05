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

        public PostButton(GraphicsDevice g, SpriteFont font)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            r = new Rectangle(10, 10, 70, 25);
            this.font = font;
        }

        public void Update(GameTime gt)
        {

        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, r, Color.LightGray);
            b.DrawString(font, "Post", new Vector2(27, 13), Color.Black);
        }
    }
}
