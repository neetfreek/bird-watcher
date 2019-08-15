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
            UpdateMainPageStackLayout();        

            // Setup message subscriber for notification all Observation object data sent
            MessagingCenter.Subscribe<NewObservationPage>(this, "DataSaved", (sender) =>
            {
                UpdateMainPageStackLayout();
            });
        }

        // Re/create observations list organised newest to oldest top-down
        private void UpdateMainPageStackLayout()
        {
            observations = ObservationSerialization.LoadObservationListFromPreferences();
            CreateObservationLabels();
        }

        // Handle create observation child detail labels
        private void CreateObservationLabels()
        {
                ObservationStackLayout.Children.Clear();

            for (int counter = observations.Count - 1; counter > 0 - 1; counter--)
            {
                Label labelSpecies = ObservationDataLabel($"Species: {observations[counter].Species}" , 26, FontAttributes.Bold);
                Label labelRarity = ObservationDataLabel($"Rarity: {observations[counter].Rarity}", 22, FontAttributes.None);
                Label labelNotes = ObservationDataLabel($"Notes: {observations[counter].Notes}", 22, FontAttributes.None);
                Label labelTimestamp = ObservationDataLabel($"Timestamp: {observations[counter].Timestamp}", 18, FontAttributes.None);

                Grid newObservationGrid = ObservationGrid();

                newObservationGrid.Children.Add(labelSpecies, 0, 0);
                newObservationGrid.Children.Add(labelRarity, 0, 1);
                newObservationGrid.Children.Add(labelNotes, 0, 2);
                newObservationGrid.Children.Add(labelTimestamp, 0, 3);
                ObservationStackLayout.Children.Add(newObservationGrid);
            }
        }

        // Create boilerplate observation child detail label
        private Label ObservationDataLabel(string text, int fontSize, FontAttributes fontAttributes)
        {
            Label label = new Label()
            {
                Text = text,
                FontAttributes = fontAttributes,
                FontSize = fontSize,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            return label;
        }

        // Create observation grid object to contain each observation, details
        private Grid ObservationGrid() // ADD FOURTH ROW FOR TIMESTAMP
        {
            Grid grid = new Grid();
            RowDefinition rowSpecies = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            RowDefinition rowRarity = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            RowDefinition rowNotes = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            RowDefinition rowTimestamp = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            ColumnDefinition columnDetails = new ColumnDefinition() { Width = new GridLength(7.5, GridUnitType.Star) };
            ColumnDefinition columnImage = new ColumnDefinition() { Width = new GridLength(2.5, GridUnitType.Star) };
            Grid.SetRowSpan(columnImage, 2);
            return grid;
        }

        // Method called by button clicks from MainPage view
        async void OnButtonNewObservationClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewObservationPage());
        }
    }
}
