namespace SpecEvoer.Data
{
    public struct TempatureRange
    {
        public int UpperKelvin { get; set; }
        public int LowerKelvin { get; set; }

        public TempatureRange(int upperkelvin, int lowerkelvin)
        {
            UpperKelvin = upperkelvin;
            LowerKelvin = lowerkelvin;
        }
    }


}
