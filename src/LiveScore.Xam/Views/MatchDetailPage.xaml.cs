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
    }
}