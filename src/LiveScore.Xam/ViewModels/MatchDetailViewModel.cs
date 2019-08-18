using System;

using LiveScore.Xam.Models;

namespace LiveScore.Xam.ViewModels
{
    public class MatchDetailViewModel : BaseViewModel
    {
        private MatchViewModel match;
        public MatchViewModel Match
        {
            get { return match; }
            set { SetProperty(ref match, value); }
        }
        public MatchDetailViewModel(MatchViewModel match = null)
        {
            Title = $"{match?.Team1.Name} vs {match.Team2.Name}";
            Match = match;
        }
    }
}
