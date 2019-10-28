using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecEvoer.Data
{
    public class Biome : IDescribing, IDating
    {
        public Biome(TempatureRange tempature, PressureRange pressure, int humidity, string name, Year startYear, Year endYear, string description, List<string> keywords)
        {
            Tempature = tempature;
            Pressure = pressure;
            Humidity = humidity;
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            Description = description;
            Keywords = keywords;

            //These are done seperate.
            Energies = new List<EnergySources>();
            Biomes = new ObservableCollection<Biome>();
        }

        public void Edit(ObservableCollection<Biome> biomes, TempatureRange tempature, PressureRange pressure, List<EnergySources> energies, int humidity, string name, Year startYear, Year endYear, string description, List<string> keywords)
        {
            
            Tempature = tempature;
            Pressure = pressure;
            Humidity = humidity;
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            Description = description;
            Keywords = keywords;

            //This differs from Construction in that it will generally pass the old biome and old energies back in.
            Biomes = biomes;
            Energies = energies;
        }

        public void AddBiome(Biome b)
        {
            Biomes.Add(b);
        }

        public void RemoveBiome(Biome b)
        {
            Biomes.Remove(b);
        }

        public void AddEnergySource(EnergySources e)
        {
            Energies.Add(e);
        }

        public void RemoveEnergySource(EnergySources e)
        {
            Energies.Remove(e);
        }




        //What other biomes are part of this.
        public ObservableCollection<Biome> Biomes { get; set; }

        //What is the pressure like, tempature, humidity?
        public TempatureRange Tempature { get; set; }

        public PressureRange Pressure { get; set; }

        public List<EnergySources> Energies {get; set;}

        private int _humidity;
        public int Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                if (0 > value)
                {
                    _humidity = 0;
                }
                else if (value > 100)
                {
                    _humidity = 100;
                }
                else
                {
                    _humidity = value;
                }
            }
        }

        public Era LongestExtent
        {
            get
            {
                Era e = Logic.Checker.CheckEraWithLongestExtent(StartYear.year, EndYear.year);
                return e;
            }
        }

        public int TotalWattage
        { get
            {
                int temp = 0;
                foreach(EnergySources e in Energies)
                {
                    temp += e.Watts;
                }
                return temp;
            }
        }


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

        public override string ToString()
        {
            return Name;
        }
    }
}
