using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public class Juncture: IDescribing
    {
        public Juncture(Era caused, Year date, string name, string description, List<string> keywords)
        {
            Caused = caused;
            Date = date;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(Era caused, Year date, string name, string description, List<string> keywords)
        {
            Caused = caused;
            Date = date;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public Era Caused { get; set; }
        public Year Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }
}
