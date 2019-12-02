using DanskeCodingTask.Infrastructure;
using DanskeCodingTask.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace DanskeCodingTask.Tests
{
    public class FileReaderTests
    {
        private IFileReader _fileReader;

        [SetUp]
        public void Setup()
        {
            _fileReader = new FileReader();
        }

        [Test]
        public void ReadInput_ReadTest1()
        {
            var sr = _fileReader.ReadInput("ReadInput_ReadTest1.txt");

            var result = new List<List<int>>()
            {
                new List<int>() { 1 },
                new List<int>() { 2, 3 },
                new List<int>() { 4, 5, 6 }
            };
            
            Assert.IsEmpty(sr.Errors);
            Assert.AreEqual(result, sr.Result);
        }

        [Test]
        public void ReadInput_FileNotFound()
        {
            var sr = _fileReader.ReadInput("file_do_not_exits.txt");
            Assert.That(sr.Errors, Has.Exactly(1).Property("Key").EqualTo(ErrorKey.FileNotFound));
        }

        [Test]
        public void ReadInput_InvalidFileContent()
        {
            var sr = _fileReader.ReadInput("ReadInput_InvalidFileContent.txt");
            Assert.That(sr.Errors, Has.Exactly(1).Property("Key").EqualTo(ErrorKey.InvalidFileContent));
        }

        [Test]
        public void ReadInput_WrongDataFormat()
        {
            var sr = _fileReader.ReadInput("ReadInput_WrongDataFormat.txt");
            Assert.That(sr.Errors, Has.Exactly(1).Property("Key").EqualTo(ErrorKey.WrongDataFormat));
        }

    }
}