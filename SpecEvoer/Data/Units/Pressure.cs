namespace SpecEvoer.Data
{
    public struct PressureRange
    {
        public PressureRange(int upperAtmo, int lowerAtmo)
        {
            UpperAtmo = upperAtmo;
            LowerAtmo = lowerAtmo;
        }

        public float UpperAtmo { get; set; }
        public float LowerAtmo { get; set; }
    }
}
