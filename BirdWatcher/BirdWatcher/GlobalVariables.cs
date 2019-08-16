/**************************************************************************
* Contains commonly-used CONST variables used throughout the application  *
***************************************************************************/
namespace BirdWatcher
{
    class GlobalVariables
    {
        // Internal sizes
        public const int LENGTH_NOTE_EXCERPT = 60;

        public const int SIZE_FONT_HEADING = 36;
        public const int SIZE_FONT_SUBHEADING = 30;
        public const int SIZE_FONT_TEXT_LARGE = 26;
        public const int SIZE_FONT_TEXT = 22;
        public const int SIZE_FONT_TEXT_SMALL = 18;



        // User-facing text
        public const string LABEL_SPECIES = "Species:";
        public const string LABEL_RARITY = "Rarity:";
        public const string LABEL_NOTES = "Notes:";
        public const string LABEL_TIMESTAMP = "Timestamp:";

        public const string RARITY_COMMON = "Common";
        public const string RARITY_RARE = "Rare";
        public const string RARITY_EXTREMELY_RARE = "Extremely Rare";

        // Internal message text
        public const string MESSAGE_DATA_SAVED = "DataSaved";
        public const string PREFERENCE_DATA_NOT_FOUND = "Preference data not found, at key!";
    }
}
