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

        public void AddNewEra(string name, int start, int end, string description, string keys)
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

        public void EditEra(Era source, string name, int start, int end, string description, string keys)
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

        public void AddBiome(int uk, int lk, int up, int lp, Biome.Climate humidity, string name, int startYear, int endYear, string description, string keys)
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
            }
            catch
            {
                Logger.AddLog($"Unable to add the biome: {name}");
            }
        }

        public void EditBiome(Biome b, int uk, int lk, int up, int lp, Biome.Climate humidity, string name, int startYear, int endYear, string description, string keys)
        {
            try
            {
                TempatureRange t = new TempatureRange(uk, lk);
                PressureRange p = new PressureRange(up, lp);
                Year sy = new Year(startYear);
                Year ey = new Year(endYear);
                List<string> keywords = keys.ToUpper().Split(' ').ToList();

                b.Edit(b.Biomes, t, p, b.Energies, humidity, name, sy, ey, description, keywords);
                Logger.AddLog($"Edited the biome: {b.Name}");
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

        public void AddEnergySource(Biome main, Energy e, int wattage)
        {

            try
            {
                EnergySources es = new EnergySources(e, wattage);

                main.AddEnergySource(es);
                Logger.AddLog($"Added the Energy Source {e.ToString()} to {main.Name}");
            }
            catch
            {
                Logger.AddLog($"Unable to add the Energy Source {e.ToString()} to {main.Name}");
            }

        }

        public void RemoveEnergySource(Biome main, EnergySources es)
        {

            try
            {
                main.RemoveEnergySource(es);
                Logger.AddLog($"Removed the Energy Source {es.Energy.ToString()} to {main.Name}");
            }
            catch
            {
                Logger.AddLog($"Unable to remove the Energy Source {es.Energy.ToString()} to {main.Name}");
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

        
}
