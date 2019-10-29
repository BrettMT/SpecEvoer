using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecEvoer.Data
{
    public class Clade : IDescribing, IDating, IBiological
    {
        public Categorical Categorical = new Categorical(); //All extant members are also part of other clades.

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

        public void SetCategorical(bool b, double year)
        {
            Categorical.isCategorical = b;
            Categorical.Point.year = year;
        }



        public Clade Parent { get; set; }
        public List<Clade> Decendants { get; set; }
        public List<Species> Members { get; set; }
        public List<Biome> Biomes { get; set; }




        #region Interfaces
        public BodyPlan BodyPlan { get; set; }
        public Reproduction Reproduction { get; set; }
        public Senses Senses { get; set; }
        public Niche Niche { get; set; }
        public Social Social { get; set; }
        public Biochemistry Biochemistry { get; set; }
        public ObservableCollection<Relation> Relations { get; set; }

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
            //I dont want a shallow copy of the list, I dont want to pass the list.
            ObservableCollection<Relation> temp = new ObservableCollection<Relation>();
            foreach(Relation r in source.Relations) { temp.Add(r); }
            Relations = temp;

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

    public class Categorical: ITimelineEvent
    {
        public bool isCategorical;

        public Categorical() 
        {
            this.isCategorical = false;
            Point = new Year(0);
        }

        public Year Point { get; set; }
    }


}
