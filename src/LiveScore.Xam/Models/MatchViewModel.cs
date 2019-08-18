using System;
using LiveScore.Xam.ViewModels;

namespace LiveScore.Xam.Models
{
    public class MatchViewModel : ExtendedBindableObject
    {
        public int Id { get; set; }

        private TeamViewModel team1;
        public TeamViewModel Team1
        {
            get { return team1; }
            set { SetProperty(ref team1, value); }
        }

        private TeamViewModel team2;
        public TeamViewModel Team2
        {
            get { return team2; }
            set { SetProperty(ref team2, value); }
        }

        private int team1Score;
        public int Team1Score
        {
            get { return team1Score; }
            set { SetProperty(ref team1Score, value); }
        }

        private int team2Score;
        public int Team2Score
        {
            get { return team2Score; }
            set { SetProperty(ref team2Score, value); }
        }

        private MatchStatusViewModel status;
        public MatchStatusViewModel Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }
    }
}
