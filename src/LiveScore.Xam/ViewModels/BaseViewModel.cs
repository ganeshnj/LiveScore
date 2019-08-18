using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using LiveScore.Xam.Models;
using LiveScore.Xam.Services;

namespace LiveScore.Xam.ViewModels
{
    public class BaseViewModel : ExtendedBindableObject
    {
        public IMatchesService MatchesService => DependencyService.Get<IMatchesService>() ?? new MatchesService();
        public IMatchHubService MatchHubService => DependencyService.Get<IMatchHubService>() ?? new MatchHubService();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public BaseViewModel()
        {
            MatchHubService.Init();
        }
    }
}
