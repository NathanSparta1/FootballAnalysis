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
    public partial class MatchPage : ContentPage
    {
        public static MatchData Match;
        List<MatchData> matches = new List<MatchData>();
        public MatchPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var con = new SQLite.SQLiteConnection(App.FilePath))
            {
                // create a table if it doesnt exist
                con.CreateTable<MatchData>();

                var myTest = new MatchData()
                {
                    Date = "03/01/2020",
                    MatchType = "Friendly",
                    OpponentName = "Harold Hill F.C",
                    Rating = 7,
                    Goals = 2,
                    Assists = 1,
                    Tackles = 4,
                    Dribbles = 2,
                    KeyPasses = 0,
                    Stamina = 8,
                    Minutes = 90,
                    
                };

                 //int rowsAdded = con.Insert(myTest);

                var Matches = con.Table<MatchData>().ToList();
                MatchViews.ItemsSource = Matches;



                // con.DropTable<TrainingData>();

                // var dummyFromDB = con.Table<TrainingData>().ToList();

                //Age.Text = dummyFromDB.First().Age.ToString();
                //Name.Text = dummyFromDB.First().Name;

            }
        }

        private void ListViewSelection(object sender, SelectionChangedEventArgs e)
        {
            Match = (MatchData)MatchViews.SelectedItem;

            if (Match != null)
            {
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
                DateContent.Text = Match.Date.ToString();
                OpponentContent.Text = Match.OpponentName;
                MatchTypeContent.Text = Match.MatchType;
                MinutesContent.Text = Match.Minutes.ToString();
                RatingContent.Text = Match.Rating.ToString();
                GoalsContent.Text = Match.Goals.ToString();
                AssistsContent.Text = Match.Assists.ToString();
                TacklesContent.Text = Match.Tackles.ToString();
                DribblesContent.Text = Match.Dribbles.ToString();
                KeyPassesContent.Text = Match.KeyPasses.ToString();
                StaminaContent.Text = Match.Stamina.ToString();
            }

        }
        private async void ButtonAdd_ClickM(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MatchEntry());
        }

        private  async void ButtonEdit_ClickM(object sender, EventArgs e)
        {
            using (var con = new SQLite.SQLiteConnection(App.FilePath))
            {
                Match = (MatchData)MatchViews.SelectedItem;

                var matchToEdit = con.Find<MatchData>(Match.MatchId);

                await Navigation.PushAsync(new MatchEditEntry(matchToEdit));

            }

        }

        private void ButtonDelete_ClickM(object sender, EventArgs e)
        {
            if (DeleteButton.Text == "Delete")
            {
                DeleteButton.Text = "Confirm?";

                DateContent.BackgroundColor = Color.Red;
                OpponentContent.BackgroundColor = Color.Red;
                MinutesContent.BackgroundColor = Color.Red;
                MatchTypeContent.BackgroundColor = Color.Red;
                RatingContent.BackgroundColor = Color.Red;
                GoalsContent.BackgroundColor = Color.Red;
                AssistsContent.BackgroundColor = Color.Red;
                TacklesContent.BackgroundColor = Color.Red;
                DribblesContent.BackgroundColor = Color.Red;
                KeyPassesContent.BackgroundColor = Color.Red;
                StaminaContent.BackgroundColor = Color.Red;
            }

            else
            {
                using (var con = new SQLite.SQLiteConnection(App.FilePath))
                {
                    Match = (MatchData)MatchViews.SelectedItem;

                    var matchToDelete = con.Find<MatchData>(Match.MatchId);

                    con.Delete<MatchData>(matchToDelete.MatchId);

                    MatchViews.ItemsSource = null;

                    matches = con.Table<MatchData>().ToList();

                    MatchViews.ItemsSource = matches;

                }
                DeleteButton.Text = "Delete";

                DateContent.BackgroundColor = Color.Black;
                OpponentContent.BackgroundColor = Color.Black;
                MinutesContent.BackgroundColor = Color.Black;
                MatchTypeContent.BackgroundColor = Color.Black;
                RatingContent.BackgroundColor = Color.Black;
                GoalsContent.BackgroundColor = Color.Black;
                AssistsContent.BackgroundColor = Color.Black;
                TacklesContent.BackgroundColor = Color.Black;
                DribblesContent.BackgroundColor = Color.Black;
                KeyPassesContent.BackgroundColor = Color.Black;
                StaminaContent.BackgroundColor = Color.Black;


                DateContent.Text = " ";
                OpponentContent.Text = " ";
                MinutesContent.Text = " ";
                MatchTypeContent.Text = " ";
                RatingContent.Text = " ";
                GoalsContent.Text = " ";
                AssistsContent.Text = " ";
                TacklesContent.Text = " ";
                DribblesContent.Text = " ";
                KeyPassesContent.Text = " ";
                StaminaContent.Text = " ";
            }

        }

    }
    public class MatchData
    {
        [PrimaryKey, AutoIncrement]
        public int MatchId { get; set; }
        public string Date { get; set; }
        public string MatchType { get; set; }

        public double? Rating { get; set; }
        public string OpponentName { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public int? Tackles { get; set; }
        public int? Dribbles { get; set; }
        public int? KeyPasses { get; set; }
        public double? Minutes { get; set; }
        public double? Stamina { get; set; }
        //public bool? CleanSheet { get; set; }
    }
}