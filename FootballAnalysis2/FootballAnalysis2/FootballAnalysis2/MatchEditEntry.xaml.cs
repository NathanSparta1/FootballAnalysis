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
    public partial class MatchEditEntry : ContentPage
    {
        public MatchData match;
        public MatchEditEntry()
        {
            InitializeComponent();
        }

        public MatchEditEntry(MatchData Match)
        {
            InitializeComponent();
            Match = match;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            DateEntry.Text = MatchPage.Match.Date;
            OpponentEntry.Text = MatchPage.Match.OpponentName;
            MatchTypeEntry.Text = MatchPage.Match.MatchType;
            MinutesEntry.Text = MatchPage.Match.Minutes.ToString();
            RatingEntry.Text = MatchPage.Match.Rating.ToString();
            GoalsEntry.Text = MatchPage.Match.Goals.ToString();
            AssistsEntry.Text = MatchPage.Match.Assists.ToString();
            TacklesEntry.Text = MatchPage.Match.Tackles.ToString();
            DribblesEntry.Text = MatchPage.Match.Dribbles.ToString();
            KeyPassesEntry.Text = MatchPage.Match.KeyPasses.ToString();
            StaminaEntry.Text = MatchPage.Match.Stamina.ToString();


        }

        private void ButtonSaveMatch_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                var MatchToEdit = con.Find<MatchData>(MatchPage.Match.MatchId);

                MatchToEdit.Date = DateEntry.Text;
                MatchToEdit.OpponentName = OpponentEntry.Text;
                MatchToEdit.MatchType = MatchTypeEntry.Text;
                MatchToEdit.Minutes = Convert.ToDouble(MinutesEntry.Text);
                MatchToEdit.Rating = Convert.ToDouble(RatingEntry.Text);
                MatchToEdit.Goals = Convert.ToInt32(GoalsEntry.Text);
                MatchToEdit.Assists = Convert.ToInt32(AssistsEntry.Text);
                MatchToEdit.Tackles = Convert.ToInt32(TacklesEntry.Text);
                MatchToEdit.Dribbles = Convert.ToInt32(DribblesEntry.Text);
                MatchToEdit.KeyPasses = Convert.ToInt32(KeyPassesEntry.Text);
                MatchToEdit.Stamina = Convert.ToInt32(StaminaEntry.Text);

                con.Update(MatchToEdit);
            }
        }
    }
}