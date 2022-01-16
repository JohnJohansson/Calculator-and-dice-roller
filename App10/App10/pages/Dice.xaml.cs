using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App10.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dice : ContentPage

    {
        //a interger var for the random nr generator
        private int randomNr;
        //Put the list outside so it can be read
        private readonly List<string> dices;
        public Dice()
        {
            //a list of strings with the dice images
            dices = new List<string>
            {
                "dice1.jpg",
                "dice2.jpg",
                "dice3.jpg",
                "dice4.jpg",
                "dice5.jpg",
                "dice6.jpg"
            };

            //Initilizing the component all the code after this
            //runs after it alredy got initilized
            InitializeComponent();

            image.Source = ImageSource.FromResource("App10.images.dice.png");
            image.WidthRequest = 150;
            image.HeightRequest = 150;
        }
        // the code for the dice rolling 
        // a randomizer that will show a dice image when you click the button 
        private void Roll_Btn(object sender, EventArgs e)
        {
            randomNr = new Random().Next(6);
            image.Source = ImageSource.FromResource("App10.images." + dices[randomNr]);
        }
    }
}