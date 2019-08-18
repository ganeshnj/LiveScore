using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LiveScore.Xam.Models;
using LiveScore.Xam.Views;
using LiveScore.Xam.ViewModels;

namespace LiveScore.Xam.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MatchesPage : ContentPage
    {
        MatchesViewModel viewModel;

        public MatchesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MatchesViewModel();
            MatchesListView.ItemSelected += MatchesListView_ItemSelected;
        }

        private async void MatchesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MatchViewModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new MatchDetailPage(new MatchDetailViewModel(item)));

            // Manually deselect item.
            MatchesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Matches.Count == 0)
                viewModel.LoadMatchesCommand.Execute(null);
        }
    }
}