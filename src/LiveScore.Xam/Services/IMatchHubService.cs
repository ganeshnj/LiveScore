using System;
using System.Threading.Tasks;
using LiveScore.Xam.Models;

namespace LiveScore.Xam.Services
{
    public interface IMatchHubService
    {
        event EventHandler<ScoreEventArgs> OnReceivedScore;
        event EventHandler OnConnectionClosed;

        void Init();

        Task ConnectAsync();
        Task DisconnectAsync();

        Task AddToMatchAsync(string matchId);
        Task RemoveFromMatchAsync(string matchId);
    }
}
