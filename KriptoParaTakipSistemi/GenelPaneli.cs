using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; // JSON verisini işlemek için
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading.Tasks; // Bu metot kripto verilerini API'den çekmek için kullanılır



namespace KriptoParaTakipSistemi
{


    public partial class GenelPanel : Form
    {
        public GenelPanel()
        {
            InitializeComponent();
            // Büyütme ve küçültme butonlarını kaldır
            this.MaximizeBox = false; // Büyütme butonunu kaldır
            this.MinimizeBox = false; // Küçültme butonunu kaldır
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenelForm_FormÇıkış);
            // ComboBox için DropDown olayını bağlayın
            cmboxNeArıyorsun.DropDown += new EventHandler(cmboxNeArıyorsun_DropDown);
           

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            btnFiyatlarıYenile.PerformClick();
            btnGöstergePaneli.PerformClick();
        }
        private async void btnFiyatlarıYenile_Click(object sender, EventArgs e)
        {
            await KriptoFiyatlariniAl();
        }
        private void GenelForm_FormÇıkış(object sender, FormClosingEventArgs e)
        {
            // Çıkışın bir kez doğrulandığını kontrol edin
            if (!ÇıkışOnaylandı)
            {
                DialogResult result = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ÇıkışOnaylandı = true; // Kullanıcı çıkışı onayladı
                    Application.Exit(); // Uygulamayı kapat
                }
                else
                {
                    e.Cancel = true; // Kullanıcı iptal etti, form kapanmayacak
                }
            }
        }
        private bool ÇıkışOnaylandı = false;
        private async Task KriptoFiyatlariniAl()
        {
            try
            {
                // 'using' ifadesini 8.0 altı sürümler için blok içinde kullanıyoruz
                using (HttpClient client = new HttpClient())
                {
                    // CoinGecko API URL'si
                    string url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,dogecoin,litecoin,uniswap,solana&vs_currencies=usd";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject prices = JObject.Parse(responseBody);

                        // Fiyatları Çek;
                        lblBitcoin.Text = $"Bitcoin: ${prices["bitcoin"]?["usd"]?.ToString()}";
                        lblEthereum.Text = $"Ethereum: ${prices["ethereum"]?["usd"]?.ToString()}";
                        lblDogecoin.Text = $"Dogecoin: ${prices["dogecoin"]?["usd"]?.ToString()}";
                        lblLitecoin.Text = $"Litecoin: ${prices["litecoin"]?["usd"]?.ToString()}";
                        lblUniswap.Text = $"Uniswap: ${prices["uniswap"]?["usd"]?.ToString()}";
                        lblSolana.Text = $"Solana: ${prices["solana"]?["usd"]?.ToString()}";

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


        private void lblAd_Click(object sender, EventArgs e)
        {

        }
        private void lblHosgeldin_Click(object sender, EventArgs e)
        {

        }
        
        private void ptcrFotograf_Click(object sender, EventArgs e)
        {

        }
        private void btnGöstergePaneli_Click(object sender, EventArgs e)
        {

        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            TransferPaneli transferPaneli = new TransferPaneli();
            transferPaneli.ShowDialog();
        }
        private void btnCüzdan_Click(object sender, EventArgs e)
        {
            CüzdanPaneli cüzdanPaneli =new CüzdanPaneli();
            cüzdanPaneli.ShowDialog();
        }
        /*-------------------------------------------------------------------*/
        private void lblSolana_Click(object sender, EventArgs e)
        {

        }
        private void btnSolana_Click_1(object sender, EventArgs e)
        {
            SolanaPaneli solanaPaneli = new SolanaPaneli();
            solanaPaneli.ShowDialog();
        }
        private void ptcrSolana_Click(object sender, EventArgs e)
        {

        }
        /*-------------------------------------------------------------------*/
        private void lblDogecoin_Click(object sender, EventArgs e)
        {

        }
        private void btnDogecoin_Click(object sender, EventArgs e)
        {
            DogecoinPaneli Dogecoinpaneli = new DogecoinPaneli();
            Dogecoinpaneli.ShowDialog();
        }
        private void ptcrDogecoin_Click(object sender, EventArgs e)
        {

        }
        /*-------------------------------------------------------------------*/
        private void lblLitecoin_Click(object sender, EventArgs e)
        {

        }
        private void btnLitcoin_Click(object sender, EventArgs e)
        {
            LitcoinPaneli litcoinPaneli = new LitcoinPaneli();
            litcoinPaneli.ShowDialog();
        }
        private void ptcrLitcoin_Click(object sender, EventArgs e)
        {

        }
        /*-------------------------------------------------------------------*/
        private void lblBitcoin_Click(object sender, EventArgs e)
        {

        }
        private void btnBitcoin_Click(object sender, EventArgs e)
        {
            BitcoinPaneli göstergePaneli = new BitcoinPaneli();
            göstergePaneli.ShowDialog();
        }
        private void ptcrBitcoin_Click(object sender, EventArgs e)
        {

        }
        /*-------------------------------------------------------------------*/
        private void lblUniswap_Click(object sender, EventArgs e)
        {

        }
        private void btnUniswap_Click(object sender, EventArgs e)
        {
            UniswapPaneli uniswapPaneli = new UniswapPaneli();
            uniswapPaneli.ShowDialog();
        }
        private void ptcrUniswap_Click(object sender, EventArgs e)
        {

        }
        /*-------------------------------------------------------------------*/
        private void lblEthereum_Click(object sender, EventArgs e)
        {

        }
        private void btnEthereum_Click(object sender, EventArgs e)
        {
            EthereumPaneli EthereumPaneli = new EthereumPaneli();
            EthereumPaneli.ShowDialog();
        }
        private void ptcrEthereum_Click(object sender, EventArgs e)
        {

        }
        /*-------------------------------------------------------------------*/
      
        private void cmboxNeArıyorsun_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
        private void cmboxNeArıyorsun_DropDown(object sender, EventArgs e)
        {
            if (cmboxNeArıyorsun.Items.Count > 0) // Eğer ComboBox'ta eleman varsa
            {
                cmboxNeArıyorsun.SelectedIndex = 0; // İlk elemanı seç
            }
        }

        private void cmboxNeArıyorsun_KeyDown(object sender, KeyEventArgs e)
        {
            // Seçilen öğe "Bitcoin" ise BitcoinPaneli formunu aç
            if (cmboxNeArıyorsun.SelectedItem.ToString() == "Bitcoin")
            {
                BitcoinPaneli bitcoinForm = new BitcoinPaneli();
                bitcoinForm.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Ethereum")
            {
                EthereumPaneli ethereumPaneli = new EthereumPaneli();
                ethereumPaneli.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Dogecoin")
            {
                DogecoinPaneli ethereumPaneli = new DogecoinPaneli();
                ethereumPaneli.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Litcoin")
            {
                LitcoinPaneli litcoinPaneli = new LitcoinPaneli();
                litcoinPaneli.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Uniswap")
            {
                UniswapPaneli uniswapPaneli = new UniswapPaneli();
                uniswapPaneli.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Solana")
            {
                SolanaPaneli solanaPaneli = new SolanaPaneli();
                solanaPaneli.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Cüzdan")
            {
                CüzdanPaneli cüzdanPaneli = new CüzdanPaneli();
                cüzdanPaneli.Show();
            }
            else if (cmboxNeArıyorsun.SelectedItem.ToString() == "Transfer")
            {
                TransferPaneli transferPaneli = new TransferPaneli();
                transferPaneli.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir seçim yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Tuş olayını işlenmiş olarak işaretle
            e.Handled = true;
        }

        
    }
}   
