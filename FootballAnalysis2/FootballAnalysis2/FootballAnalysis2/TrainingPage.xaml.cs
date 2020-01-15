using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballAnalysis2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingPage : ContentPage
    {
        public static TrainingData training;
        List<TrainingData> sessions = new List<TrainingData>();
        public TrainingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var con = new SQLite.SQLiteConnection(App.FilePath))
            {
                // create a table if it doesnt exist
                con.CreateTable<TrainingData>();

               var myTest = new TrainingData() { Date = "03/01/2020", Rating = 7, Goals = 2, Assists = 1,
                    Tackles = 4, Dribbles = 2, KeyPasses = 0, Stamina = 8};

               // int rowsAdded = con.Insert(myTest);

                var training = con.Table<TrainingData>().ToList();
                TrainingViews.ItemsSource = training;



               // con.DropTable<TrainingData>();
               
               // var dummyFromDB = con.Table<TrainingData>().ToList();

                //Age.Text = dummyFromDB.First().Age.ToString();
                //Name.Text = dummyFromDB.First().Name;

            }
        }

        private void ListViewSelection(object sender,SelectionChangedEventArgs e)
        {
            training = (TrainingData)TrainingViews.SelectedItem;

            if (training != null)
            {
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
                DateContent.Text = training.Date.ToString();
                RatingContent.Text = training.Rating.ToString();
                GoalsContent.Text = training.Goals.ToString();
                AssistsContent.Text = training.Assists.ToString();
                TacklesContent.Text = training.Tackles.ToString();
                DribblesContent.Text = training.Dribbles.ToString();
                KeyPassesContent.Text = training.KeyPasses.ToString();
                StaminaContent.Text = training.Stamina.ToString();
            }
           
        }
        private async void ButtonAdd_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainingEntry());
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {


            if (DeleteButton.Text == "Delete")
            {
                DeleteButton.Text = "Confirm?";

                DateContent.BackgroundColor = Color.Red;
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
                    training = (TrainingData)TrainingViews.SelectedItem;

                    var trainingToDelete = con.Find<TrainingData>(training.TrainingId);

                    con.Delete<TrainingData>(trainingToDelete.TrainingId);

                    TrainingViews.ItemsSource = null;

                    sessions = con.Table<TrainingData>().ToList();

                    TrainingViews.ItemsSource = sessions;

                }
                DeleteButton.Text = "Delete";

                DateContent.BackgroundColor = Color.Black;
                RatingContent.BackgroundColor = Color.Black;
                GoalsContent.BackgroundColor = Color.Black;
                AssistsContent.BackgroundColor = Color.Black;
                TacklesContent.BackgroundColor = Color.Black;
                DribblesContent.BackgroundColor = Color.Black;
                KeyPassesContent.BackgroundColor = Color.Black;
                StaminaContent.BackgroundColor = Color.Black;


                DateContent.Text = " ";
                RatingContent.Text = " ";
                GoalsContent.Text = " ";
                AssistsContent.Text = " ";
                TacklesContent.Text = " ";
                DribblesContent.Text = " ";
                KeyPassesContent.Text = " ";
                StaminaContent.Text = " ";
            }
            

        }
        private async void ButtonEdit_Click(object sender, EventArgs e)
        {
            using (var con = new SQLite.SQLiteConnection(App.FilePath))
            {
                training = (TrainingData)TrainingViews.SelectedItem;

                var trainingToEdit = con.Find<TrainingData>(training.TrainingId);

                
                await Navigation.PushAsync(new TrainingEditPage(trainingToEdit));

            }
               
        }


    }



    public class TrainingData
    {
        [PrimaryKey,AutoIncrement]
        public int TrainingId { get; set; }

        public string Date { get; set; }
        public double? Rating { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public int? Tackles { get; set; }
        public int? Dribbles { get; set; }
        public int? KeyPasses { get; set; }
        public double? Stamina { get; set; }
    }
}