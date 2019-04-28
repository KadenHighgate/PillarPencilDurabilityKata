using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    public class Pencil
    {
        internal void Write(Paper paper, string content)
        {
            paper.content += content;
        }
    }
}
