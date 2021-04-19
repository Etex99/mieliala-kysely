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
    public partial class LuoKyselyJohdatus : ContentPage
    {

        public IList<string> introMessage { get; set; }
        public string selectedItem = null;



        public LuoKyselyJohdatus()
        {
            InitializeComponent();

            introMessage = Const.intros;



            if(Main.GetInstance().GetMainState() == Main.MainState.Editing)
            {
                selectedItem = SurveyManager.GetInstance().GetSurvey().introMessage;
                JButton.Text = selectedItem;
                JatkaBtn.IsEnabled = true;
            }
           

       
            BindingContext = this;


 
        }

        private void btnPopupButton_Clicked(object sender, EventArgs e)
        {
           

            if (popupSelection.IsVisible == false)
            {

                popupSelection.IsVisible = true; 
            }

            else if (popupSelection.IsVisible == true)
            {

                popupSelection.IsVisible = false;
            }

        }

   


        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = e.CurrentSelection[0] as string;

            //Change the text of the button based on selected intro message
            
            if (selectedItem != null) { 
               JButton.Text = selectedItem;
                JatkaBtn.IsEnabled = true;
            }

            else
                JButton.Text = "Valitse johdatuslause";
        }



        async void JatkaButtonClicked(object sender, EventArgs e)
        {
            //kyselyn johdatuslause asetetaan.
            SurveyManager.GetInstance().GetSurvey().introMessage = selectedItem;
          

            //siirrytään "luo uus kysely 2/3" sivulle 
            await Navigation.PushAsync(new LuoKyselyEmojit());
        }

        async void PeruutaButtonClicked(object sender, EventArgs e)
        {
            //survey resetoidaan
            SurveyManager.GetInstance().ResetSurvey();

            //Jos ollaan edit tilassa, niin siirrytään takaisin kyselyntarkastelu sivulle, muutoin main menuun
            if(Main.GetInstance().GetMainState() == Main.MainState.Editing)
            {
                Main.GetInstance().BrowseSurveys();
                await Navigation.PopAsync();
            }
            else
            {
                // siirrytään etusivulle
                await Navigation.PopToRootAsync();
            }
        }
    }

  
}