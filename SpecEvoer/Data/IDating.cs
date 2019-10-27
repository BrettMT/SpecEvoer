namespace SpecEvoer.Data
{
    interface IDating
    {
        Year StartYear { get; set; }
        Year EndYear { get; set; }

        bool isContemporary { get; }
      

        bool isUndecided { get; }

    }


}
