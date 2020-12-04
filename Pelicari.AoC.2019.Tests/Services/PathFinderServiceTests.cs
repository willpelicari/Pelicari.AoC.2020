using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2019.Tests.Services
{
    [TestClass]
    public class PathFinderServiceTests
    {
        private PathFinderService _pathFinderService;

        [TestInitialize]
        public void OnInitialize()
        {
            _pathFinderService = new PathFinderService();
        }

        [TestMethod]
        public void ParseMapPattern_WhenFileContentIsReceived_ThenReturnMapPatternMatrix()
        {
            //Arrange
            var fileContent = new[] { ".#........#", "#.##...#..." };
            var expectedResult = new char[][] {
                new char[] { '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
                new char[] { '#', '.', '#', '#', '.', '.', '.', '#', '.', '.', '.' }
            };

            //Act
            var result = _pathFinderService.ParseMapPattern(fileContent);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [DataTestMethod]
        [DataRow(0, 0, 'A')]
        [DataRow(2, 0, 'B')]
        [DataRow(8, 0, 'C')]
        public void MoveToboggan_WhenTobogganAndMapPattern_ThenReturnFoundSymbol(int tobogganPosX, int tobogganPosY, char expectedSymbol)
        {
            //Arrange
            var toboggan = new Toboggan() { X = tobogganPosX, Y = tobogganPosY };
            var mapPattern = new char[][] {
                new char[] { '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
                new char[] { 'C', '.', '#', 'A', '.', 'B', '.', '#', '.', '.', '.' }
            };

            //Act
            var result = _pathFinderService.MoveToboggan(mapPattern, toboggan, 3, 1);

            //Assert
            result.Should().Be(expectedSymbol);
        }

        [TestMethod]
        public void CountSymbols_WhenMapTobogganOffsetsAndSymbolArePassed_ThenReturnNumberOfSymbolsFound()
        {
            //Arrange
            var toboggan = new Toboggan() { X = 0, Y = 0 };
            var fileContent = new[] { ".#........#", "#.##...#..." };

            //Act
            var result = _pathFinderService.CountSymbols(fileContent, toboggan, 3, 1, '#');

            //Assert
            result.Should().Be(1);
        }
    }
}
