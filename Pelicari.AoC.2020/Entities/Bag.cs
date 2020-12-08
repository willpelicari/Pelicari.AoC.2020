using System.Collections.Generic;

namespace Pelicari.AoC._2020.Entities
{
    public class Bag
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public IList<Bag>  Content { get; set; }
    }
}
