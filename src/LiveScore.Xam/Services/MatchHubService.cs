using System;
using System.Threading.Tasks;
using LiveScore.Xam.Helpers;
using LiveScore.Xam.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace LiveScore.Xam.Services
{
    public class MatchHubService : IMatchHubService
    {
        public event EventHandler<ScoreEventArgs> OnReceivedScore;
        public event EventHandler OnConnectionClosed;

        private HubConnection hubConnection;

        public void Init()
        {
            var url = $"https://{Settings.HubServer}/match";
            hubConnection = new HubConnectionBuilder().WithUrl(url).Build();
            hubConnection.Closed += HubConnection_Closed;
            hubConnection.On<string, Score>("ReceiveScore", (matchId, score) =>
            {
                OnReceivedScore?.Invoke(this, new ScoreEventArgs(score));
            });
        }

        private Task HubConnection_Closed(Exception arg)
        {
            OnConnectionClosed.Invoke(this, null);
            return Task.CompletedTask;
        }

        public async Task ConnectAsync()
        {
            if (hubConnection.State == HubConnectionState.Connected)
            {
                return;
            }

            await hubConnection.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            if (hubConnection.State != HubConnectionState.Connected)
                return;

            await hubConnection.StopAsync();
        }

        public async Task RemoveFromMatchAsync(string matchId)
        {
            await hubConnection.SendAsync("RemoveFromMatchAsync", matchId);
        }

        public async Task AddToMatchAsync(string matchId)
        {
            await hubConnection.SendAsync("AddToMatchAsync", matchId);
        }
    }
}
