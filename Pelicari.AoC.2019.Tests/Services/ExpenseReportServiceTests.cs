using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Pelicari.AoC._2020.Config;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;
using System.Collections.Generic;

namespace Pelicari.AoC._2019.Tests.Services
{
    [TestClass]
    public class ExpenseReportServiceTests
    {
        private IInputsRepository _inputsRepository;
        private IDay _dayConfig;
        private ExpenseReportService _expenseReportService;

        [TestInitialize]
        public void OnInitialize()
        {
            _inputsRepository = Substitute.For<IInputsRepository>();
            _dayConfig = Substitute.For<IDay>();
            _expenseReportService = new ExpenseReportService(_inputsRepository, _dayConfig);
        }

        [DataTestMethod, DataRow(new[] { "1721", "979", "366", "299", "675", "1456" })]
        public void FindAddendsOfYear_WhenAskedForTwoAddends_ThenTwoCorrectAddendsAreReturned(string[] inputs)
        {
            //Arrange
            _dayConfig.ChallengeDay.Returns(1);
            _dayConfig.PuzzleNumber.Returns(1);
            _inputsRepository.GetInputs(day: 1, puzzleNumber: 1).Returns(inputs);

            //Act 1721 299
            var result = _expenseReportService.FindAddendsOfYear(numberOfAddends: 2);

            //Assert
            result.Should().HaveCount(2);
            result.Should().Contain(new int[] { 1721, 299 });
        }

        [DataTestMethod, DataRow(new[] { "1721", "979", "366", "299", "675", "1456" })]
        public void MultiplyAddends_WhenAskedForTwoAddends_ThenReturnMultiplicationResult(string[] inputs)
        {
            //Arrange
            _dayConfig.ChallengeDay.Returns(1);
            _dayConfig.PuzzleNumber.Returns(1);
            _inputsRepository.GetInputs(day: 1, puzzleNumber: 1).Returns(inputs);

            //Act
            var result = _expenseReportService.MultiplyAddends(numberOfAddends: 2);

            //Assert
            result.Should().Be(514579);
        }

        [DataTestMethod, DataRow(new[] { "1721", "979", "366", "299", "675", "1456" })]
        public void FindAddendsOfYear_WhenAskedForThreeAddends_ThenThreeCorrectAddendsAreReturned(string[] inputs)
        {
            //Arrange
            _dayConfig.ChallengeDay.Returns(1);
            _dayConfig.PuzzleNumber.Returns(1);
            _inputsRepository.GetInputs(day: 1, puzzleNumber: 1).Returns(inputs);

            //Act
            var result = _expenseReportService.FindAddendsOfYear(numberOfAddends: 3);

            //Assert
            result.Should().HaveCount(3);
            result.Should().Contain(new int[] { 979, 366, 675 });
        }

        [DataTestMethod, DataRow(new[] { "1721", "979", "366", "299", "675", "1456" })]
        public void MultiplyAddends_WhenAskedForThreeAddends_ThenReturnMultiplicationResult(string [] inputs)
        {
            //Arrange
            _dayConfig.ChallengeDay.Returns(1);
            _dayConfig.PuzzleNumber.Returns(1);
            _inputsRepository.GetInputs(day: 1, puzzleNumber: 1).Returns(inputs);

            //Act
            var result = _expenseReportService.MultiplyAddends(numberOfAddends: 3);

            //Assert
            result.Should().Be(241861950);
        }
    }
}
