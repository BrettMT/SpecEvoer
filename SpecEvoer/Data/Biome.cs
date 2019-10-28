using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecEvoer.Data
{
    public class Biome : IDescribing, IDating
    {
        public Biome(TempatureRange tempature, PressureRange pressure, double humidity, string name, Year startYear, Year endYear, string description, List<string> keywords)
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
            Biomes = new ObservableCollection<Biome>();
        }

        public void Edit(ObservableCollection<Biome> biomes, TempatureRange tempature, PressureRange pressure, double humidity, string name, Year startYear, Year endYear, string description, List<string> keywords)
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
        }

        public void AddBiome(Biome b)
        {
            Biomes.Add(b);
        }

        public void RemoveBiome(Biome b)
        {
            Biomes.Remove(b);
        }




        //What other biomes are part of this.
        public ObservableCollection<Biome> Biomes { get; set; }

        //What is the pressure like, tempature, humidity?
        public TempatureRange Tempature { get; set; }

        public PressureRange Pressure { get; set; }

        private double _humidity;
        public double Humidity
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
                double temp = 0;
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
