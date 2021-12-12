using System;
using System.Collections.Generic;
using System.Text;

namespace Mikkel_Glerup_Code_Test.NewFolder
{
    class DateMenu
    {
        public DateTime CustomDateMenu()
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
    }
}
