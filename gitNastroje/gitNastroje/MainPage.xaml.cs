using gitNastroje.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gitNastroje
{
    public partial class MainPage : ContentPage
    {
        public static Dictionary<MoodEnum, string> MoodIcons = new Dictionary<MoodEnum, string>()
        {
            {MoodEnum.zadowolony, "good.png" },
            {MoodEnum.dobry, "mid.png" },
            {MoodEnum.przeciętny, "meh.png" },
            {MoodEnum.słaby, "sad.png" },
            {MoodEnum.okropny, "bad.png" },
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private async void DatePickerChanged(object sender, PropertyChangedEventArgs e)
        {
            var mood = App.Database.GetMood(datePicker.Date);
            if(mood != null)
            {
                var col = (int)mood.Result.EnumMood;
                
            }
        }

        private void BtnMore(object sender, EventArgs e)
        {

        }

    }
}
