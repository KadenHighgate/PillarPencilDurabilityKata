using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    class Pencil
    {
        internal int durability;

        public Pencil(int durability)
        {
            this.durability = durability;
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
    }
}
