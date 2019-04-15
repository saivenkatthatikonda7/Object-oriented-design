using System;
using System.Collections.Generic;
using System.Linq;

namespace altSrc
{


    public class userAccount
    {
        private Dictionary<string, double> Ledger = new Dictionary<string, double>();

        private bool loggedIn = false;



        public userAccount()
        {

        }


        public bool GetLoggedIn()
        {
            return this.loggedIn;
        }

        public void SetLoggedIn(bool value)
        {
            this.loggedIn = value;
        }

        public void AddLedgerDeposit(String itemName,double cost)
        {
            this.Ledger.Add(itemName, cost);
        }

        public void AddLedgerWithdrawl(String itemName, double cost)
        {
            this.Ledger.Add(itemName, -(cost));
        }
        public double CheckBalance()
        {
            return Ledger.Sum(x => x.Value);
        }

        public void ShowTransactionHistory()
        {
            foreach (var entry in Ledger)
            {
                // do something with entry.Value or entry.Key
                Console.WriteLine("Transaction name : " + entry.Key + " Transaction value: " + entry.Value );
            }
        }


    }
}
