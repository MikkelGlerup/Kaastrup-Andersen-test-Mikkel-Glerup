using System;
using System.Collections.Generic;
using System.Text;

namespace Mikkel_Glerup_Code_Test
{
    public class BillingModel
    {
        public DateTime BillingDate { get; set; } = DateTime.Today;
        public int BillingHours { get; set; }
        public int HourlyWage { get; set; } = 150;
        public int ExpectedPay { get; set; }
    }
}
