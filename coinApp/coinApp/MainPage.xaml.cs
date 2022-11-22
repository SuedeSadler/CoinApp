using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using coinApp.Model;

namespace coinApp
{
    public partial class MainPage : ContentPage
    {
        private string ApiKey = "F8E741AF-1EBC-432B-AF06-008E7E34594C";
        private string baseimageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        private List<Coin> coins;
        
        public MainPage()
        {
            InitializeComponent();
            coinListView.ItemsSource = GetCoins();
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            coinListView.ItemsSource = GetCoins();
        }
        private List<Coin> GetCoins()
        {
            List<Coin>coins;

            var client = new RestClient("http://rest.coinapi.io/v1/assets/?filter_asset_id=BTC;ETH;USDT;USDC;BNB;BUSD;XRP;DOGE");
            var request = new RestRequest();
            request.AddHeader("X-CoinAPI-Key", ApiKey);

            //var response = client.Execute<List<Coin>>(request);
            //var coins = response.Data;

            var response = client.Execute(request);
            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                if(!String.IsNullOrEmpty(c.Id_icon))
                    c.Icon_url = baseimageUrl + c.Id_icon.Replace("-", "") + ".png";
                else
                    c.Icon_url = "";
            }  
            return coins;
        }

        private async void AddCoin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new coinApp.AddCoin());
        }
    }
}
