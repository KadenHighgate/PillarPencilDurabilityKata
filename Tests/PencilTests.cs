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
        Pencil pencil;
        Paper paper;

        [SetUp]
        public void InitializeWritingSpace()
        {
            pencil = new Pencil(10);
            paper = new Paper();
        }

        [Test]
        [Category("pass")]
        public void whenWeWriteAStringThatStringIsAppliedToPaperAccurately()
        {

            pencil.Write(paper, "Writing");
            Assert.AreEqual("Writing", paper.content);
        }

        [Test]
        [Category("pass")]
        public void whenWeWriteAStringThatStringIsAddedToPaperCurrentContent()
        {
            Pencil pencil = new Pencil(10);
            Paper paper = new Paper("I am");
            pencil.Write(paper, " Writing");

            Assert.AreEqual("I am Writing", paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenThePencilWritesItsDurabilityDegrades()
        {
            int startDurability = pencil.durability;
            pencil.Write(paper, "123456789101112");
            int endDurability = pencil.durability;

            Assert.Less(endDurability, startDurability);
        }
    }
}
