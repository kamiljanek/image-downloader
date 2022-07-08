using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Flymet.Entities;
using Model;
using SynopticMap;
using Xunit;

namespace ArchiveCreator.Tests
{
    public class DownloadElementTests
    {
        [Fact()]
        public void AddElementTest_ForAddSynoptic_UpdatesProperty()
        {
            //arrange
            var result = new DownloadElement();
            var synoptic = new SynopticForecastFactory();

            //act
            result.AddElement(synoptic);

            //assert
            result.Elements.Should().NotBeEmpty();
        }
        [Fact()]
        public void AddElementTest_ForAddFlymetForecasts_UpdatesProperty()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mock = fixture.Create<DownloadElement>();

            fixture.Register<IGenerate>(() => fixture.Create<FlymetForecast>());

            var flymetForecasts = fixture.CreateMany<IGenerate>(3).ToList();

            //act
            mock.AddElement(flymetForecasts);

            //assert
            mock.Elements.Should().NotBeEmpty();

        }
    }
}