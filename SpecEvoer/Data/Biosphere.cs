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

        //The Features
        public ObservableCollection<Senses> Senses = new ObservableCollection<Senses>();
        public ObservableCollection<Reproduction> Reproductions = new ObservableCollection<Reproduction>();
        public ObservableCollection<BodyPlan> BodyPlans = new ObservableCollection<BodyPlan>();
        public ObservableCollection<Niche> Niches = new ObservableCollection<Niche>();
        public ObservableCollection<Biochemistry> Biochemistries = new ObservableCollection<Biochemistry>();
        public ObservableCollection<Social> Socials = new ObservableCollection<Social>();
    }


}
