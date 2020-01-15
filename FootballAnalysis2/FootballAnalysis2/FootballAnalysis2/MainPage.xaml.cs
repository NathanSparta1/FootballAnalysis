using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FootballAnalysis2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TrainingMenuButton_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new TrainingPage());
            
        }

        private async void MatchMenuButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MatchPage());

        }

        private async void MiscMenuButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Miscellaneous());

        }
    }
}
