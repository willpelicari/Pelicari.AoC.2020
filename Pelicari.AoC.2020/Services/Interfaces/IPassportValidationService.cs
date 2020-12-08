using System.Collections.Generic;

namespace Pelicari.AoC._2020.Services
{
    public interface IPassportValidationService
    {
        int CountValidPassports(string fileInput, bool completeValidation = true);
    }
}