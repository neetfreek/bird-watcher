/**************************************************************************
* Contains MainPage view functionality                                    *
* 1. Handles creating, populating Observation grid control objects and    *
*       their sorting order in the ObservationStackLayout control object. *
* 2. Handles New Observation and Sort button click functionality.         *
***************************************************************************/
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BirdWatcher
{
    public partial class MainPage : ContentPage
    {
        private bool reverseSort = false;

        // Contain created observations
        private static List<Observation> observations = new List<Observation>();

        public MainPage()
        {
            InitializeComponent();
            UpdateMainPageStackLayout();        

            // Setup message subscriber for notification all Observation object data sent
            MessagingCenter.Subscribe<NewObservationPage>(this, GlobalVariables.MESSAGE_DATA_SAVED, (sender) =>
            {
                UpdateMainPageStackLayout();
            });
        }

        // Re/create observations list organised according to whether reverseSort true/false
        private void UpdateMainPageStackLayout()
        {
            observations = ObservationSerialization.LoadObservationListFromPreferences();
            if (reverseSort)
            {
                observations.Reverse();
            }

            CreateObservationLabels();
        }

        // Handle create observation child detail labels
        private void CreateObservationLabels()
        {
            ObservationStackLayout.Children.Clear();

            if (observations.Count > 0)
            {
                BoxView seperatorFirst = new BoxView() { BackgroundColor = Color.DarkOliveGreen, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                ObservationStackLayout.Children.Add(seperatorFirst);
            }

            for (int counter = observations.Count - 1; counter > 0 - 1; counter--)
            {
                Label labelSpecies = ObservationDataLabel(
                    $"{GlobalVariables.LABEL_SPECIES} {observations[counter].Species}", GlobalVariables.SIZE_FONT_TEXT_LARGE, FontAttributes.Bold);
                Label labelRarity = ObservationDataLabel(
                    $"{GlobalVariables.LABEL_RARITY} {observations[counter].Rarity}", GlobalVariables.SIZE_FONT_TEXT, FontAttributes.None);
                Label labelNotes = ObservationDataLabel(
                    $"{GlobalVariables.LABEL_NOTES} {ShortenNotes(observations[counter].Notes)}", GlobalVariables.SIZE_FONT_TEXT, FontAttributes.None);
                Label labelTimestamp = ObservationDataLabel(
                    $"{GlobalVariables.LABEL_TIMESTAMP} {observations[counter].Timestamp}", GlobalVariables.SIZE_FONT_TEXT_SMALL, FontAttributes.None);

                BoxView seperator = new BoxView() { BackgroundColor=Color.DarkOliveGreen, HorizontalOptions=LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

                Grid newObservationGrid = ObservationGrid();

                newObservationGrid.Children.Add(labelSpecies, 0, 0);
                newObservationGrid.Children.Add(labelRarity, 0, 1);
                newObservationGrid.Children.Add(labelNotes, 0, 2);
                newObservationGrid.Children.Add(labelTimestamp, 0, 3);
                ObservationStackLayout.Children.Add(newObservationGrid);
                ObservationStackLayout.Children.Add(seperator);
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

        // If note's length exceeds GlobalVariables.LENGTH_NOTE_EXCERPT characters, reduce to limit and append "..."
        private string ShortenNotes(string notes)
        {
            string notesToShorten = notes;
            string notesShortened = notesToShorten;
            if (notesToShorten.Length > GlobalVariables.LENGTH_NOTE_EXCERPT)
            {
                notesShortened = $"{notesToShorten.Substring(0, GlobalVariables.LENGTH_NOTE_EXCERPT)}...";
            }

            return notesShortened;
        }

        // Create observation grid object to contain each observation, details
        private Grid ObservationGrid()
        {
            Grid grid = new Grid();
            RowDefinition rowSpecies = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            RowDefinition rowRarity = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            RowDefinition rowNotes = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            RowDefinition rowTimestamp = new RowDefinition() { Height = new GridLength(2.5, GridUnitType.Star) };
            ColumnDefinition columnDetails = new ColumnDefinition() { Width = new GridLength(7.5, GridUnitType.Star) };
            return grid;
        }

        // Handle New Observation button click
        async void OnButtonNewObservationClickedAsync(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewObservationPage());
        }

        // Handle Sort button click 
        void OnButtonSortClicked(object sender, EventArgs args)
        {
            reverseSort = !reverseSort;
            UpdateMainPageStackLayout();
        }
    }
}
