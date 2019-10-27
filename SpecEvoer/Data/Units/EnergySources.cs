namespace SpecEvoer.Data
{
    public enum Energy { Photo, Electric, Magnetic, Thermal, Ionic, Chemo, Radio, Osmo, Kinetic }

    public class EnergySources
    {
        public Energy Energy;
        public int Watts;

        public EnergySources(Energy e, int watts)
        {
            Energy = e;
            Watts = watts;
        }
    }
}
