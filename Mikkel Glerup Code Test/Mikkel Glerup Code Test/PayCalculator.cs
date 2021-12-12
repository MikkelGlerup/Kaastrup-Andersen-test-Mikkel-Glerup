using System;
using System.Collections.Generic;
using System.Text;

namespace Mikkel_Glerup_Code_Test
{
    public class PayCalculator
    {
        private PaySheet m_paySheet { get; set; }
        public PayCalculator()
        {
            m_paySheet = new PaySheet();
        }

        
        public BillingModel CalculatePay(BillingModel billingModel)
        {

            if (billingModel.BillingDate.DayOfWeek == DayOfWeek.Saturday || billingModel.BillingDate.DayOfWeek == DayOfWeek.Sunday)
                billingModel.BillingHours = WeekendBonus(billingModel);

            if (billingModel.BillingHours > 3)
                billingModel.BillingHours = ExtraHourBonus(billingModel);

            if (billingModel.BillingHours > 7)
                billingModel.ExpectedPay = SalaryBonus(billingModel);

            billingModel.ExpectedPay = CalculateSalary(billingModel);
            return billingModel;
        }
        private int WeekendBonus(BillingModel billingModel)
        {         
                return billingModel.BillingHours *= m_paySheet.WeekendBonus;
        }
        private int ExtraHourBonus(BillingModel billingModel)
        {
                return billingModel.BillingHours + m_paySheet.BonusHours;
        }
        private int SalaryBonus(BillingModel billingModel)
        {
                return billingModel.ExpectedPay = m_paySheet.OvertimePay;
        }
        private int CalculateSalary(BillingModel billingModel)
        {
            billingModel.ExpectedPay += billingModel.BillingHours * billingModel.HourlyWage;

            return billingModel.ExpectedPay;
        }

        public PaySheet paySheet
        {
            get { return m_paySheet; }
        }
    }
}
