using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pelicari.AoC._2020.Tests.Services
{
    [TestClass]
    public class PassportValidationServiceTests
    {
        private PassportValidationService _passportValidationService;

        [TestInitialize]
        public void OnInitialize()
        {
            _passportValidationService = new PassportValidationService();
        }

        [DataTestMethod]
        [DataRow("notValid")]
        [DataRow("1919")]
        [DataRow("2003")]
        [DataRow("02000")]
        [DataRow("200")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidBirthYear_WhenBirthYearIsInvalid_ThenReturnFalse(string invalidDate)
        {
            //Act
            var result = _passportValidationService.ValidBirthYear(invalidDate);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("1920")]
        [DataRow("2002")]
        public void ValidBirthYear_WhenBirthYearIsValid_ThenReturnTrue(string validDate)
        {
            //Act
            var result = _passportValidationService.ValidBirthYear(validDate);

            //Assert
            result.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow("notValid")]
        [DataRow("2009")]
        [DataRow("2021")]
        [DataRow("02020")]
        [DataRow("200")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidIssueYear_WhenIssueYearIsInvalid_ThenReturnFalse(string invalidDate)
        {
            //Act
            var result = _passportValidationService.ValidIssueYear(invalidDate);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("2010")]
        [DataRow("2020")]
        public void ValidIssueYear_WhenIssueYearIsValid_ThenReturnTrue(string validDate)
        {
            //Act
            var result = _passportValidationService.ValidIssueYear(validDate);

            //Assert
            result.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow("notValid")]
        [DataRow("2019")]
        [DataRow("2031")]
        [DataRow("02020")]
        [DataRow("200")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidExpirationYear_WhenExpirationYearIsInvalid_ThenReturnFalse(string invalidDate)
        {
            //Act
            var result = _passportValidationService.ValidExpirationYear(invalidDate);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("2020")]
        [DataRow("2030")]
        public void ValidExpirationYear_WhenExpirationYearIsValid_ThenReturnTrue(string validDate)
        {
            //Act
            var result = _passportValidationService.ValidExpirationYear(validDate);

            //Assert
            result.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow("notValid")]
        [DataRow("cm190")]
        [DataRow("194cm")]
        [DataRow("149CM")]
        [DataRow("58IN")]
        [DataRow("77in")]
        [DataRow("0100cm")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidHeight_WhenHeightIsInvalid_ThenReturnFalse(string invalidHeight)
        {
            //Act
            var result = _passportValidationService.ValidHeight(invalidHeight);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("151CM")]
        [DataRow("193cm")]
        [DataRow("59in")]
        [DataRow("76IN")]
        public void ValidHeight_WhenHeightIsValid_ThenReturnTrue(string validHeight)
        {
            //Act
            var result = _passportValidationService.ValidHeight(validHeight);

            //Assert
            result.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow("notValid")]
        [DataRow("#12345")]
        [DataRow("12345")]
        [DataRow("123456#")]
        [DataRow("#0f12cg")]
        [DataRow("#00000-")]
        [DataRow("#FFFFF")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidHairColor_WhenHairColorIsInvalid_ThenReturnFalse(string invalidHairColor)
        {
            //Act
            var result = _passportValidationService.ValidHairColor(invalidHairColor);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("#c0c0c0")]
        [DataRow("#fff0d0")]
        [DataRow("#032123")]
        [DataRow("#FF123d")]
        public void ValidHairColor_WhenHairColorIsValid_ThenReturnTrue(string validHairColor)
        {
            //Act
            var result = _passportValidationService.ValidHairColor(validHairColor);

            //Assert
            result.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow("notValid")]
        [DataRow("123")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidEyeColor_WhenEyeColorIsInvalid_ThenReturnFalse(string invalidEyeColor)
        {
            //Act
            var result = _passportValidationService.ValidEyeColor(invalidEyeColor);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("amb")]
        [DataRow("blu")]
        [DataRow("brn")]
        [DataRow("gry")]
        [DataRow("grn")]
        [DataRow("hzl")]
        [DataRow("oth")]
        public void ValidEyeColor_WhenEyeColorIsValid_ThenReturnTrue(string validEyeColor)
        {
            //Act
            var result = _passportValidationService.ValidEyeColor(validEyeColor);

            //Assert
            result.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow("abcd12345")]
        [DataRow("12345678")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ValidPassportId_WhePassportIdIsInvalid_ThenReturnFalse(string invalidPassportId)
        {
            //Act
            var result = _passportValidationService.ValidPassportId(invalidPassportId);

            //Assert
            result.Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow("000000000")]
        [DataRow("012345678")]
        [DataRow("123456789")]
        [DataRow("987654321")]
        [DataRow("111122223")]
        public void ValidPassportId_WhenPassportIdIsValid_ThenReturnTrue(string validPassportId)
        {
            //Act
            var result = _passportValidationService.ValidPassportId(validPassportId);

            //Assert
            result.Should().BeTrue();
        }
    }
}
