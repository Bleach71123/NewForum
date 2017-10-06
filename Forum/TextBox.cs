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
    class TextBox
    {
        string text = ""; //Start with no text
        int cursorPos = 0;
        //These are set in the constructor:
        SpriteFont font;
        Rectangle backRect;
        Texture2D t;
        int lines = 1;

        bool textReady = true;
        Keys hold; 

        public TextBox(GraphicsDevice g, SpriteFont font)
        {
            t = new Texture2D(g, 1, 1);
            t.SetData(new Color[] { Color.White });
            backRect = new Rectangle(100, 100, 100, 30);
            this.font = font;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(t, backRect, Color.LightGray);
            b.DrawString(font, WrapText(text), new Vector2(100, 100), Color.Black);
        }

        public void Update(GameTime gt)
        {
            /*Keys[] keys = Keyboard.GetState().GetPressedKeys();
            Keys hold = Keys.RightAlt;
            if (keys.Length > 0)
                hold = keys[0];
            for (int i = 1; i < keys.Length; i++)
            {
                if (keys[i] == hold)
                    keys.SetValue(Keys.RightAlt, i);
                else
                    hold = keys[i];
            }
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] != Keys.RightAlt)
                {
                    if (keys[i] == Keys.Back)
                        BackSpace();
                    else
                    {
                        Char[] keyInput = ConvertKeyToChar(keys[i], false).ToCharArray();
                        CharEntered(keyInput[0]);
                    }
                }
            }*/
            if (Keyboard.GetState().IsKeyUp(hold))
                textReady = true;
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            if (keys.Length > 0)
            {
                if (hold != keys[0] || textReady)
                {
                    if (keys[0] == Keys.Back)
                        BackSpace();
                    else if (keys[0] != Keys.LeftShift && keys[0] != Keys.RightShift)
                    {
                        Char[] keyInput = ConvertKeyToChar(keys[0], Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift)).ToCharArray();
                        CharEntered(keyInput[0]);
                        //shift = false;
                    }
                    hold = keys[0];
                    textReady = false;
                }
            }

            backRect.Height = (int)font.MeasureString("O").Y * lines;

        }

        private String WrapText(string text)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float linewidth = 0f;
            float maxLine = 80f;
            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words)
            {
                lines = 1;
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
                    lines++;
                }
            }
            return sb.ToString();
        }

        public void CharEntered(char c)
        {
            string newText = text.Insert(cursorPos, c.ToString()); //Insert the char
            //Check if the text width is shorter than the back rectangle
           // if (font.MeasureString(newText).X < backRect.Width)
           // {
                text = newText; //Set the text
                cursorPos++; //Move the text cursor
                             // }
            WrapText(text);
        }

        public void BackSpace()
        {
            if (text.Length > 0)
            {
                text = text.Remove(text.Length - 1);
                cursorPos--;
            }
        }

        public String ConvertKeyToChar(Keys key, bool shift)
        {
            switch (key)
            {
                case Keys.Space: return " ";

                // Escape Sequences 
                case Keys.Enter: return "\n";                         // Create a new line 
                case Keys.Tab: return "\t";                           // Tab to the right 

                // D-Numerics (strip above the alphabet) 
                case Keys.D0: return shift ? ")" : "0";
                case Keys.D1: return shift ? "!" : "1";
                case Keys.D2: return shift ? "@" : "2";
                case Keys.D3: return shift ? "#" : "3";
                case Keys.D4: return shift ? "$" : "4";
                case Keys.D5: return shift ? "%" : "5";
                case Keys.D6: return shift ? "^" : "6";
                case Keys.D7: return shift ? "&" : "7";
                case Keys.D8: return shift ? "*" : "8";
                case Keys.D9: return shift ? "(" : "9";

                // Numpad 
                case Keys.NumPad0: return "0";
                case Keys.NumPad1: return "1";
                case Keys.NumPad2: return "2";
                case Keys.NumPad3: return "3";
                case Keys.NumPad4: return "4";
                case Keys.NumPad5: return "5";
                case Keys.NumPad6: return "6";
                case Keys.NumPad7: return "7";
                case Keys.NumPad8: return "8";
                case Keys.NumPad9: return "9";
                case Keys.Add: return "+";
                case Keys.Subtract: return "-";
                case Keys.Multiply: return "*";
                case Keys.Divide: return "/";
                case Keys.Decimal: return ".";

                // Alphabet 
                case Keys.A: return shift ? "A" : "a";
                case Keys.B: return shift ? "B" : "b";
                case Keys.C: return shift ? "C" : "c";
                case Keys.D: return shift ? "D" : "d";
                case Keys.E: return shift ? "E" : "e";
                case Keys.F: return shift ? "F" : "f";
                case Keys.G: return shift ? "G" : "g";
                case Keys.H: return shift ? "H" : "h";
                case Keys.I: return shift ? "I" : "i";
                case Keys.J: return shift ? "J" : "j";
                case Keys.K: return shift ? "K" : "k";
                case Keys.L: return shift ? "L" : "l";
                case Keys.M: return shift ? "M" : "m";
                case Keys.N: return shift ? "N" : "n";
                case Keys.O: return shift ? "O" : "o";
                case Keys.P: return shift ? "P" : "p";
                case Keys.Q: return shift ? "Q" : "q";
                case Keys.R: return shift ? "R" : "r";
                case Keys.S: return shift ? "S" : "s";
                case Keys.T: return shift ? "T" : "t";
                case Keys.U: return shift ? "U" : "u";
                case Keys.V: return shift ? "V" : "v";
                case Keys.W: return shift ? "W" : "w";
                case Keys.X: return shift ? "X" : "x";
                case Keys.Y: return shift ? "Y" : "y";
                case Keys.Z: return shift ? "Z" : "z";

                // Oem 
                case Keys.OemOpenBrackets: return shift ? "{" : "[";
                case Keys.OemCloseBrackets: return shift ? "}" : "]";
                case Keys.OemComma: return shift ? "<" : ",";
                case Keys.OemPeriod: return shift ? ">" : ".";
                case Keys.OemMinus: return shift ? "_" : "-";
                case Keys.OemPlus: return shift ? "+" : "=";
                case Keys.OemQuestion: return shift ? "?" : "/";
                case Keys.OemSemicolon: return shift ? ":" : ";";
                case Keys.OemQuotes: return shift ? "\"" : "'";
                case Keys.OemPipe: return shift ? "|" : "\\";
                case Keys.OemTilde: return shift ? "~" : "`";
            }

            return string.Empty;
        }
    }
}
