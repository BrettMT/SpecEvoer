using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecEvoer.Data
{
    public class Biosphere
    {
        public ObservableCollection<Era> Eras = new ObservableCollection<Era>();
        public List<Clade> Cateogries = new List<Clade>();
        public List<Species> Species = new List<Species>();
        public List<Biome> Biomes = new List<Biome>();
    }


}
