using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballAnalysis2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Miscellaneous : ContentPage
    {
        public Miscellaneous()
        {
            InitializeComponent();
        }
    }

    public class MiscData
    {
        public int MiscId { get; set; }
        public DateTime Date { get; set; }
        public string MatchType { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Tackles { get; set; }
        public int Dribbles { get; set; }
        public int KeyPasses { get; set; }
        public double Rating { get; set; }
        public double Minutes { get; set; }
        public double Stamina { get; set; }
    }
}