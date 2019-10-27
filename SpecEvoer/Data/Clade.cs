using System.Collections.Generic;

namespace SpecEvoer.Data
{
    public class Clade : IDescribing, IDating
    {
        public Categorical Categorical; //All extant members are also part of other clades.

        public Clade(Clade parent, List<Clade> decendants, List<Species> members, List<Biome> biomes, Year startYear, Year endYear, string name, string description, List<string> keywords)
        {
            Parent = parent;
            Decendants = decendants;
            Members = members;
            Biomes = biomes;
            StartYear = startYear;
            EndYear = endYear;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(Clade parent, List<Clade> decendants, List<Species> members, List<Biome> biomes, Year startYear, Year endYear, string name, string description, List<string> keywords)
        {
            Parent = parent;
            Decendants = decendants;
            Members = members;
            Biomes = biomes;
            StartYear = startYear;
            EndYear = endYear;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public Clade Parent { get; set; }
        public List<Clade> Decendants { get; set; }
        public List<Species> Members { get; set; }
        public List<Biome> Biomes { get; set; }

        #region Interfaces
        public Year StartYear { get; set; }
        public Year EndYear { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }

        public bool isContemporary
        {
            get => EndYear.year == -1;
        }

        public bool isUndecided
        {
            get => EndYear.year == -2;
        }
        #endregion
    }

    public struct Categorical: ITimelineEvent
    {
        bool isCategorical;

        public Year Point { get; set; }
    }


}
