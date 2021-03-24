﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YhteenVetoHost : ContentPage
    {
        public YhteenVetoHost()
        {
            InitializeComponent();
        }
        async void LopetaClicked(object sender, EventArgs e)
        {
            //Sulkee kyselyn kaikilta osallisujilta (linjat poikki höhö XD)
        }
        async void JatkaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AktiviteettiäänestysEka());
        }
    }
}