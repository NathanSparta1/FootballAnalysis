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
    public partial class MatchEntry : ContentPage
    {
        public MatchEntry()
        {
            InitializeComponent();
        }

        private void ButtonSaveMatch_Click(object sender, EventArgs e)
        {
            MatchData newMatch = new MatchData()
            {
                Date = DateEntry.Text,
                OpponentName = OpponentEntry.Text,
                MatchType = MatchTypeEntry.Text,
                Minutes = Convert.ToDouble(MinutesEntry.Text),
                Rating = Convert.ToDouble(RatingEntry.Text),
                Goals = Convert.ToInt32(GoalsEntry.Text),
                Assists = Convert.ToInt32(AssistsEntry.Text),
                Tackles = Convert.ToInt32(AssistsEntry.Text),
                Dribbles = Convert.ToInt32(DribblesEntry.Text),
                KeyPasses = Convert.ToInt32(KeyPassesEntry.Text),
                Stamina = Convert.ToDouble(StaminaEntry.Text),

            };

            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                // if statement needs testing   makes sure new records with null fields cannot be added
                //if (newMatch.Date != null && newMatch.OpponentName != null && newMatch.MatchType != null)
                //{
                    con.CreateTable<TrainingData>();
                    int rowsAdded = con.Insert(newMatch);
               // }



            }
        }
    }
}