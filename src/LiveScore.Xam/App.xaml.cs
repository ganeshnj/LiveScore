﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiveScore.Xam.Services;
using LiveScore.Xam.Views;

namespace LiveScore.Xam
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MatchesService>();
            DependencyService.Register<MatchHubService>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
