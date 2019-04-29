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
            pencil = new Pencil(100, 8);
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
            paper = new Paper("I am");
            pencil.Write(paper, " Writing");

            Assert.AreEqual("I am Writing", paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenThePencilWritesItsDurabilityDegrades()
        {
            int startDurability = pencil.durability;
            pencil.Write(paper, "0123456789ABCDEF");
            int endDurability = pencil.durability;

            Assert.Less(endDurability, startDurability);
        }

        [Test]
        [Category("pass")]
        public void WhenALowerCaseLetterIsWrittenItDegradesDurabilityByOne()
        {
            int startDurability = pencil.durability;
            pencil.Write(paper, "u");

            Assert.AreEqual(startDurability, pencil.durability + 1);
        }

        [Test]
        [Category("pass")]
        public void WhenAUpperCaseLetterIsWrittenItDegradesDurabilityByTwo()
        {
            int startDurability = pencil.durability;
            pencil.Write(paper, "I");

            Assert.AreEqual(startDurability, pencil.durability + 2);
        }

        [Test]
        [Category("pass")]
        public void WhenPencilRunsOutOfDurabilityCharactersStopBeingWritten()
        {
            pencil = new Pencil(10, 8);
            string content = "OceanViews";
            string expectedContent = "OceanVie  ";

            pencil.Write(paper, content);

            Assert.AreEqual(expectedContent, paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilIsSharpenedItReturnsToItsMaxDurability()
        {
            pencil = new Pencil(10, 8);
            pencil.Write(paper, "12345");
            pencil.Sharpen();
            Assert.AreEqual(10, pencil.durability);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilIsSharpenedItsLengthReduces()
        {
            pencil = new Pencil(10, 8);
            pencil.Sharpen();
            Assert.AreEqual(7, pencil.length);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilIsSharpenedItsDurabilityIsReset()
        {
            pencil = new Pencil(10, 8);
            pencil.Write(paper, "hello");
            pencil.Sharpen();

            Assert.AreEqual(10, pencil.durability);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilErasesTextItReplacesTextWithWhiteSpace()
        {
            paper.AddContent("Now You See Me");
            pencil.Erase(paper, "See");

            Assert.IsTrue(!paper.content.Contains("See"));
        }

    }
}
