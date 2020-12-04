using System.Collections.Generic;

namespace Pelicari.AoC._2020.Services
{
    public interface IExpenseReportService
    {
        IEnumerable<int> FindAddendsOfYear(IEnumerable<int> inputs, int numberOfAddends);
        int MultiplyAddends(IEnumerable<string> inputs, int numberOfAddends);
    }
}