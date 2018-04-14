using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChallongeStats {
    [JsonObject(MemberSerialization.OptIn, Description = "match")]
    public class Match {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("player1_id")]
        public long? Player1Id { get; set; }

        [JsonProperty("player2_id")]
        public long? Player2Id { get; set; }

        [JsonProperty("winner_id")]
        public long? WinnerId { get; set; }

        [JsonProperty("loser_id")]
        public long? LoserId { get; set; }

        [JsonProperty("scores_csv")]
        public string ScoresCsv { get; set; }

        [JsonProperty("round")]
        public long Round { get; set; }

        [JsonProperty("group_id")]
        public long? GroupId { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        //[JsonProperty("suggested_play_order")]
        //public long? SuggestedPlayOrder { get; set; }
        
        public override string ToString() {
            return Player1Id + " vs " + Player2Id + ": " + ScoresCsv;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    class MatchContainer {
        [JsonProperty("match")]
        public Match Match { get; set; }

        public override string ToString() {
            return Match.ToString();
        }
    }
}