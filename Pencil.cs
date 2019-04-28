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
            foreach (char ch in content)
            {
                if (!Char.IsWhiteSpace(ch))
                    durability -= 1;
            }

            paper.AddContent(content);
        }
    }
}
