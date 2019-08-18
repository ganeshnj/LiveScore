using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LiveScore.Xam.Models;
using LiveScore.Xam.ViewModels;

namespace LiveScore.Xam.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MatchDetailPage : ContentPage
    {
        MatchDetailViewModel viewModel;

        public MatchDetailPage(MatchDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public MatchDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MatchDetailViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.MatchHubService.ConnectAsync();
            await viewModel.MatchHubService.AddToMatchAsync(viewModel.Match.Id.ToString());
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            await viewModel.MatchHubService.RemoveFromMatchAsync(viewModel.Match.Id.ToString());
            await viewModel.MatchHubService.DisconnectAsync();
        }
    }
}