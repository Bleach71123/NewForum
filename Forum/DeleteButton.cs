using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Forum
{
    class DeleteButton
    {
        Texture2D t;
        Rectangle r;
        SpriteFont font;

        public DeleteButton(GraphicsDevice g, SpriteFont font)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            r = new Rectangle(700, 400, 70, 25);
            this.font = font;
        }

        public void Update(GameTime gt)
        {

        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, r, Color.LightGray);
            b.DrawString(font, "Delete", new Vector2(710, 405), Color.Black);
        }
    }
}
