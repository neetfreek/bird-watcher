/**************************************************************************
* Represents Observation objects                                          *
* 1. Contains Observation details as properties, assigned to via          *
*       constructor when objects created.                                 *
***************************************************************************/
using System;
using System.Runtime.Serialization;

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
        [DataMember]
        public readonly string Timestamp = "";

        public Observation(string species, string notes, string rarity)
        {
            Species = species;
            Notes = notes;
            Rarity= rarity;
            Timestamp = DateTime.Now.ToString("G");
        }
    }
}
