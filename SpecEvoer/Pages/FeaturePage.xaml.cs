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
    public sealed partial class FeaturePage : Page
    {
        Logic.Specer Specer;

        public FeaturePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Specer = (Logic.Specer)e.Parameter;


            FeatureTypeCB.ItemsSource = Enum.GetValues(typeof(Data.Feature));
            //listView.ItemsSource = Specer.Biomes;
            //Specer.BiomesChanged += UpdateList;
        }

        private void UpdateList(object o, EventArgs e)
        {

            listView.ItemsSource = Specer.Biomes;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.AddFeature((Data.Feature)FeatureTypeCB.SelectedItem, NameTB.Text, DescriptionTB.Text, KeywordTB.Text);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.EditFeature((Data.Feature)FeatureTypeCB.SelectedItem, listView.SelectedItem, NameTB.Text, DescriptionTB.Text, KeywordTB.Text);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.RemoveFeature((Data.Feature)FeatureTypeCB.SelectedItem, listView.SelectedItem);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                NameTB.Text = ((Data.IDescribing)listView.SelectedItem).Name;
                DescriptionTB.Text = ((Data.IDescribing)listView.SelectedItem).Description;
                string temp = "";
                foreach (string s in ((Data.IDescribing)listView.SelectedItem).Keywords)
                {
                    temp += s + " ";
                }
                KeywordTB.Text = temp;
            }
        }

        private void FeatureTypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (FeatureTypeCB.SelectedItem)
            {
                case Data.Feature.BodyPlan:
                    listView.ItemsSource = Specer.BodyPlan;
                    break;
                case Data.Feature.Niche:
                    listView.ItemsSource = Specer.Niche;
                    break;
                case Data.Feature.Social:
                    listView.ItemsSource = Specer.Social;
                    break;
                case Data.Feature.Reproduction:
                    listView.ItemsSource = Specer.Reproduction;
                    break;
                case Data.Feature.Senses:
                    listView.ItemsSource = Specer.Senses;
                    break;
                case Data.Feature.Biochemistry:
                    listView.ItemsSource = Specer.Biochemistry;
                    break;
            }
        }
    }
}
