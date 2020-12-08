using Pelicari.AoC._2020.Entities;
using System.Collections.Generic;

namespace Pelicari.AoC._2020.Repositories
{
    public interface IBagsRepository
    {
        IEnumerable<Bag> ParseBags();
    }
}