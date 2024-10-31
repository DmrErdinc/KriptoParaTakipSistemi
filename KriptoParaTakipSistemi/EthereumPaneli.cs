using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptoParaTakipSistemi
{
    public partial class EthereumPaneli : Form
    {
        public EthereumPaneli()
        {
            InitializeComponent();
            // Büyütme ve küçültme butonlarını kaldır
            this.MaximizeBox = false; // Büyütme butonunu kaldır
            this.MinimizeBox = false; // Küçültme butonunu kaldır
        }

        private void EthereumPaneli_Load(object sender, EventArgs e)
        {
            btnEthFiyatYenile.PerformClick();

        }
        private async Task KriptoFiyatlariniAl()
        {
            try
            {
                // 'using' ifadesini 8.0 altı sürümler için blok içinde kullanıyoruz
                using (HttpClient client = new HttpClient())
                {
                    // CoinGecko API URL'si
                    string url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,dogecoin,litecoin,avalanche,solana&vs_currencies=usd";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject prices = JObject.Parse(responseBody);

                        // Fiyatları Çek;
                        lblEthereum.Text = $"Ethereum: ${prices["ethereum"]?["usd"]?.ToString()}";

                    }
                    else
                    {
                        MessageBox.Show("Fiyatları çekerken bir hata oluştu. Lütfen tekrar deneyin.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private async void btnEthFiyatYenile_Click(object sender, EventArgs e)
        {
            await KriptoFiyatlariniAl();
        }

        private void lblEthAl_Click(object sender, EventArgs e)
        {

        }
    }
}
