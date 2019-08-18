using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LiveScore.Xam.Models;

namespace LiveScore.Xam.Services
{
    public class MatchesService : IMatchesService
    {
        private IHttpRequester httpRequester;

        public MatchesService()
        {
            httpRequester = new HttpRequester(new System.Net.Http.HttpClientHandler());
        }

        public async Task<MatchViewModel> GetMatchById(int id)
        {
            var url = $"matches/{id}";
            return await httpRequester.GetItemAsync<MatchViewModel>(url);
        }

        public async Task<IEnumerable<MatchViewModel>> GetMatches()
        {
            var url = "matches";
            return await httpRequester.GetItemsAsync<MatchViewModel>(url);
        }
    }
}
