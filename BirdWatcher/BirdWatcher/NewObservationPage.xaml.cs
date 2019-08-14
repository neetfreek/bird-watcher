using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcher
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewObservationPage : ContentPage
	{
		public NewObservationPage ()
		{
			InitializeComponent ();
		}

        // Methods called by button clicks from NewObservationPage view
        async void OnButtonCommonClicked(object sender, EventArgs args)
        {
            // Add proper logic
            await Navigation.PushAsync(new MainPage());
        }
        async void OnButtonRareClicked(object sender, EventArgs args)
        {
            // Add proper logic
            await Navigation.PushAsync(new MainPage());
        }
        async void OnButtonExtremelyRareClicked(object sender, EventArgs args)
        {
            // Add proper logic
            await Navigation.PushAsync(new MainPage());
        }

        async void OnButtonSaveClicked(object sender, EventArgs args)
        {
            // Add proper logic
            await Navigation.PushAsync(new MainPage());
        }
        async void OnButtonCancelClicked(object sender, EventArgs args)
        {
            // Add proper logic
            await Navigation.PushAsync(new MainPage());
        }
    }
}