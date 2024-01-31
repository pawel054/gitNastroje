using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gitNastroje
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyMood : ContentPage
    {
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            moodsList.ItemsSource = await App.Database.GetAllMoods();
        }

        public DailyMood()
        {
            InitializeComponent();
        }
    }
}