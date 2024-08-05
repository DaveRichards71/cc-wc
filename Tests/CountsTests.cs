using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace Logic.Tests
{
    [TestFixture]
    public class CountsTests
    {
        private IFileSystem _fileSystem;
        private Counts _counts;

        [SetUp]
        public void Setup()
        {
            _fileSystem = new MockFileSystem();
            _counts = new Counts(_fileSystem);
        }

        [Test]
        public void CountBytes_ShouldReturnCorrectByteCount_ForGivenFile()
        {
            // Arrange
            var testFileName = @"c:\testfile.txt";
            var testFileContent = "Hello, World!";
            _fileSystem.File.WriteAllText(testFileName, testFileContent);
            var expectedByteCount = testFileContent.Length; // Assuming ASCII encoding

            // Act
            var actualByteCount = _counts.CountBytes(testFileName);

            // Assert
            Assert.That(actualByteCount, Is.EqualTo(expectedByteCount), $"Expected {actualByteCount} to be {expectedByteCount}");
        }

        [Test]
        public void Counts_CountBytes_CountsBytesInFile()
        {
            // Arrange
            string file1 = @"c:\myfile.txt";
            string file2 = @"c:\demo\jQuery.js";
            string file3 = @"c:\demo\image.gif";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { file1, new MockFileData("Testing is meh.") },
                { file2, new MockFileData("some js") },
                { file3, new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
            });

            var counts = new Counts(fileSystem);

            // Act
            var count = counts.CountBytes(file3);

            // Assert
            Assert.That(count, Is.EqualTo(4), $"Expected {count} to be {4}");
        }

        [Test]
        public void Counts_CountLines_CountsLinesInFile()
        {
            // Arrange
            string file1 = @"c:\myfile.txt";
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { file1, new MockFileData("Testing is meh.") }
            });

            var counts = new Counts(fileSystem);

            // Act
            var count = counts.CountLines(file1);

            // Assert
            Assert.That(count, Is.EqualTo(1), $"Expected {count} to be {1}");
        }

        
    }
}