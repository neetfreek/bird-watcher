using System;
using System.Collections.Generic;
using System.Text;

// For object serialization and saving data
using System.IO;
using System.Runtime.Serialization.Json;
using Xamarin.Essentials;

namespace BirdWatcher
{
    public static class ObservationSerialization
    {
        // Handle convert Observation object to JSON data, save to Preferences
        public static void SaveObservationToPreferences(Observation observation)
        {
            string newObservationString = ObservationToString(observation);
            AddObservationStringToPreferences(newObservationString);
        }

        // Handle create Observation objects from Preferences JSON data, add to list, return
        public static List<Observation> LoadObservationListFromPreferences()
        {
            List<Observation> observations = new List<Observation>();

            int counter = 0;
            while (Preferences.ContainsKey(counter.ToString()))
            {
                Observation observationToAdd = PreferencesDataToObject(Preferences.Get(counter.ToString(), GlobalVariables.PREFERENCE_DATA_NOT_FOUND));
                observations.Add(observationToAdd);
                counter++;
            }

            return observations;
        }


        // Create JSON object from Observation data
        private static string ObservationToString(Observation observation)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Observation));
            serializer.WriteObject(stream, observation);

            byte[] observationJson = stream.ToArray();
            stream.Close();
            string observationString = Encoding.UTF8.GetString(observationJson, 0, observationJson.Length);

            return observationString;
        }

        // Add string-format observation data (value) as string to preferences with object name as key
        private static void AddObservationStringToPreferences(string newObservationString)
        {
            int counter = 0;
            // Create unique key for observation
            while (Preferences.ContainsKey($"{counter}"))
            {
                counter++;
            }

            Preferences.Set($"{counter}", newObservationString);
        }

        // Return Observation object with fields set from Preferences data
        private static Observation PreferencesDataToObject(string observationString)
        {
            Observation observation = new Observation("", "", "");
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(observationString));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(observation.GetType());

            return serializer.ReadObject(stream) as Observation;
        }
    }
}
