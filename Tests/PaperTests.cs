using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PillarPencilDurabilityKata.Tests
{
    [TestFixture]
    class PaperTests
    {
        [Test]
        public void whenThePaperIsWrittenToWeCanReadIt()
        {
            Pencil pencil = new Pencil(100);
            Paper paper = new Paper();

            pencil.Write(paper, "I am being written to");

            Assert.AreEqual("I am being written to", paper.content);
        }
    }
}
