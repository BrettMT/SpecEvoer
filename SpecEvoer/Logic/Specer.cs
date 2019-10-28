using SpecEvoer.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Logic
{

    public class Specer
    {
        private Biosphere Biosphere = new Biosphere();
        public Logger Logger = new Logger();

        public void CreateNewBiosphere()
        {
            Biosphere = new Biosphere();
        }

        public void LoadBiosphere()
        {
            throw new NotImplementedException();
        }

        public void SaveBiosphere()
        {
            throw new NotImplementedException();
        }

        #region Eras

        public event EventHandler ErasChanged;

        public ObservableCollection<Era> Eras
        {
            get
            {
                return Biosphere?.Eras ?? null;
            }
        }

        public void AddNewEra(string name, double start, double end, string description, string keys)
        {
            try
            {
                Year startYear = new Year(start);
                Year endYear = new Year(end);
                List<string> keywords = keys.ToUpper().Split(' ').ToList();


                Biosphere?.Eras.Add(new Era(name, startYear, endYear, description, keywords));
                Logger.AddLog($"Added the era: {name}");
                ErasChanged.Invoke(this, null);
            }
            catch
            {
                Logger.AddLog($"Unable to add the era: {name}");
            }
        }

        public void EditEra(Era source, string name, double start, double end, string description, string keys)
        {
            try
            {
                Year startYear = new Year(start);
                Year endYear = new Year(end);
                List<string> keywords = keys.ToUpper().Split(' ').ToList();


                source.Edit(name, startYear, endYear, description, keywords);
                Logger.AddLog($"Edited the era: {source.Name}");
                ErasChanged.Invoke(this, null);
            }
            catch
            {
                Logger.AddLog($"Unable to Edit the era: {source.Name}");
            }
        }

        public void RemoveEra(Era era)
        {
            try
            {
                Biosphere?.Eras.Remove(era);
                Logger.AddLog($"Removed the era: {era.Name}");
                ErasChanged.Invoke(this, null);
            }
            catch
            {
                Logger.AddLog($"Unable to Remove the era: {era.Name}");
            }
        }
        #endregion

        #region Biome
        public event EventHandler BiomesChanged;

        public ObservableCollection<Biome> Biomes
        {
            get
            {
                return Biosphere?.Biomes ?? null;
            }
        }

        public void AddBiome(double uk, double lk, double up, double lp, double humidity, string name, double startYear, double endYear, string description, string keys)
        {
            try
            {
                TempatureRange t = new TempatureRange(uk, lk);
                PressureRange p = new PressureRange(up, lp);
                Year sy = new Year(startYear);
                Year ey = new Year(endYear);
                List<string> keywords = keys.ToUpper().Split(' ').ToList();

                Biosphere.Biomes.Add(new Biome(t, p, humidity, name, sy, ey, description, keywords));
                Logger.AddLog($"Added the biome: {name}");
                BiomesChanged.Invoke(this, null);
            }
            catch
            {
                Logger.AddLog($"Unable to add the biome: {name}");
            }
        }

        public void EditBiome(Biome b, double uk, double lk, double up, double lp, double humidity, string name, double startYear, double endYear, string description, string keys)
        {
            try
            {
                TempatureRange t = new TempatureRange(uk, lk);
                PressureRange p = new PressureRange(up, lp);
                Year sy = new Year(startYear);
                Year ey = new Year(endYear);
                List<string> keywords = keys.ToUpper().Split(' ').ToList();

                b.Edit(b.Biomes, t, p, humidity, name, sy, ey, description, keywords);
                Logger.AddLog($"Edited the biome: {b.Name}");
                BiomesChanged.Invoke(this, null);
            }
            catch
            {
                Logger.AddLog($"Unable to add the biome: {b.Name}");
            }
        }

        public void AddSubBiome(Biome main, Biome sub)
        {

            try
            {
                main.AddBiome(sub);
                Logger.AddLog($"Added the sub Biome {sub.Name} to {main.Name}");
                BiomesChanged.Invoke(this, null);
            }
            catch
            {
                Logger.AddLog($"Unable to add the sub Biome {sub.Name} to {main.Name}");
            }
            
        }

        public void RemoveSubBiome(Biome main, Biome sub)
        {

            try
            {
                main.RemoveBiome(sub);
                Logger.AddLog($"Removed the sub Biome {sub.Name} to {main.Name}");
            }
            catch
            {
                Logger.AddLog($"Unable to remove the sub Biome {sub.Name} to {main.Name}");
            }

        }

        public void RemoveBiome(Biome b)
        {
            try
            {

                Logger.AddLog($"Removed the biome: {b.Name}");
            }
            catch
            {
                Logger.AddLog($"Unable to add the biome: {b.Name}");
            }
        }
        #endregion


        public void AddNewClade()
        {

        }

        public void CreateNewSpecies()
        {

        }
    }

    public class Logger
    {
        private List<string> _Logs = new List<string>();
        public string RecentLog { get; private set;}

        public void AddLog(string log)
        {
            RecentLog = log;
            _Logs.Add(log);
        }

        public List<string> Logs
        {
            get
            {
                //This will create a shallow copy.
                return _Logs.ToList();
            }
        }

    }

    static public class Checker
    {
        static public Specer Specer;

        static public Era CheckEraWithLongestExtent(double start, double end)
        {
            List<Era> eras = new List<Era>();

            foreach(Era e in Specer.Eras)
            {
                if (FallsWithin(start, end, e)) eras.Add(e);
            }

            //IEnumerable<Era> stuff = from x in Specer.Eras
             //                        where (x.StartYear.year < start && start < x.EndYear.year)
               //                      select x;

            return DetermineEraWithLongestExtent(eras, start, end);
        }

        static private bool FallsWithin(double start, double end, Era e)
        {
            //If the starting position falls between the beginning and end of an era, its within that era. If the start comes right as the era ends its not part of that era.
            if(e.StartYear.year <= start && start < e.EndYear.year)
            {
                return true;
            }
            //If the end point falls within an era its part of that era, if the end falls right at the beggining it is not where as if the end also falls on the end of the era it is.
            if(e.StartYear.year < end && end <= e.EndYear.year)
            {
                return true;
            }

            //Completely falls within.
            if(e.StartYear.year >= start && e.EndYear.year <= end)
            {
                return true;
            }
            return false;
        }

        static private Era DetermineEraWithLongestExtent(IEnumerable<Era> es, double start, double end)
        {
            Era result = null;
            double extant = 0;
            foreach(Era e in es)
            {
                double beginningExtantYear;
                double EndExtantYear;

                //If the era starts before our date, use our date. else the era starts after our date so use its start date instead.
                if(e.StartYear.year < start)
                {
                    beginningExtantYear = start;
                }
                else
                {
                    beginningExtantYear = e.StartYear.year;
                }

                //If the era ends after our date, use our date. else the era ends before our date so use it instead.
                if(e.EndYear.year > end)
                {
                    EndExtantYear = end;
                }
                else
                {
                    EndExtantYear = e.EndYear.year;
                }

                //End minus beggining(example 25y - 5y = 20y) is the extent of time we spent in this era.

                double extent = EndExtantYear - beginningExtantYear;

                //If this extent is greater than the highest extent so far set it and era.
                if(extent > extant)
                {
                    extant = extent;
                    result = e; 
                }
            }
            //Now the era with the longest extent should be in the era slot after going through all of them.

            return result;

        }
    }

        
}
