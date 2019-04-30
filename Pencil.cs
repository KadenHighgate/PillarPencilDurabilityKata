using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    class Pencil
    {
        int maxDurability;
        int maxEraserDurability;
        public int durability;
        public int length;
        public int eraserDurability;


        public Pencil(int maxDurability, int length)
        {
            durability = maxDurability;
            this.maxDurability = maxDurability;
            this.length = length;

        }

        public Pencil(int maxDurability, int length, int maxEraserDurability) : this(maxDurability, length)
        {
            eraserDurability = this.maxEraserDurability = maxEraserDurability;
        }

        internal string Write(string content)
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
            return writtenContent;
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

            int startIndex = paper.content.LastIndexOf(eraseContent);
            if (startIndex < 0)
                return;
            int endIndex = startIndex + eraseContent.Length - 1;

            for (int k = endIndex; k >= startIndex && k <= endIndex; k--)
            {
                if (eraserDurability > 0)
                {
                    paper.content = paper.content.Remove(k, 1);
                    paper.content = paper.content.Insert(k, " ");
                    eraserDurability -= 1;
                    paper.lastEditIndex = k;
                }
            }
        }
    }
}
