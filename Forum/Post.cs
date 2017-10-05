using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Forum
{
    
    class Post
    {
        String author;
        String post;
        RespondButton respond;
        DeleteButton delete;

        public Post(String author, String post)
        {
            this.author = author;
            this.post = post;
        }
    }
}
