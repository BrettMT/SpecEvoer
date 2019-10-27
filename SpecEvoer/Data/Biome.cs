using System.Collections.Generic;

namespace SpecEvoer.Data
{
    public class Biome : IDescribing, IDating
    {
        public Biome(List<Biome> biomes, string name, Year startYear, Year endYear, string description, List<string> keywords)
        {
            Biomes = biomes;
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(List<Biome> biomes, string name, Year startYear, Year endYear, string description, List<string> keywords)
        {
            Biomes = biomes;
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            Description = description;
            Keywords = keywords;
        }

        //What other biomes are part of this.
        public List<Biome> Biomes { get; set; }

        //What is the pressure like, tempature, humidity?
        public Tempature Tempature { get; set; }

        public Pressure Pressure { get; set; }

        public enum Climate { Dry, Mild, Wet}
        public Climate Humidity { get; set; }


        #region Interfaces
        public string Name { get; set; }
        public Year StartYear { get; set; }
        public Year EndYear { get; set; }
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
}
