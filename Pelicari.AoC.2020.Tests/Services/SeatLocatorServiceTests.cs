using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Services
{
    [TestClass]
    public class SeatLocatorServiceTests
    {
        private SeatLocatorService _seatLocatorService;

        [TestInitialize]
        public void OnInitialize()
        {
            _seatLocatorService = new SeatLocatorService();
        }

        [TestMethod]
        public void ValidBirthYear_WhenBirthYearIsInvalid_ThenReturnFalse()
        {
            //Act
            _seatLocatorService.FindSeatId("FBFBBFFRLR");

            //Assert
            //result.Should().BeFalse();
        }
    }
}
