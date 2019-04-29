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
            string[] contentArray = paper.content.Split(' ');
            string[] eraseContentArray = eraseContent.Split(' ');


            for (int i = eraseContentArray.Length - 1; i >= 0; i--)
            {
                for (int j = contentArray.Length - 1; j >= 0; j--)
                    if (contentArray[j].Contains(eraseContentArray[i]))
                    {
                        int startIndex = contentArray[j].LastIndexOf(eraseContentArray[i]);
                        int endIndex = startIndex + eraseContentArray[i].Length - 1;

                        for (int k = endIndex; k >= startIndex && k <= endIndex; k--)
                        {
                            if (eraserDurability > 0)
                            {
                                contentArray[j] = contentArray[j].Remove(k, 1);
                                contentArray[j] = contentArray[j].Insert(k, " ");
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
