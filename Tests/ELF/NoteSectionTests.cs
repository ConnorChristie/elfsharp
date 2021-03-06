using NUnit.Framework;
using ELFSharp.ELF.Sections;
using ELFSharp.ELF;

namespace Tests.ELF
{
    [TestFixture]
    public class NoteSectionTests
    {
        [Test]
        public void ShouldReadNoteName32()
        {
            var elf = ELFReader.Load(Utilities.GetBinary("hello32le"));
            var noteSection = (INoteSection)elf.GetSection(".note.ABI-tag");
            Assert.AreEqual("GNU", noteSection.NoteName);
        }

        [Test]
        public void ShouldReadNoteName64()
        {
            var elf = ELFReader.Load(Utilities.GetBinary("hello64le"));
            var noteSection = (INoteSection)elf.GetSection(".note.ABI-tag");
            Assert.AreEqual("GNU", noteSection.NoteName);
        }

        [Test]
        public void ShouldReadNoteType32()
        {
            var elf = ELFReader.Load<uint>(Utilities.GetBinary("hello32le"));
            var noteSection = (NoteSection<uint>)elf.GetSection(".note.ABI-tag");
            Assert.AreEqual(1, noteSection.NoteType);
        }

        [Test]
        public void ShouldReadNoteType64()
        {
            var elf = ELFReader.Load<ulong>(Utilities.GetBinary("hello64le"));
            var noteSection = (NoteSection<ulong>)elf.GetSection(".note.ABI-tag");
            Assert.AreEqual(1, noteSection.NoteType);
        }

        [Test]
        public void ShouldNotThrowOnCustomNote()
        {
            // Not all notes conform to the expected format that the NoteSection
            // class uses; this test validates that we can successfully parse a
            // binary containing such a section and retrieve the note, all without
            // throwing an exception.
            const string sectionName = ".note.custom";
            var elf = ELFReader.Load<uint>(Utilities.GetBinary("custom-note"));
            var noteSection = (NoteSection<uint>)elf.GetSection(sectionName);
            Assert.AreEqual(sectionName, noteSection.Name);
        }
    }
}

