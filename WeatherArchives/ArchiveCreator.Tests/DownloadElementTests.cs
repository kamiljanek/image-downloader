using FluentAssertions;
using Flymet;
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
            var dict = new Dictionary<string, string>()
            {
                { @"https://www.chmi.cz/files/portal/docs/meteo/om/evropa/preba/preba.gif", @"synoptic_map.gif" }
            };
            //act
            result.AddElement(synoptic);

            //assert
            result.Elements.Should().BeEquivalentTo(dict);
        }
        [Fact()]
        public void AddElementTest_ForAddFlymetFiles_UpdatesProperty()
        {
            //arrange
            var result = new DownloadElement();
            var synoptic = new SynopticForecastFactory();
            var fileOperation = new FileOperation();
            var flymetForecastFactory = new FlymetForecastFactory(fileOperation);

            //act
            result.AddElement(flymetForecastFactory.CreateWeatherForecasts());

            //assert
            result.Elements.Should().NotBeEmpty();
        }
    }
}