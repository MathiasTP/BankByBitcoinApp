using BankByBitcoinApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankByBitcoinApp.Services
{
    public interface IRestService
    {
        Task<UserInfo> GetUserInfo(string id);

        Task<List<LoginInfo>> GetLoginInfo();
        Task<bool> VerifyLogin();

        Task<BTC> GetBitcoinPrice();
    }
}
