using System.Collections.Generic;

namespace SpecEvoer.Data
{
    public class Era: IDescribing, IDating
    {
        public Era(string name, Year startYear, Year endYear, string description, List<string> keywords)
        {
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            Description = description;
            Keywords = keywords;
        }

        public void Edit(string name, Year startYear, Year endYear, string description, List<string> keywords)
        {
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
            Description = description;
            Keywords = keywords;
        }

        

        #region Interface
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
    }


}
