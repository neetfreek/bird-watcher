using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BirdWatcher
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Methods called by button clicks from MainPage
        async void OnButtonNewObservationClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewObservationPage());
        }
    }
}
