using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Forum
{
    class DeleteButton
    {
        Texture2D t;

        public DeleteButton(GraphicsDevice g)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
        }

        public void Update(GameTime gt)
        {

        }

        public void Draw(SpriteBatch b)
        {
            
        }
    }
}
