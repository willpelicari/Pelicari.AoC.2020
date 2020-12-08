namespace Pelicari.AoC._2020.Services
{
    public interface ILuggageProcessingService
    {
        int CountBagContainers(string bagColor);
        int CountExtraLuggages(string givenBagColor);
    }
}