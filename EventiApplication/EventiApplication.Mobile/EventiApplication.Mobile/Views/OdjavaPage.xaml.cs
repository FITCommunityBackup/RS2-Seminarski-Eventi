﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventiApplication.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OdjavaPage : ContentPage
    {
        public OdjavaPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            OdjaviKorisnika();
        }

        private void OdjaviKorisnika()
        {
            Global.Korisnik = null;
            Application.Current.MainPage = new LoginPage(); //?
        }
    }
}