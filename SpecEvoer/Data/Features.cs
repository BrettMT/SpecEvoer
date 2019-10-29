using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public enum Feature { BodyPlan, Niche, Social, Reproduction, Senses, Biochemistry}

    public class BodyPlan : IDescribing
    {
        public BodyPlan(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class Niche : IDescribing
    {
        public Niche(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public void Edit(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class Social : IDescribing
    {
        public Social(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public void Edit(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class Biochemistry : IDescribing
    {
        public Biochemistry(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public void Edit(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class Reproduction : IDescribing
    {
        public Reproduction(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public void Edit(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class Senses : IDescribing
    {
        public Senses(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public void Edit(string name, string description, List<string> keywords)
        {
            Name = name;
            Description = description;
            Keywords = keywords;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
    }

}
