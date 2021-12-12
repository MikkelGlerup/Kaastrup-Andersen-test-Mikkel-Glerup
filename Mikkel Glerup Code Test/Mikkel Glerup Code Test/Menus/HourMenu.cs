using System;
using System.Collections.Generic;
using System.Text;

namespace Mikkel_Glerup_Code_Test.NewFolder
{
    class HourMenu
    {
        public int CustomHoursMenu(BillingModel billingModel)
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
