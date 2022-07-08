using AutoFixture.Xunit2;
using AutoFixture;
using AutoFixture.AutoMoq;
using Model;
using Moq;
using Xunit;
using System.IO.Abstractions;
using System.Net.Mail;
using FluentAssertions;
using Newtonsoft.Json;
using System.Security.Principal;

namespace Model.Tests
{
    public class FileOperationTests
    {
        [Fact]
        public void FileReaderTest_ForReadFromJsonFile_ReturnsUserGmail()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mock = fixture.Freeze<Mock<IFileSystem>>();
            var sut = fixture.Create<FileOperation>();
            var userGmail = fixture.Build<UserGmail>()
                .With(x => x.GmailAddress, "asdfasf@gmail.com").Create();
            var userGmailSerialised = JsonConvert.SerializeObject(userGmail);
            var filePath = fixture.Create<string>();
            mock.Setup(m => m.File.ReadAllText(filePath)).Returns(userGmailSerialised);

            //act
            var expectedUserGmail = sut.FileReader<UserGmail>(filePath);
            
            //assert
            expectedUserGmail.Should().BeEquivalentTo(userGmail);
            
        }
    }
}