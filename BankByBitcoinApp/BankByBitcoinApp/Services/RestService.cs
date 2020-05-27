using BankByBitcoinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BankByBitcoinApp.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public UserInfo UserInfos { get; set; }
        public List<LoginInfo> LoginInfos { get; set; }

        public BTC bitcoinprice { get; set; }

        public static string BaseAddress =
        Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public RestService()
        {
            var handler = GetInsecureHandler();

            _client = new HttpClient(handler);
        }
        public async Task<UserInfo> GetUserInfo(string id)
        {
            UserInfos = new UserInfo();

            try
            {
                var response = await _client.GetAsync(BaseAddress + $"/api/UserInfoes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    UserInfos = JsonConvert.DeserializeObject<UserInfo>(content);
                    App.userinfo = UserInfos;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return UserInfos;
        }

        public Task<bool> VerifyLogin()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LoginInfo>> GetLoginInfo()
        {
            LoginInfos = new List<LoginInfo>();

            try
            {
                var response = await _client.GetAsync("https://10.0.2.2:5001/api/LoginInfo");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LoginInfos = JsonConvert.DeserializeObject<List<LoginInfo>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return LoginInfos;
        }

        public async Task<BTC> GetBitcoinPrice()
        {

            try
            {
                var response = await _client.GetAsync("https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd&include_24hr_change=true");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    bitcoinprice = JsonConvert.DeserializeObject<BTC>(content);
                    App.BitcoinPrice = bitcoinprice.bitcoin.usd;
                    App.BitcoinChange = bitcoinprice.bitcoin.usd_24h_change;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return bitcoinprice;
        }
    }
}
