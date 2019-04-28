using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    class Pencil
    {
        internal void Write(Paper paper, string content)
        {
            paper.AddContent(content);
        }
    }
}
