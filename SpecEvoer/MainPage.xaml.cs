using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpecEvoer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Logic.Specer Specer = new Logic.Specer();

        public MainPage()
        {
            this.InitializeComponent();

            Logic.Checker.Specer = Specer;

            Specer.AddNewEra("Creation", 0, 10000, "creation era", "PROTOLIFE");
            Specer.AddNewEra("Diversification", 10000, 15000, "major diversification", "MULTICELLULAR");
            Specer.AddNewEra("Iterim Period", 9000, 11000, "major Shift", "MULTICELLULAR");
            Specer.AddNewEra("New Era", 15000, 25000, "major Shift", "MULTICELLULAR");

            Specer.AddBiome(240, 250, 21, 30, 100, "Primordial Ocean", 0, 15000, "Primordial Soup", "PRIMODIAL");
            
            Specer.AddBiome(240, 250, 21, 30, 100, "Primordial Coast", 0, 15000, "Primordial Soup", "PRIMODIAL");
            Specer.AddBiome(240, 250, 21, 30, 100, "Primordial Tidepool", 0, 15000, "Primordial Soup", "PRIMODIAL");

            Specer.AddSubBiome(Specer.Biomes[0], Specer.Biomes[1]);
            Specer.AddSubBiome(Specer.Biomes[0], Specer.Biomes[2]);

            Type t = typeof(Pages.JuncturePage);
            frame.Navigate(t, Specer);
        }
    }
}
