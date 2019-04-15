using System;
using System.Collections.Generic;

namespace altSrc
{
    class Program
    {
      
        private static Dictionary<String, String> Accounts = new Dictionary<String,String>();
        private static Dictionary<String,userAccount> userLedgers= new Dictionary<String,userAccount>();
        private static userAccount user1;

        //function to create the user
        public static void createUser(String id,String password)
        {
            if (!Accounts.ContainsKey(id))
            {
                Accounts.Add(id, password);
                userLedgers.Add(id, new userAccount());
                Console.WriteLine("Account has been created Successfully \n");

            }
            else
            {
                Console.WriteLine("Account creation failed.Username already exists! please choose another username and try again \n");
            }
        }

        /*login validation is done in this function
        if the login is successfull it returns the respective user's ledger
        */      
        public static userAccount login(String id,String password)
        {
            if(Accounts.ContainsKey(id) && Accounts[id] == password)
            {
                return userLedgers[id];
            }

            else
            {
                return null;
            }
        }


        static void Main(string[] args)
        {

            choose();
        }

        static void choose()
        {

            Console.WriteLine("Choose an option: \n" +
                "0.Create Account \n"+
                "1.Login, \n" +
                "2.Record a Deposit,\n" +
                "3.Record a Withdrawl,\n" +
                "4.Check Balance,\n" +
                "5.See Transaction history,\n" +
                "6.Logout,\n" +
                "7.Exit.");

            int option = Convert.ToInt32(Console.ReadLine());


            switch(option)
            {
                case 0:
                    Console.WriteLine("Enter username for the account \n");
                    String userName = Console.ReadLine();
                    Console.WriteLine("Enter the password for your account \n");
                    String password = Console.ReadLine();
                    createUser(userName, password);

                    choose();
                    break;
                case 1:
                    if (user1 == null) {
                        Console.WriteLine("Enter the username: \n");
                        String Uid = Console.ReadLine();
                        Console.WriteLine("Enter the password: \n");
                        String Upassword = Console.ReadLine();

                        user1 = login(Uid, Upassword);

                        if (user1 != null)
                        {
                            user1.SetLoggedIn(true);

                            Console.WriteLine("login successful! \n");
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please check username and password \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are already logged in \n");
                    }
            
                    choose();
                    break;


                case 2:
                    if (user1 != null && user1.GetLoggedIn())
                    {
                        Console.WriteLine("Enter the name of the deposit you want to add in the ledger \n");
                        String name = Console.ReadLine();
                        Console.WriteLine("Enter the value of the deposit \n");
                        Double deposit = Convert.ToDouble(Console.ReadLine());
                        user1.AddLedgerDeposit(name, deposit);
                        Console.WriteLine("Deposit successfully \n");
                     
                    }
                    else
                    {
                        Console.WriteLine("You are not logged in, please login and try again. \n");

                    }
                    choose();
                    break;


                case 3:
                    if (user1 != null && user1.GetLoggedIn())
                    {
                        Console.WriteLine("Enter the reason for the withdrawl you want to add in the ledger \n");
                        String name1 = Console.ReadLine();
                        Console.WriteLine("Enter the amount you want to withdraw \n");
                        Double withdrawl = Convert.ToDouble(Console.ReadLine());
                        user1.AddLedgerWithdrawl(name1, withdrawl);
                        Console.WriteLine("withdrawl successfully \n");
                    }
                    else
                    {
                        Console.WriteLine("You are not logged in, please login and try again. \n");

                    }
                    choose();
                    break;


                case 4:
                    if (user1 != null && user1.GetLoggedIn())
                    {
                        Console.WriteLine("The current balance in your account is  " + user1.CheckBalance());
                    }
                    else
                    {
                        Console.WriteLine("You are not logged in, please login and try again. \n");

                    }
                    choose();
                    break;


                case 5:
                    if (user1 != null && user1.GetLoggedIn())
                    {
                        Console.WriteLine("Transaction history:");
                        user1.ShowTransactionHistory();
                    }
                    else
                    {
                        Console.WriteLine("You are not logged in, please login and try again. \n");

                    }
                    choose();
                    break;

                case 6:
                    user1.SetLoggedIn(false);
                    user1 = null;
                    Console.WriteLine("you successfully logged out \n");
                    choose();
                    break;
            }


        }
    }

}
