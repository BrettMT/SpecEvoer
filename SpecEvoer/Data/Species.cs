using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public class Species : IDescribing, IDating, IBiological
    {
        public Species(Clade cateogry, Biome biome, Species parent, List<Species> decendants, Year startYear, Year endYear, string name, string description, List<string> keywords)
        {
            Cateogry = cateogry;
            Biome = biome;
            Parent = parent;
            Decendants = decendants;
            StartYear = startYear;
            EndYear = endYear;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(Clade cateogry, Biome biome, Species parent, List<Species> decendants, Year startYear, Year endYear, string name, string description, List<string> keywords)
        {
            Cateogry = cateogry;
            Biome = biome;
            Parent = parent;
            Decendants = decendants;
            StartYear = startYear;
            EndYear = endYear;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public Clade Cateogry { get; set; }
        public Biome Biome { get; set; }
        public Species Parent { get; set; }
        public List<Species> Decendants { get; set; }


        #region Interfaces
        public BodyPlan BodyPlan { get; set; }
        public Reproduction Reproduction { get; set; }
        public Senses Senses { get; set; }
        public Niche Niche { get; set; }
        public Social Social { get; set; }
        public Biochemistry Biochemistry { get; set; }

        public TempatureRange Tempature { get; set; }
        public PressureRange Pressure { get; set; }

        public void CopyFrom(IBiological source)
        {
            BodyPlan = source.BodyPlan;
            Reproduction = source.Reproduction;
            Senses = source.Senses;
            Niche = source.Niche;
            Social = source.Social;
            Biochemistry = source.Biochemistry;

            Tempature = source.Tempature;
            Pressure = source.Pressure;
        }

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


}
