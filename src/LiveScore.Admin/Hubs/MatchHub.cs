using System;
using System.Threading.Tasks;
using LiveScore.Admin.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace LiveScore.Admin.Hubs
{
    public class MatchHub : Hub<IMatchHub>
    {
        private readonly ILogger<MatchHub> logger;

        public MatchHub(ILogger<MatchHub> logger)
        {
            this.logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task AddToMatchAsync(string matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId);

            logger.LogInformation($"{Context.ConnectionId} is added to {matchId} group");
        }

        public async Task RemoveFromMatchAsync(string matchId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, matchId);

            logger.LogInformation($"{Context.ConnectionId} is removed from {matchId} group");
        }

        public async Task SendScoreAsync(string matchId, Score score)
        {
            await Clients.Group(matchId).SendScoreAsync(matchId, score);
        }
    }
}
