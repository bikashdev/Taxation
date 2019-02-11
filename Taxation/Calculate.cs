using System.Text;
using System;
using System.Globalization;

namespace core
{
    public static class Calculator
    {
        public static string Calculate(string monthly1, bool isMarried, bool isBonus = false, string bonus = "")
        {
            //According to fiscal year 2075/076;

            decimal[] limitsMarried = { 400000, 500000, 700000, 2000000 };
            decimal[] limitsUnmarried = { 350000, 450000, 650000, 2000000 };

            decimal monthly = decimal.Parse(monthly1);
            //Tax Rates
            decimal[] SlabTaxRate = { 0.01m, 0.1m, 0.2m, 0.3m, 0.36m };

            //Taxable Amounts
            decimal[] taxableAmount = { 0m, 0m, 0m, 0m, 0m };

            decimal yearlyTax = 0m;/* { get; set; }*/
            decimal monthlyTax = 0m;/* { get; set; }*/
            decimal monthlyAfterTaxDeduction = 0m;/* { get; set; }*/

            if (monthly != 0.00M || monthly.ToString() != string.Empty)
            {
                decimal yearly = monthly * 12;
                if (isMarried)
                {
                    if (yearly > 0 && yearly <= limitsMarried[0])
                    {
                        taxableAmount[0] = yearly;
                        yearlyTax = taxableAmount[0] * SlabTaxRate[0];
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > limitsMarried[0] && yearly <= limitsMarried[1])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 2; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsMarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > limitsMarried[1] && yearly <= limitsMarried[2])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 3; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsMarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > limitsMarried[2] && yearly <= limitsMarried[3])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 4; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsMarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > limitsMarried[3])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 5; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsMarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                }
                else
                {
                    if (yearly > 0 && yearly <= limitsUnmarried[0])
                    {
                        yearlyTax = yearly * SlabTaxRate[0];
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > limitsUnmarried[0] && yearly <= limitsUnmarried[1])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 2; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsUnmarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > limitsUnmarried[1] && yearly <= limitsUnmarried[2])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 3; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsUnmarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                    }
                    else if (yearly > limitsUnmarried[2] && yearly <= limitsUnmarried[3])
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 4; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsUnmarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                    }
                    else
                    {
                        taxableAmount[0] = yearly;
                        for (int a = 0; a < 5; a++)
                        {
                            taxableAmount[a] = taxableAmount[0] - limitsUnmarried[a];
                            yearlyTax += taxableAmount[a] * SlabTaxRate[a];
                        }
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                    }
                }
                // return "Value Cannot be Null";
            }

            monthlyAfterTaxDeduction = decimal.Round(monthlyAfterTaxDeduction, 2);
            return monthlyAfterTaxDeduction.ToString();
        }


    }

    public class Tax
    {
        public decimal yearlyTax { get; set; }
        public decimal monthlyTax { get; set; }
        public decimal NetMonthlyIncome { get; set; }
        public decimal MonthlyIncome { get; set; }

        public decimal[] taxableAmount = { 0, 0, 0, 0, 0 };
        decimal[] limitsMarried = { 400000, 500000, 700000, 2000000 };
        decimal[] limitsUnmarried = { 350000, 450000, 650000, 2000000 };
        decimal[] SlabTaxRate = { 0.01m, 0.1m, 0.2m, 0.3m, 0.36m };
        public Tax TaxCalculater(bool isMarried, decimal yearlyIncome, int noOfFractions)
        {
            Tax taxation = new Tax();
            taxation.taxableAmount[0] = yearlyIncome;
            for (int t = 0; t < noOfFractions; t++)
            {
                if (isMarried)
                {
                    taxation.taxableAmount[t + 1] = taxableAmount[0] - limitsMarried[t];
                    taxation.yearlyTax += taxableAmount[t + 1] * SlabTaxRate[t];
                }
                else
                {
                    taxation.taxableAmount[t + 1] = taxableAmount[0] - limitsUnmarried[t];
                    taxation.yearlyTax += taxableAmount[t + 1] * SlabTaxRate[t];
                }
            }
            taxation.monthlyTax = yearlyTax / 12;
            taxation.NetMonthlyIncome = MonthlyIncome - monthlyTax;
            return taxation;
        }
    }
}