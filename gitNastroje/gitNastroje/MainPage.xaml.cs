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

        private static List<ImageButton> Buttons = new List<ImageButton>()
        {
            new ImageButton(){ Source = MoodIcons[MoodEnum.zadowolony] },
            new ImageButton(){ Source = MoodIcons[MoodEnum.dobry] },
            new ImageButton(){ Source = MoodIcons[MoodEnum.przeciętny] },
            new ImageButton(){ Source = MoodIcons[MoodEnum.słaby] },
            new ImageButton(){ Source = MoodIcons[MoodEnum.okropny] },
        };

        private async void GetLastDayMood()
        {
            var result = await App.Database.GetLastMoodAsync();

            if(result != null)
            {
                labelLastData.Text = result.Date.ToString("MM/dd/yyyy");
                labelLastMood.Text = result.EnumMood.ToString();
            }
            else
            {
                labelLastData.Text = "Brak danych";
            }
        }

        private void EnableButtons()
        {
            foreach(var btn in Buttons)
            {
                btn.IsEnabled = true;
                btn.BackgroundColor = Color.Transparent;
            }
        }

        private void DisableButtons(int btnID)
        {
            EnableButtons();

            for(int i=0; i< Buttons.Count; i++)
            {
                if(i == btnID)
                    Buttons[i].BackgroundColor = Color.LightGray;
                Buttons[i].IsEnabled = false;
            }
        }

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
