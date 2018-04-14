using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ChallongeStats {
    class ChallongeService {
        public static async Task<List<Participant>> GetListado(string challongeApiKey, string challongeId) {
            string url = "https://api.challonge.com/v1/tournaments/" + challongeId
                + "/participants.json?api_key=" + challongeApiKey;

            HttpClient client = new HttpClient {
                BaseAddress = new Uri(url)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<ParticipantContainer> participants = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                string jsonParticipants = await response.Content.ReadAsStringAsync();
                participants = JsonConvert.DeserializeObject<List<ParticipantContainer>>(jsonParticipants);
                response.Dispose();
                return participants.Select(i => i.Participant).ToList();
            } else {
                response.Dispose();
                return null;
            }
        }

        public static async Task<List<Match>> GetPartidas(string challongeApiKey, string challongeId, long participantId) {
            string url = "https://api.challonge.com/v1/tournaments/" + challongeId
                + "/participants/" + participantId + ".json?api_key=" + challongeApiKey + "&include_matches=1";

            HttpClient client = new HttpClient {
                BaseAddress = new Uri(url)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ParticipantContainer participant = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                string jsonParticipant = await response.Content.ReadAsStringAsync();
                participant = JsonConvert.DeserializeObject<ParticipantContainer>(jsonParticipant);
            }

            response.Dispose();
            return participant.Participant.Matches.Select(i => i.Match).OrderBy(i => i.CompletedAt == null ? DateTime.MaxValue : i.CompletedAt).ToList();
        }

    }
}
