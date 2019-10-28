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
    public sealed partial class EraPage : Page
    {
        Logic.Specer Specer;

        public EraPage()
        {
            
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Specer = (Logic.Specer)e.Parameter;

            listView.ItemsSource = Specer.Eras;
            Specer.ErasChanged += UpdateEraList;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.AddNewEra(NameTB.Text, int.Parse(StartYearTB.Text), int.Parse(EndYearTB.Text), DescriptionTB.Text, KeywordTB.Text );
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.EditEra((Data.Era)listView.SelectedItem, NameTB.Text, int.Parse(StartYearTB.Text), int.Parse(EndYearTB.Text), DescriptionTB.Text, KeywordTB.Text);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.RemoveEra((Data.Era)listView.SelectedItem);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                NameTB.Text = ((Data.Era)listView.SelectedItem).Name;
                StartYearTB.Text = ((Data.Era)listView.SelectedItem).StartYear.year.ToString();
                EndYearTB.Text = ((Data.Era)listView.SelectedItem).EndYear.year.ToString();
                DescriptionTB.Text = ((Data.Era)listView.SelectedItem).Description;
                string temp = "";
                foreach(string s in ((Data.Era)listView.SelectedItem).Keywords)
                {
                    temp += s + " ";
                }
                KeywordTB.Text = temp;
            }
        }

        private void UpdateEraList(object o, EventArgs e)
        {

            listView.ItemsSource = Specer.Eras;
        }
    }
}
