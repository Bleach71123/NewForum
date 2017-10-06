using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum
{
    class Response
    {
        Texture2D t;
        Rectangle r;
        SpriteFont font;
        Color color;

        String author;
        String post;
        Vector2 textPosition;
        RespondButton respond;
        DeleteButton delete;

        public Response previous, next;

        public Response(GraphicsDevice g, String author, String post, SpriteFont font, Color color, Post previous)
        {
            this.author = author;
            this.post = post;

            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            r = new Rectangle(previous.r.X, previous.r.Y + previous.r.Height, previous.r.Width, previous.r.Height);
            textPosition = new Vector2(15 + (15 * previous.num) + (200 * previous.num), 70 + previous.r.Height);

            this.font = font;
            this.color = color;

            respond = new RespondButton(g, font, textPosition);
        }


        public void Update(GameTime gt)
        {
            respond.Update(gt);
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, r, color);

            b.DrawString(font, "Author: " + author, textPosition, Color.Black);
            //post = WrapText(post);
            b.DrawString(font, WrapText(post), textPosition + new Vector2(5, 25), Color.Black);

            respond.Draw(b);
        }

        public String WrapText(string text)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float linewidth = 0f;
            float maxLine = 170f;
            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = font.MeasureString(word);
                if (linewidth + size.X < maxLine)
                {
                    sb.Append(word + " ");
                    linewidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    linewidth = size.X + spaceWidth;
                }
            }
            return sb.ToString();
        }

    }
}
