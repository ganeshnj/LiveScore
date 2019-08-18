using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using LiveScore.Xam.Models;
using LiveScore.Xam.Views;

namespace LiveScore.Xam.ViewModels
{
    public class MatchesViewModel : BaseViewModel
    {
        public ObservableCollection<MatchViewModel> Matches { get; set; }
        public Command LoadMatchesCommand { get; set; }

        public MatchesViewModel()
        {
            Title = "Matches";
            Matches = new ObservableCollection<MatchViewModel>();
            LoadMatchesCommand = new Command(async () => await ExecuteLoadMatchesCommand());
        }

        async Task ExecuteLoadMatchesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Matches.Clear();
                var matches = await MatchesService.GetMatches();
                foreach (var match in matches)
                {
                    Matches.Add(match);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}