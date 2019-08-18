using System;
using System.Threading.Tasks;
using LiveScore.Admin.Models;

namespace LiveScore.Admin.Hubs
{
    public interface IMatchHub
    {
        Task AddToMatchAsync(string matchId);
        Task RemoveFromMatch(string matchId);
        Task SendScoreAsync(string matchId, Score score);
    }
}
