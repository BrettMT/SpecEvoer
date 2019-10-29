using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecEvoer.Data
{
    public interface IBiological
    {
        BodyPlan BodyPlan { get; set; }
        Reproduction Reproduction { get; set; }
        Senses Senses { get; set; }
        Niche Niche { get; set; }
        Social Social { get; set; }
        Biochemistry Biochemistry { get; set; }
        ObservableCollection<Relation> Relations { get; set; }
       
        TempatureRange Tempature { get; set; }
        PressureRange Pressure { get; set; }

        void CopyFrom(IBiological source);
    }


}
