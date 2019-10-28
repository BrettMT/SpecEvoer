namespace SpecEvoer.Data
{
    public struct PressureRange
    {
        public PressureRange(double upperAtmo, double lowerAtmo)
        {
            UpperAtmo = upperAtmo;
            LowerAtmo = lowerAtmo;
        }

        public double UpperAtmo { get; set; }
        public double LowerAtmo { get; set; }
    }
}
