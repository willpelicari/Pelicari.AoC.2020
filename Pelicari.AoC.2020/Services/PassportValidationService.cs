using Pelicari.AoC._2020.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pelicari.AoC._2020.Services
{
    public class PassportValidationService : IPassportValidationService
    {
        public int CountValidPassports(string fileInput, bool completeValidation = true)
        {
            int validPassports = 0;
            var passports = ParsePassports(fileInput);
            foreach (var passport in passports)
                if (IsPassportValid(completeValidation, passport))
                    validPassports++;
            return validPassports;            
        }

        private IEnumerable<Passport> ParsePassports(string fileInput)
        {
            var passports = new List<Passport>();
            var passportInputs = fileInput.Split("\r\n\r\n");

            foreach (var input in passportInputs)
            {
                var passport = new Passport();
                var parts = input.Split(' ', '\n');
                foreach (var item in parts)
                {
                    var splittedItem = item.Split(':');
                    switch (splittedItem[0])
                    {
                        case "byr":
                            passport.BirthYear = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "iyr":
                            passport.IssueYear = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "eyr":
                            passport.ExpirationYear = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "hgt":
                            passport.Height = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "hcl":
                            passport.HairColor = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "ecl":
                            passport.EyeColor = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "pid":
                            passport.PassportId = splittedItem[1].Trim('\r').Trim();
                            break;
                        case "cid":
                            passport.CountryId = splittedItem[1].Trim('\r').Trim();
                            break;
                        default:
                            break;
                    }
                }
                passports.Add(passport);
            }
            return passports;
        }

        public bool IsPassportValid(bool completeValidation, Passport passport)
        {
            if (!completeValidation)
                return !string.IsNullOrEmpty(passport?.BirthYear) &&
                    !string.IsNullOrEmpty(passport?.IssueYear) &&
                    !string.IsNullOrEmpty(passport?.ExpirationYear) &&
                    !string.IsNullOrEmpty(passport?.Height) &&
                    !string.IsNullOrEmpty(passport?.HairColor) &&
                    !string.IsNullOrEmpty(passport?.EyeColor) &&
                    !string.IsNullOrEmpty(passport?.PassportId);
            return
                ValidBirthYear(passport?.BirthYear) &&
                ValidIssueYear(passport?.IssueYear) &&
                ValidExpirationYear(passport?.ExpirationYear) &&
                ValidHeight(passport?.Height) &&
                ValidHairColor(passport?.HairColor) &&
                ValidEyeColor(passport?.EyeColor) &&
                ValidPassportId(passport?.PassportId);
        }

        public bool ValidBirthYear(string field)
        {
            if (field == null || field.Length != 4)
                return false;

            if (!int.TryParse(field, out var parsedYear))
                return false;

            return parsedYear >= 1920 && parsedYear <= 2002;
        }

        public bool ValidIssueYear(string field)
        {
            if (field == null || field.Length != 4)
                return false;

            if (!int.TryParse(field, out var parsedYear))
                return false;

            return parsedYear >= 2010 && parsedYear <= 2020;
        }

        public bool ValidExpirationYear(string field)
        {
            if (field == null || field.Length != 4)
                return false;

            if (!int.TryParse(field, out var parsedYear))
                return false;

            return parsedYear >= 2020 && parsedYear <= 2030;
        }

        public bool ValidHeight(string field)
        {
            if (field == null)
                return false;

            field = field.ToLower();

            if (field.EndsWith("cm"))
            {
                var numberValue = field.Replace("cm", "");
                if (!int.TryParse(numberValue, out var parsedNumber))
                    return false;
                return parsedNumber >= 150 && parsedNumber <= 193;
            }
            else if (field.EndsWith("in"))
            {
                var numberValue = field.Replace("in", "");
                if (!int.TryParse(numberValue, out var parsedNumber))
                    return false;
                return parsedNumber >= 59 && parsedNumber <= 76;
            }
            return false;
        }

        public bool ValidHairColor(string field)
        {
            if (field == null)
                return false;

            var pattern = @"^#[a-fA-F0-9]{6}$";
            return Regex.Match(field, pattern, RegexOptions.IgnoreCase).Success;
        }

        public bool ValidEyeColor(string field)
        {
            if (field == null)
                return false;

            switch (field)
            {
                case "amb":
                    return true;
                case "blu":
                    return true;
                case "brn":
                    return true;
                case "gry":
                    return true;
                case "grn":
                    return true;
                case "hzl":
                    return true;
                case "oth":
                    return true;
                default:
                    return false;
            }
        }

        public bool ValidPassportId(string field)
        {
            if (field == null)
                return false;

            var pattern = @"^[0-9]{9}$";
            return Regex.Match(field, pattern, RegexOptions.IgnoreCase).Success;
        }
    }
}
