namespace SpecEvoer.Data
{
    public struct TempatureRange
    {
        public double UpperKelvin { get; set; }
        public double LowerKelvin { get; set; }

        public TempatureRange(double upperkelvin, double lowerkelvin)
        {
            UpperKelvin = upperkelvin;
            LowerKelvin = lowerkelvin;
        }
    }


}
