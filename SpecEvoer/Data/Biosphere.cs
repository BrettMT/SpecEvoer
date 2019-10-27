using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecEvoer.Data
{
    public class Biosphere
    {
        public ObservableCollection<Era> Eras = new ObservableCollection<Era>();
        public ObservableCollection<Clade> Cateogries = new ObservableCollection<Clade>();
        public ObservableCollection<Species> Species = new ObservableCollection<Species>();
        public ObservableCollection<Biome> Biomes = new ObservableCollection<Biome>();
    }


}
