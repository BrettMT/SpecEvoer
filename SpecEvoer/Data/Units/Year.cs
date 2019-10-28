using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEvoer.Data
{
    public class Year
    {
        //10 Kilo Years
        public Year(double year)
        {
            this.year = year;
        }

        public double year { get; set; }



        public string MY
        {
            get => (year / 100).ToString();
        }

        public string BY
        {
            get => (year/ 100000).ToString();
        }
    }
}
