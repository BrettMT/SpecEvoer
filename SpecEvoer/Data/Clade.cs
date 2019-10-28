using System.Collections.Generic;

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
        public Energy EnergyTroph { get; set; }
        public ElectronDonor ElectronDonor { get; set; }
        public BuildingSource BuildingSource { get; set; }

        public TempatureRange Tempature { get; set; }
        public PressureRange Pressure { get; set; }

        public void CopyFrom(IBiological source)
        {
            EnergyTroph = source.EnergyTroph;
            ElectronDonor = source.ElectronDonor;
            BuildingSource = source.BuildingSource;

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
    public enum ElectronDonor { Organo, Litho, Ion}
    public enum BuildingSource { CarbonHetero, SiliconHetero, CarbonAuto, SiliconAuto, MetalHetero, MetalAuto, NitroHetero, NitroAuto, BoronHetero, BoronAuto}

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

    public interface IBiological
    {
        Energy EnergyTroph { get; set; }
        ElectronDonor ElectronDonor { get; set; }
        BuildingSource BuildingSource { get; set; }

        TempatureRange Tempature { get; set; }
        PressureRange Pressure { get; set; }

        void CopyFrom(IBiological source);
    }


}
