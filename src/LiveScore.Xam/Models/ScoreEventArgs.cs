using System;
namespace LiveScore.Xam.Models
{
    public class ScoreEventArgs : IScoreEventArgs
    {
        public Score Score { get; }

        public ScoreEventArgs(Score score)
        {
            this.Score = score;
        }
    }
}
