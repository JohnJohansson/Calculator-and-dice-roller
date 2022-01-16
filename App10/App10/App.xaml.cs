﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App10
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage(); makes a new mainpage where we can navigate from
            MainPage =new NavigationPage (new New_MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
