using System.Collections.Generic;

namespace SpecEvoer.Data
{
    interface IDescribing
    {
        string Name { get; set; }
        string Description { get; set; }
        List<string> Keywords { get; set; }
    }


}
