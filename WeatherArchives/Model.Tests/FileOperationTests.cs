using Xunit;

namespace Model.Tests
{
    public class FileOperationTests
    {
        [Fact()]
        public void FileReaderTest_ForReadFromJsonFile_ReturnsString()
        {
            //arrange
            var fileOperation = new FileOperation();
            var fileName = "fileOperationTest.json";
            //act
            var message = fileOperation.FileReader<string>(fileName);
            //assert
            Assert.Equal("test message", message);
        }
    }
}