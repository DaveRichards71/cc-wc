using System.IO.Abstractions;

namespace Logic
{
    public class Counts : ICounts
    {
        readonly IFileSystem fileSystem;

        public Counts(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }
        public Counts() : this(fileSystem: new FileSystem())
        {        
        }

        public int CountBytes(string filename)
        {
            return fileSystem.File.ReadAllBytes(filename).Length;
        }
    }
}
