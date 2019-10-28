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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SpecEvoer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BiomePage : Page
    {
        Logic.Specer Specer;

        public BiomePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Specer = (Logic.Specer)e.Parameter;

            listView.ItemsSource = Specer.Biomes;
            BiomeAdderCB.ItemsSource = Specer.Biomes;
            //Specer.BiomesChanged += UpdateList;
        }

        private void UpdateList(object o, EventArgs e)
        {

            listView.ItemsSource = Specer.Biomes;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.AddBiome(int.Parse(UpperTempTB.Text), int.Parse(LowerTempTB.Text), int.Parse(UpperPressureTB.Text), int.Parse(LowerPressureTB.Text), int.Parse(HumidityTB.Text), NameTB.Text, int.Parse(StartYearTB.Text), int.Parse(EndYearTB.Text), DescriptionTB.Text, KeywordTB.Text);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.EditBiome((Data.Biome)listView.SelectedItem, int.Parse(UpperTempTB.Text), int.Parse(LowerTempTB.Text), int.Parse(UpperPressureTB.Text), int.Parse(LowerPressureTB.Text), int.Parse(HumidityTB.Text), NameTB.Text, int.Parse(StartYearTB.Text), int.Parse(EndYearTB.Text), DescriptionTB.Text, KeywordTB.Text);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.RemoveBiome((Data.Biome)listView.SelectedItem);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                NameTB.Text = ((Data.Biome)listView.SelectedItem).Name;
                StartYearTB.Text = ((Data.Biome)listView.SelectedItem).StartYear.year.ToString();
                EndYearTB.Text = ((Data.Biome)listView.SelectedItem).EndYear.year.ToString();
                DescriptionTB.Text = ((Data.Biome)listView.SelectedItem).Description;
                string temp = "";
                foreach (string s in ((Data.Biome)listView.SelectedItem).Keywords)
                {
                    temp += s + " ";
                }
                KeywordTB.Text = temp;

                UpperTempTB.Text = ((Data.Biome)listView.SelectedItem).Tempature.UpperKelvin.ToString();
                LowerTempTB.Text = ((Data.Biome)listView.SelectedItem).Tempature.LowerKelvin.ToString();
                UpperPressureTB.Text = ((Data.Biome)listView.SelectedItem).Pressure.UpperAtmo.ToString();
                LowerPressureTB.Text = ((Data.Biome)listView.SelectedItem).Pressure.LowerAtmo.ToString();

                HumidityTB.Text = ((Data.Biome)listView.SelectedItem).Humidity.ToString();
            }
        }

        private void BiomeAdderBtn_Click(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null && BiomeAdderCB.SelectedItem != null)
            {
                Specer.AddSubBiome(((Data.Biome)listView.SelectedItem), ((Data.Biome)BiomeAdderCB.SelectedItem));
                
            }
        }
    }
}
