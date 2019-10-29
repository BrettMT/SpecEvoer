using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public struct Relation : IDescribing
    {
        IDescribing Describing;

        public Relation(IDescribing describing, string name, string description, List<string> keywords)
        {
            Describing = describing;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(IDescribing describing, string name, string description, List<string> keywords)
        {
            Describing = describing;
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }
}
