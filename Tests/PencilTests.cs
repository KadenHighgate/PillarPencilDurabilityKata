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
            pencil = new Pencil(100, 8, 100);
            paper = new Paper();
        }

        [Test]
        [Category("pass")]
        public void whenWeWriteAStringThatStringIsAppliedToPaperAccurately()
        {

            paper.AddContent(pencil.Write("Writing"));
            Assert.AreEqual("Writing", paper.content);
        }

        [Test]
        [Category("pass")]
        public void whenWeWriteAStringThatStringIsAddedToPaperCurrentContent()
        {
            paper = new Paper("I am");
            paper.AddContent(pencil.Write(" Writing"));

            Assert.AreEqual("I am Writing", paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenThePencilWritesItsDurabilityDegrades()
        {
            int startDurability = pencil.durability;
            paper.AddContent(pencil.Write("0123456789ABCDEF"));
            int endDurability = pencil.durability;

            Assert.Less(endDurability, startDurability);
        }

        [Test]
        [Category("pass")]
        public void WhenALowerCaseLetterIsWrittenItDegradesDurabilityByOne()
        {
            int startDurability = pencil.durability;
            paper.AddContent(pencil.Write("u"));

            Assert.AreEqual(startDurability, pencil.durability + 1);
        }

        [Test]
        [Category("pass")]
        public void WhenAUpperCaseLetterIsWrittenItDegradesDurabilityByTwo()
        {
            int startDurability = pencil.durability;
            paper.AddContent(pencil.Write("I"));

            Assert.AreEqual(startDurability, pencil.durability + 2);
        }

        [Test]
        [Category("pass")]
        public void WhenPencilRunsOutOfDurabilityCharactersStopBeingWritten()
        {
            pencil = new Pencil(10, 8);
            string content = "OceanViews";
            string expectedContent = "OceanVie  ";

            paper.AddContent(pencil.Write(content));

            Assert.AreEqual(expectedContent, paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilIsSharpenedItReturnsToItsMaxDurability()
        {
            pencil = new Pencil(10, 8);
            paper.AddContent(pencil.Write("12345"));
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
            paper.AddContent(pencil.Write("hello"));
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

        [Test]
        [Category("pass")]
        public void WhenAPencilErasesTextItReplacesLastOccurranceOfText()
        {
            paper.AddContent("Now You See Me, Now You Don't");
            pencil.Erase(paper, "You");

            Assert.AreEqual("Now You See Me, Now     Don't", paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilErasesTextItReplacesTextWithinAWord()
        {
            paper.AddContent("Temptations, Organizations, Occupations");
            pencil.Erase(paper, "ation");

            Assert.AreEqual("Temptations, Organizations, Occup     s", paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilErasesItDegradesByOne()
        {
            pencil = new Pencil(100, 8, 5);
            paper.AddContent("Erase");
            pencil.Erase(paper, "Erase");

            Assert.AreEqual(0, pencil.eraserDurability);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilErasesRepeatedTextInASingleWordEraseTheLastOccurance()
        {
            pencil = new Pencil(100, 8, 5);
            paper.AddContent("BamBam");
            pencil.Erase(paper, "Bam");

            Assert.AreEqual("Bam   ", paper.content);
        }

        [Test]
        [Category("pass")]
        public void WhenAPencilErasesBeyondItsDurabilityDoNotRemoveRemainingText()
        {
            pencil = new Pencil(100, 8, 5);
            paper.AddContent("What Remains");
            pencil.Erase(paper, "What Remains");

            Assert.AreEqual("What Re     ", paper.content);
        }

        [Test]
        [Category("pass")]
        [TestCase("Change Me", "Change", "Morph", "Morph  Me")]
        [TestCase("Change Me Please", "Me", "Us", "Change Us Please")]
        [TestCase("Change MePlease", "Please", "Immediately", "Change MeImmediately")]

        public void WhenAPencilErasesTextItCanEditTheWhiteSpace(string a, string b, string c, string d)
        {
            paper = new Paper(a);
            pencil.Erase(paper, b);
            paper.EditContent(pencil.Write(c));

            Assert.AreEqual(d, paper.content);
        }

    }
}
