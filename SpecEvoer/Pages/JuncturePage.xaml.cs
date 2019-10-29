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
    public sealed partial class JuncturePage : Page
    {
        Logic.Specer Specer;

        public JuncturePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Specer = (Logic.Specer)e.Parameter;

            listView.ItemsSource = Specer.Juncture;
            EraCB.ItemsSource = Specer.Eras;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.AddNewJuncture((Data.Era)EraCB.SelectedItem, double.Parse(YearTB.Text), NameTB.Text,  DescriptionTB.Text, KeywordTB.Text);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.EditJuncture((Data.Juncture)listView.SelectedItem, (Data.Era)EraCB.SelectedItem, double.Parse(YearTB.Text), NameTB.Text, DescriptionTB.Text, KeywordTB.Text);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Specer.RemoveJuncture((Data.Juncture)listView.SelectedItem);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                NameTB.Text = ((Data.Juncture)listView.SelectedItem).Name;
                YearTB.Text = ((Data.Juncture)listView.SelectedItem).Date.year.ToString();
                DescriptionTB.Text = ((Data.Juncture)listView.SelectedItem).Description;
                EraCB.SelectedItem = ((Data.Juncture)listView.SelectedItem).Caused;
                string temp = "";
                foreach (string s in ((Data.Juncture)listView.SelectedItem).Keywords)
                {
                    temp += s + " ";
                }
                KeywordTB.Text = temp;
            }
        }
    }
}
