using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChallongeStats {
    [JsonObject(MemberSerialization.OptIn, Description = "participant")]
    class Participant {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("group_player_ids")]
        public List<long> GroupIds { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("matches")]
        public List<MatchContainer> Matches { get; set; }

        public override string ToString() {
            return Id + ":" + DisplayName;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    class ParticipantContainer {
        [JsonProperty("participant")]
        public Participant Participant { get; set; }

        public override string ToString() {
            return Participant.ToString();
        }
    }
}
