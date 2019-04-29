using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    class Pencil
    {
        public int durability;
        int maxDurability;
        public int length;

        public Pencil(int maxDurability, int length)
        {
            durability = maxDurability;
            this.maxDurability = maxDurability;
            this.length = length;

        }

        internal void Write(Paper paper, string content)
        {
            string writtenContent = string.Empty;
            foreach (char ch in content)
            {
                if (!Char.IsWhiteSpace(ch))
                {
                    if (Char.IsUpper(ch) && durability > 1)
                    {
                        durability -= 2;
                        writtenContent += ch;
                    }
                    else if (durability > 0)
                    {
                        durability -= 1;
                        writtenContent += ch;
                    }
                    else if (durability <= 0)
                    {
                        writtenContent += ' ';
                    }
                }
                else
                {
                    writtenContent += ch;
                }
            }
            paper.AddContent(writtenContent);
        }

        internal void Sharpen()
        {
            durability = maxDurability;
            if (length > 0)
                length -= 1;
        }

        internal void Erase(Paper paper, string eraseContent)
        {
            int eraseLength = eraseContent.Length;
            string blankSpaces = string.Empty;

            for (int i = 0; i < eraseLength; i++)
            {
                blankSpaces += " ";
            }
            paper.content = paper.content.Replace(eraseContent, blankSpaces);
        }
    }
}
