using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day9
    {
        private ServiceProvider _serviceProvider;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IXmasDecryptService, XmasDecryptService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day9_Puzzle1()
        {
            //Arrange
            var xmasDecryptService = _serviceProvider.GetService<IXmasDecryptService>();

            //Act
            var result = xmasDecryptService.FindWeakPoint(considerContiguousSet: false, preambleSize: 25, out var weakPoint);

            //Assert
            result.Should().BeTrue();
            weakPoint.Should().Be(85848519);
        }

        [TestMethod]
        public void Day9_Puzzle2()
        {
            //Arrange
            var xmasDecryptService = _serviceProvider.GetService<IXmasDecryptService>();

            //Act
            var result = xmasDecryptService.FindWeakPoint(considerContiguousSet: true, preambleSize: 25, out var weakPoint);

            //Assert
            result.Should().BeTrue();
            weakPoint.Should().Be(85848519);
        }
    }
}
