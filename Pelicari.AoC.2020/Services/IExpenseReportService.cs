using System.Collections.Generic;

namespace Pelicari.AoC._2020.Services
{
    public interface IExpenseReportService
    {
        IEnumerable<int> FindAddendsOfYear(int numberOfAddends);
        int MultiplyAddends(int numberOfAddends);
    }
}