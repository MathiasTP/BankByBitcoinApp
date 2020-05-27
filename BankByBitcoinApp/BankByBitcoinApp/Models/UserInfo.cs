using System;
using System.Collections.Generic;
using System.Text;

namespace BankByBitcoinApp.Models
{
    public class UserInfo
    {
       public string id { get; set; }
       public string navn { get; set; }

       public string email { get; set; }

       public int InitialInvestment { get; set; }

       public double BTCPriceAtInvest { get; set; }
    }
}
