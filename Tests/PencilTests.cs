using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PillarPencilDurabilityKata.Tests
{
    [TestFixture]
    class PencilTests
    {



        [Test]
        [Category("pass")]
        public void whenWeWriteAStringThatStringIsOnPaperAccurately()
        {
            Pencil pencil = new Pencil();
            Paper paper = new Paper();
            pencil.Write(paper, "Writing");

            Assert.AreEqual("Writing", paper.content);
        }

        [Test]
        [Category("pass")]
        public void whenWeWriteAStringThatStringIsAddedToPaperCurrentContent()
        {
            Pencil pencil = new Pencil();
            Paper paper = new Paper("I am");
            pencil.Write(paper, " Writing");

            Assert.AreEqual("I am Writing", paper.content);
        }
    }
}
