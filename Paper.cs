using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurabilityKata
{
    class Paper
    {
        public string content;
        public Paper()
        {
            content = string.Empty;
        }

        public Paper(string startingContent)
        {
            content = startingContent;
        }
    }
}
