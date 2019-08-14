using System;
using System.Collections.Generic;
using System.Text;

namespace BirdWatcher
{
    public class Observation
    {
        public readonly string Species = "";
        public readonly string Notes = "";
        public readonly string Rarity = "";

        public Observation(string species, string notes, string rarity)
        {
            Species = species;
            Notes = notes;
            Rarity= rarity;
        }
    }
}
