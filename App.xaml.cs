﻿using BloodConnect.Pages;
using Microsoft.Maui.Controls;

namespace BloodConnect
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }
    }
}
