using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace FootballAnalysis2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingEditPage : ContentPage
    {
        // TrainingData training;
        public TrainingData training;
        //TrainingPage page;

        public TrainingEditPage()
        {
            InitializeComponent();
        }

        public TrainingEditPage(TrainingData Training)
        {
            InitializeComponent();
            Training = training;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
             
              
                
                DateEntry.Text = TrainingPage.training.Date;
                RatingEntry.Text = TrainingPage.training.Rating.ToString();
                GoalsEntry.Text = TrainingPage.training.Goals.ToString();
                AssistsEntry.Text = TrainingPage.training.Assists.ToString();
                TacklesEntry.Text = TrainingPage.training.Tackles.ToString();
                DribblesEntry.Text = TrainingPage.training.Dribbles.ToString();
                KeyPassesEntry.Text = TrainingPage.training.KeyPasses.ToString();
                StaminaEntry.Text = TrainingPage.training.Stamina.ToString();

            
        }

        private void SaveAndEditBTN(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                var trainingToEdit = con.Find<TrainingData>(TrainingPage.training.TrainingId);

                trainingToEdit.Date = DateEntry.Text;
                trainingToEdit.Rating = Convert.ToDouble(RatingEntry.Text);
                trainingToEdit.Goals = Convert.ToInt32(GoalsEntry.Text);
                trainingToEdit.Assists = Convert.ToInt32(AssistsEntry.Text);
                trainingToEdit.Tackles = Convert.ToInt32(TacklesEntry.Text);
                trainingToEdit.Dribbles = Convert.ToInt32(DribblesEntry.Text);
                trainingToEdit.KeyPasses = Convert.ToInt32(KeyPassesEntry.Text);
                trainingToEdit.Stamina = Convert.ToInt32(StaminaEntry.Text);

                con.Update(trainingToEdit);
            }
        }



     }
}