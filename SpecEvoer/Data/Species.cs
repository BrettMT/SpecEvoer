using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public class Species : IDescribing
    {
        public Era StartEra { get; set; }
        public Era EndEra { get; set; }
        public Cateogry Cateogry { get; set; }
        public Species Parent { get; set; }
        public List<Species> Decendants { get; set; }


        #region Interfaces

        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        #endregion
    }

    public class Cateogry : IDescribing
    {
        public Era StartEra { get; set; }

        public Cateogry Parent { get; set; }
        public List<Cateogry> Decendants { get; set; }
        public List<Species> Members { get; set; }
        #region Interfaces

        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        #endregion
    }

    public class Era
    {
        public string name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }

    public class Biosphere
    {
        public List<Era> Eras = new List<Era>();
        public List<Cateogry> Cateogries = new List<Cateogry>();
        public List<Species> Species = new List<Species>();
    }






    

    interface IDescribing
    {
        string Name { get; set; }
        string Description { get; set; }
        string Keywords { get; set; }
    }


}
