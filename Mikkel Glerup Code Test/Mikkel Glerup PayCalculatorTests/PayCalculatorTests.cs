using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikkel_Glerup_Code_Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mikkel_Glerup_Code_Test.Tests
{
    [TestClass()]
    public class PayCalculatorTests
    {
        PayCalculator payCalculator = new PayCalculator();
        BillingModel billingModelTest = new BillingModel();
        DateTime WeekDay = new DateTime(2021, 12, 13);
        DateTime Holiday = new DateTime(2021, 12, 12);
        Random randomHour = new Random();

        [TestMethod()]
        public void ThreeHourExtraHourTest()
        {
            billingModelTest.BillingDate = WeekDay;
            billingModelTest.BillingHours = randomHour.Next(4, 100);
            int expectedHours = billingModelTest.BillingHours + payCalculator.paySheet.BonusHours;

            billingModelTest = payCalculator.CalculatePay(billingModelTest);

            int actualHours = billingModelTest.BillingHours;
            Assert.AreEqual(expectedHours, actualHours);
        }
        [TestMethod()]
        public void ThreeHourExtraHourTestFail()
        {
            billingModelTest.BillingDate = WeekDay;
            billingModelTest.BillingHours = randomHour.Next(4);
            int expectedHours = billingModelTest.BillingHours + payCalculator.paySheet.BonusHours;

            billingModelTest = payCalculator.CalculatePay(billingModelTest);

            int actualHours = billingModelTest.BillingHours;
            Assert.AreNotEqual(expectedHours, actualHours);
        }

        [TestMethod()]
        public void WeekendBonus()
        {
            billingModelTest.BillingDate = Holiday;
            billingModelTest.BillingHours = randomHour.Next(0, 100);
            int expectedHours = billingModelTest.BillingHours * payCalculator.paySheet.WeekendBonus;
            if (billingModelTest.BillingHours > 3)
            {
                expectedHours = expectedHours + payCalculator.paySheet.BonusHours;
            }

            billingModelTest = payCalculator.CalculatePay(billingModelTest);

            int actualHours = billingModelTest.BillingHours;
            Assert.AreEqual(expectedHours, actualHours);
        }
        [TestMethod()]
        public void WeekendBonusFail()
        {
            billingModelTest.BillingDate = WeekDay;
            billingModelTest.BillingHours = randomHour.Next(0, 100);
            int expectedHours = billingModelTest.BillingHours * payCalculator.paySheet.WeekendBonus;
            if (billingModelTest.BillingHours > 3)
            {
                expectedHours = expectedHours + payCalculator.paySheet.BonusHours;
            }

            billingModelTest = payCalculator.CalculatePay(billingModelTest);

            int actualHours = billingModelTest.BillingHours;
            Assert.AreNotEqual(expectedHours, actualHours);
        }
        [TestMethod()]
        public void CalculatePayTest()
        {
            billingModelTest.BillingDate = WeekDay;
            billingModelTest.BillingHours = randomHour.Next(7, 100);
            int expectedHours = billingModelTest.BillingHours;
            if (billingModelTest.BillingHours > 3)
            {
                expectedHours = expectedHours + payCalculator.paySheet.BonusHours;
            }
            int expectedPay = expectedHours * billingModelTest.HourlyWage + payCalculator.paySheet.OvertimePay;

            billingModelTest = payCalculator.CalculatePay(billingModelTest);

            int actualPay = billingModelTest.ExpectedPay;
            Assert.AreEqual(expectedPay, actualPay);
        }
        [TestMethod()]
        public void CalculatePayFail()
        {
            billingModelTest.BillingDate = WeekDay;
            billingModelTest.BillingHours = randomHour.Next(0, 6); ;
            int expectedHours = billingModelTest.BillingHours;
            if (billingModelTest.BillingHours > 3)
            {
                expectedHours = expectedHours + payCalculator.paySheet.BonusHours;
            }
            int expectedPay = expectedHours * billingModelTest.HourlyWage + payCalculator.paySheet.OvertimePay;

            billingModelTest = payCalculator.CalculatePay(billingModelTest);

            int actualPay = billingModelTest.ExpectedPay;
            Assert.AreNotEqual(expectedPay, actualPay);
        }
    }
}