using System;

namespace ELFSharp
{
    public interface IELF
    {
        Endianess Endianess { get; }
        Class Class { get; }
        FileType Type { get; }
        Machine Machine { get; }
        bool HasProgramHeader { get; }
        bool HasSectionHeader { get; }
        bool HasSectionsStringTable { get; }
        // TODO: programheaders
        IStringTable SectionsStringTable { get; }
        // TODO: sections

    }
}
