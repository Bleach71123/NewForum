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
        public Rectangle r;
        public int x;
        SpriteFont font;
        Color color;

        String author;
        String post;
        Vector2 textPosition;
        RespondButton respond;
        DeleteButton delete;

        //Response response;
        GraphicsDevice g;

        public int num;

        public Post previous, next;

        public Post(GraphicsDevice g, String author, String post, SpriteFont font, Color color, int num, Post previous)
        {
            x = 200;
            this.author = author;
            this.post = post;

            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });

            this.previous = previous;
            if (previous == null)
            {
                r = new Rectangle(10 + (x * num), 60, 200, 300);
                textPosition = new Vector2(15 + (x * num), 70);
            }
            else
            {
                r = new Rectangle(previous.r.X, previous.r.Y + previous.r.Height, previous.r.Width, previous.r.Height);
                textPosition = new Vector2(15 + (15 * previous.num) + (200 * previous.num), 70 + previous.r.Height);
            }

            this.font = font;
            this.color = color;

            respond = new RespondButton(g, font, textPosition);
            delete = new DeleteButton(g, font, textPosition);

            this.num = num;

            this.g = g;
        }

        public void Update(GameTime gt)
        {
            respond.Update(gt);
            delete.Update(gt);

            if (previous == null)
            {
                r = new Rectangle(10 + (x * num), 60, 200, 300);
                textPosition = new Vector2(15 + (x * num), 70);
            }
            else
            {
                r = new Rectangle(previous.r.X, previous.r.Y + previous.r.Height, previous.r.Width, previous.r.Height);
                textPosition = new Vector2(15 + (15 * previous.num) + (x * previous.num), 70 + previous.r.Height);
            }

            respond.setPosition(textPosition);
            delete.setPosition(textPosition);

            Post hold;
            if (respond.respondPressed()){
                hold = this;
                while (hold.next != null)
                    hold = hold.next;
                hold.next = new Post(g, "Chickman", "This is another response. This is another response. This is another response. This is another response.", font, color, num, hold);
            }

            hold = next;
            while (hold != null)
            {
                hold.Update(gt);
                hold = hold.next;
            }
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, r, color);
           
            b.DrawString(font, "Author: " + author, textPosition, Color.Black);
            //post = WrapText(post);
            b.DrawString(font, WrapText(post), textPosition + new Vector2(5, 25), Color.Black);

            respond.Draw(b);
            delete.Draw(b);

            if (next != null)
            {
                Post hold = next;
                while (hold != null)
                {
                    hold.Draw(b);
                    hold = hold.next;
                }
            }
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
