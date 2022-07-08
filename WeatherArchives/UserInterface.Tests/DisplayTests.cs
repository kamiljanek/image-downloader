using AutoFixture;
using AutoFixture.AutoMoq;
using Flymet.Entities;
using Model;
using Moq;
using Xunit;

namespace UserInterface.Tests
{
    public class DisplayTests
    {
        [Fact()]
        public void CaseMenuOptionsTest_ForSelectFlymetUrlElement_VerifyFileGeneratorCalledOnce()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockFileOperation = fixture.Freeze<Mock<IFileOperation>>();
            var sut = fixture.Create<Display>();
            List<FlymetUrlElement> flymetUrlElements = fixture.CreateMany<FlymetUrlElement>(2).ToList();
            List<FlymetUrlElement> selectedFlymetUrlElements = new List<FlymetUrlElement>()
            {
                new ("2", "asda", "asda")
            };
            flymetUrlElements.AddRange(selectedFlymetUrlElements);
            string filePath = fixture.Create<string>();

            var input = new StringReader("2");
            Console.SetIn(input);

            //act
            sut.CaseMenuOptions(filePath, flymetUrlElements);

            //assert
            mockFileOperation.Verify(m => m.FileGenerator(filePath, selectedFlymetUrlElements), Times.Once);
        }
    }
}