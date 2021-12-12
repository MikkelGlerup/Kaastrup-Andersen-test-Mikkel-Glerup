using Mikkel_Glerup_Code_Test.NewFolder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mikkel_Glerup_Code_Test
{
    public class MainMenu
    {
        DateMenu dateMenu  = new DateMenu();
        HourMenu HourMenu  = new HourMenu();
        public bool MenuHub()
        {
            Console.WriteLine("Welcome. Please choose a date option:");
            Console.WriteLine($"1) Todays date ({DateTime.Today.ToShortDateString()})");
            Console.WriteLine("2) Custom date");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            BillingModel billingModel = new BillingModel();
            PayCalculator payCalculator = new PayCalculator();
            switch (Console.ReadLine())
            {
                case "1":
                    billingModel.BillingHours = HourMenu.CustomHoursMenu(billingModel);
                    billingModel = payCalculator.CalculatePay(billingModel);
                    break;
                case "2":
                    billingModel.BillingDate = dateMenu.CustomDateMenu();
                    billingModel.BillingHours = HourMenu.CustomHoursMenu(billingModel);
                    billingModel = payCalculator.CalculatePay(billingModel);
                    break;
                case "3":
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("Please choose an option.\n");
                    return true;
            }

            Console.Clear();
            Console.WriteLine($"Your expected pay is:\n{billingModel.ExpectedPay}");
            Console.Write("\r\nPress key to return to menu.");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
    }
}
