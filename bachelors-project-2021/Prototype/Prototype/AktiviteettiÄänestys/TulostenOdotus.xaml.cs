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
    public partial class TulostenOdotus : ContentPage
    {

        private int _countSeconds = 20;

        public TulostenOdotus()
        {
            InitializeComponent();

  

            //poistetaan turha navigointipalkki
            NavigationPage.SetHasNavigationBar(this, false); 

            //Siirrytään aktiviteettin äänestykseen tuloksiin 10s kuluttua. (timer testi) 


            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _countSeconds--;

                 timer.Text = _countSeconds.ToString();
                

                 if (_countSeconds == 0) {
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        Navigation.PushAsync(new AktiviteettiäänestysTulokset());
                        return false;
                    });

                  
                 }

                return Convert.ToBoolean(_countSeconds);
            });

            Task.Run( () => Main.GetInstance().host.RunActivityVote() );


        }


        //Device back button disabled
        protected override bool OnBackButtonPressed()
        {
            return true;

        }




    }
}