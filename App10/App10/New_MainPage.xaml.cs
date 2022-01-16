using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//This page connects to the New_MainPage.XAML here the functions exist and on the other page is the styling
namespace App10
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class New_MainPage : ContentPage
    {
        public New_MainPage()
        {
            InitializeComponent();
        }
        private async void Btn_Clicked1(object sender, EventArgs e)
        {
            //Calculator page
            await this.Navigation.PushAsync(new pages.Calculator());
        }
        private async void Btn_Clicked2(object sender, EventArgs e)
        {
            //Dice page
            await this.Navigation.PushAsync(new pages.Dice());
        }
    }
}