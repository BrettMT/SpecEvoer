using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public class Year
    {
        //100 Kilo Years
        public Year(int year)
        {
            this.year = year;
        }

        public int year { get; set; }



        public string MY
        {
            get => (year / 10).ToString();
        }

        public string BY
        {
            get => (year/ 10000).ToString();
        }
    }
}
