namespace SpecEvoer.Data
{
    public struct PressureRange
    {
        public PressureRange(int upperPascals, int lowerPascals)
        {
            UpperPascals = upperPascals;
            LowerPascals = lowerPascals;
        }

        public int UpperPascals { get; set; }
        public int LowerPascals { get; set; }
    }
}
