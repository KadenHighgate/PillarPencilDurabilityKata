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
        public int lastEditIndex;

        public Paper()
        {
            content = string.Empty;
        }

        public Paper(string startingContent)
        {
            content = startingContent;
            lastEditIndex = 0;
        }

        public void AddContent(string newContent)
        {
            content += newContent;
        }

        public void EditContent(string newContent)
        {
            string edittedContent = string.Empty;
            for (int i = 0; i < newContent.Length; i++)
            {
                edittedContent += newContent[i];
            }

            if (lastEditIndex + newContent.Length <= content.Length)
            {
                content = content.Remove(lastEditIndex, newContent.Length);
                content = content.Insert(lastEditIndex, edittedContent);
            }
            else
            {
                content = content.Remove(lastEditIndex);
                content += edittedContent;
            }

        }
    }
}
