using BankByBitcoinApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankByBitcoinApp.Services
{
   public class ServiceManager
    {
        IRestService restService;

        public ServiceManager(IRestService service)
        {
            restService = service;
        }

        public Task<UserInfo> GetUserInfo(string id)
        {
            return restService.GetUserInfo(id);
        }

        public Task<List<LoginInfo>> GetLoginInfo()
        {
            return restService.GetLoginInfo();
        }

        public Task<BTC> GetBitcoinPrice()
        {
            return restService.GetBitcoinPrice();
        }
    }
}
