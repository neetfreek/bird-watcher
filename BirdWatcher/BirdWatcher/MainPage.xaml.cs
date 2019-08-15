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
        // Contain created observations
        private static List<Observation> observations = new List<Observation>();

        public MainPage()
        {
            InitializeComponent();
            observations = ObservationSerialization.LoadObservationListFromPreferences();
            UpdateMainPageStackLayout();        

            // Setup message subscriber for notification all Observation object data sent
            MessagingCenter.Subscribe<NewObservationPage>(this, "DataSaved", (sender) =>
            {
                observations = ObservationSerialization.LoadObservationListFromPreferences();
                UpdateMainPageStackLayout();
            });
        }

        private void UpdateMainPageStackLayout()
        {
            // REMOVE OR SKIP PRE-EXISTING LABELS IN MAINPAGESTACKLAYOUT
            CreateObservationLabels();
        }

        private void CreateObservationLabels()
        {
            for (int counter = 0; counter < observations.Count; counter++)
            {
                Label label = new Label() {
                    Text = observations[counter].Species,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Start
                };
                ObservationStackLayout.Children.Add(label);
            }
        }

        // Method called by button clicks from MainPage view
        async void OnButtonNewObservationClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewObservationPage());
        }
    }
}
