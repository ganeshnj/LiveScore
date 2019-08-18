using System;
namespace LiveScore.Models
{
    public class Match
    {
        public int Id { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public MatchStatus Status { get; set; }
    }
}
