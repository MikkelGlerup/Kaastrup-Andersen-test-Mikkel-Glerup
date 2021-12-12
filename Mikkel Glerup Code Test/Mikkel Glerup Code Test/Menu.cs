using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mikkel_Glerup_Code_Test
{
    public class Menu
    {
        public bool MainMenu()
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
                    billingModel.BillingHours = CustomHoursMenu(billingModel);
                    billingModel = payCalculator.CalculatePay(billingModel);
                    break;
                case "2":
                    billingModel.BillingDate = CustomDateMenu();
                    billingModel.BillingHours = CustomHoursMenu(billingModel);
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
        private DateTime CustomDateMenu()
        {
            List<String> timeStrings = new List<String>();
            
            Console.Clear();
            Console.WriteLine("Enter day: ");
            timeStrings.Add(Console.ReadLine());


            Console.WriteLine("Enter month: ");
            timeStrings.Add(Console.ReadLine());

            timeStrings.Add(System.DateTime.Now.Year.ToString());


            var result = String.Join("/", timeStrings);

            DateTime dateValue;
            //DD/MM//YY
            if (!DateTime.TryParse(result, out dateValue))
            {
                Console.WriteLine("Please enter correct dates.\n Press key to reenter");
                Console.ReadKey();
                CustomDateMenu();
            }

            Console.Clear();
            Console.WriteLine(dateValue.Date.ToShortDateString());
            Console.WriteLine("is this date correct?");
            Console.WriteLine("1) Yes");
            Console.WriteLine("2) No");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    BillingModel billingModel = new BillingModel();
                    billingModel.BillingDate = dateValue;
                    return billingModel.BillingDate;
                default:
                    CustomDateMenu();
                    break;
            }
            return DateTime.MinValue;
        }

        private int CustomHoursMenu(BillingModel billingModel)
        {
            Console.Clear();
            Console.WriteLine("Please enter amount of hours worked: ");

            if (!int.TryParse(Console.ReadLine(), out int AmountOfHours) || AmountOfHours > 24 || AmountOfHours < 0)
            {
                Console.Clear();
                Console.WriteLine("None for you");
                Console.WriteLine("\nPress a key to reenter hours");
                Console.ReadKey();
                CustomHoursMenu(billingModel);
            }
            else
            {
                billingModel.BillingHours = AmountOfHours;
            }

            return billingModel.BillingHours;
        }

        
    }
}
