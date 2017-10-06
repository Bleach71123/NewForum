using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum
{
    class ScrollBar
    {
        float width;
        int height;
        Texture2D t;
        Rectangle r;

        Color color;
        bool clickReleaseReady;

        public ScrollBar(GraphicsDevice g)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            r = new Rectangle(0, 400, 100, 10);
            clickReleaseReady = false;
        }

        public void Update(GameTime gt)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Mouse.GetState().X > 0 && Mouse.GetState().X < 100 && Mouse.GetState().Y > 400 && Mouse.GetState().Y < 410)
                {
                    color = Color.Gray;
                    clickReleaseReady = true;
                }
            }
            else
            {
                color = Color.LightGray;
            }

        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, new Rectangle(0, 400, 700, 10), color);
            b.Draw(t, r, color);
        }
    }
}
