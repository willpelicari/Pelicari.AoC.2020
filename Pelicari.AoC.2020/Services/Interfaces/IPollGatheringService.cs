namespace Pelicari.AoC._2020.Services
{
    public interface IPollGatheringService
    {
        int GetPollAnswers(string fileInput);
        int GetPollEqualAnswers(string fileInput);
    }
}