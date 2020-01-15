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
    public partial class TrainingEntry : ContentPage
    {
        public TrainingEntry()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            TrainingData newTraining = new TrainingData()
            {
                Date = DateEntry.Text,
                Rating = Convert.ToDouble(RatingEntry.Text),
                Goals = Convert.ToInt32(GoalsEntry.Text),
                Assists = Convert.ToInt32(AssistsEntry.Text),
                Tackles = Convert.ToInt32(AssistsEntry.Text),
                Dribbles = Convert.ToInt32(DribblesEntry.Text),
                KeyPasses = Convert.ToInt32(KeyPassesEntry.Text),
                Stamina = Convert.ToDouble(StaminaEntry.Text),

            };

            using(SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                // if statement needs testing
                if (newTraining.Date != null)
                {
                    con.CreateTable<TrainingData>();
                    int rowsAdded = con.Insert(newTraining);
                }
                
               
                
            }
        }
    }
}