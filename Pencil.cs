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
            string[] contentArray;

            contentArray = paper.content.Split(' ');
            for (int i = contentArray.Length - 1; i >= 0; i--)
            {
                if (contentArray[i].Contains(eraseContent))
                {
                    int startIndex = contentArray[i].LastIndexOf(eraseContent);
                    int endIndex = startIndex + eraseLength - 1;

                    for (int j = endIndex; j >= startIndex && j <= endIndex; j--)
                    {
                        if (eraserDurability >= 0)
                        {
                            contentArray[i] = contentArray[i].Remove(j, 1);
                            contentArray[i] = contentArray[i].Insert(j, " ");
                            eraserDurability -= 1;
                        }
                    }
                    break;
                }
            }
            paper.content = string.Join(" ", contentArray);
        }
    }
}
