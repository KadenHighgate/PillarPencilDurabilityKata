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
        public int lastEditIndex = 0;

        public Paper()
        {
            content = string.Empty;
        }

        public Paper(string startingContent)
        {
            content = startingContent;
        }

        public void AddContent(string newContent)
        {
            content += newContent;
        }

        public void EditContent(string newContent)
        {
            string edittedContent = string.Empty;
            for (int i = lastEditIndex; i < lastEditIndex + newContent.Length; i++)
            {
                edittedContent += newContent[i];
            }
            content = content.Remove(lastEditIndex, newContent.Length);
            content = content.Insert(lastEditIndex, edittedContent);
        }
    }
}
