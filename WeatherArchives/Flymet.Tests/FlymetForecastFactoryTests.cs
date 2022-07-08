using Xunit;
using Flymet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using System.IO.Abstractions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using Flymet.Entities;
using Flymet.ManualData;

namespace Flymet.Tests
{
    public class FlymetForecastFactoryTests
    {
        [Fact()]
        public void CreateWeatherForecastsTest_ForAdded2FlymetUrlElements_ShouldReturn8FlymetForecasts()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mock = fixture.Freeze<Mock<IFileOperation>>();
            var sut = fixture.Create<FlymetForecastFactory>();
            var flymetUrlElements = fixture.CreateMany<FlymetUrlElement>(2).ToList();

            mock.Setup(m => m.FileReader<List<FlymetUrlElement>>(FlymetConstValue.RegionFilePath)).Returns(flymetUrlElements);
            mock.Setup(m => m.FileReader<List<FlymetUrlElement>>(FlymetConstValue.ProductFilePath)).Returns(flymetUrlElements);
            mock.Setup(m => m.FileReader<List<FlymetUrlElement>>(FlymetConstValue.TimeFilePath)).Returns(flymetUrlElements);
            //act
            var weatherForecast = sut.CreateWeatherForecasts();

            //assert
            weatherForecast.Count.Should().Be(8);
        }
    }
}