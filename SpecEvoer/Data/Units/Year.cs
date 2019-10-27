using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public class Year
    {
        public Year(int year)
        {
            this.year = year;
        }

        public int year { get; set; }

        public string KY
        {
            get => (year / 1000).ToString();
        }

        public string MY
        {
            get => (year / 1000000).ToString();
        }

        public string BY
        {
            get => (year/ 1000000000).ToString();
        }
    }
}
