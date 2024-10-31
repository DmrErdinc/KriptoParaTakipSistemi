using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace KriptoParaTakipSistemi
{
    public partial class DogecoinPaneli : Form
    {
        private static readonly HttpClient client = new HttpClient(); // HttpClient'i tekrar kullanılabilir hale getirin

        public DogecoinPaneli()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Büyütme butonunu kaldır
            this.MinimizeBox = false; // Küçültme butonunu kaldır
        }

        private void DogecoinPaneli_Load(object sender, EventArgs e)
        {
            btnDogeFiyatYenile.PerformClick();
        }

        private async Task KriptoFiyatlariniAl()
        {
            try
            {
                // CoinGecko API URL'si
                string url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,dogecoin,litecoin,avalanche,solana&vs_currencies=usd";
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode(); // Hata durumlarını yönetmek için

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject prices = JObject.Parse(responseBody);

                // Dogecoin fiyatını UI'de güncelle
                lblDogecoin.Text = $"Dogecoin: ${prices["dogecoin"]?["usd"]?.ToString()}";
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Ağ bağlantısı hatası: " + httpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private async void btnDogeFiyatYenile_Click(object sender, EventArgs e)
        {
            await KriptoFiyatlariniAl();
        }
    }
}
