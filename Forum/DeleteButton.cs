﻿using System;
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
        Color color = Color.LightGray;
        bool clickReleaseReady;

        Vector2 v2;

        public DeleteButton(GraphicsDevice g, SpriteFont font, Vector2 v2)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            this.v2 = v2 + new Vector2(128, 250);
            r = new Rectangle((int)this.v2.X - 10, (int)this.v2.Y - 3, 70, 25);
            this.font = font;
            clickReleaseReady = false;
            
        }

        public void setPosition(Vector2 position)
        {
            v2 = position + new Vector2(128, 250);
            r = new Rectangle((int)this.v2.X - 10, (int)this.v2.Y - 3, 70, 25);
        }

        public bool deletePressed()
        {
            if (clickReleaseReady && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                clickReleaseReady = false;
                if (Mouse.GetState().X > v2.X - 3 && Mouse.GetState().X < v2.X - 10 + 70 && Mouse.GetState().Y > v2.Y - 3 && Mouse.GetState().Y < v2.Y - 3 + 25)
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(GameTime gt)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Mouse.GetState().X > v2.X - 3 && Mouse.GetState().X < v2.X - 10 + 70 && Mouse.GetState().Y > v2.Y - 3 && Mouse.GetState().Y < v2.Y - 3 + 25)
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
            b.Draw(t, r, color);
            b.DrawString(font, "Delete", v2, Color.Black);
        }
    }
}
