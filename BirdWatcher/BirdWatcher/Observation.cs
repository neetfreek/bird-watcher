using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BirdWatcher
{
    [DataContract]
    public class Observation
    {
        [DataMember]
        public readonly string Species = "";
        [DataMember]
        public readonly string Notes = "";
        [DataMember]
        public readonly string Rarity = "";

        public Observation(string species, string notes, string rarity)
        {
            Species = species;
            Notes = notes;
            Rarity= rarity;
        }
    }
}
