using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Forum
{
    
    class Post
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

        public int num;

        public Post(GraphicsDevice g, String author, String post, SpriteFont font, Color color, int num)
        {
            this.author = author;
            this.post = post;

            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            r = new Rectangle(10 + (10 * num) + (200 * num), 60, 200, 300);
            textPosition = new Vector2(15 + (15 * num) + (200 * num), 70);

            this.font = font;
            this.color = color;

            respond = new RespondButton(g, font, textPosition);
            delete = new DeleteButton(g, font, textPosition);

            this.num = num;
        }

        public void Update(GameTime gt)
        {
            respond.Update(gt);
            delete.Update(gt);

            r = new Rectangle(10 + (200 * num), 60, 200, 300);
            textPosition = new Vector2(15 + (200 * num), 70);
            respond.setPosition(textPosition);
            delete.setPosition(textPosition);
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, r, color);
           
            b.DrawString(font, "Author: " + author, textPosition, Color.Black);
            //post = WrapText(post);
            b.DrawString(font, WrapText(post), textPosition + new Vector2(5, 25), Color.Black);

            respond.Draw(b);
            delete.Draw(b);
        }

        private String WrapText(string text)
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

        public bool deletePost()
        {
            return delete.deletePressed();
        }
    }
}
