using System.Text;
using System;
using System.Globalization;

namespace core
{
    public static class Calculator
    {
        public static string Calculate(string monthly1, bool isMarried, bool isBonus=false, string bonus="")
        {
            //According to fiscal year 2074/075;
            decimal firstLimitUn = 350000;
            decimal firstLimitMa = 400000;
            decimal secondLimitUn = 450000;
            decimal secondLimitMa = 500000;
            //decimal thirdLimitUn = 550000;
            //decimal thirdLimitMa = 600000;
            decimal monthly = Decimal.Parse(monthly1);
            decimal yearlyTax = 0M;
            decimal monthlyTax = 0M;
            decimal monthlyAfterTaxDeduction = 0M;
            decimal remainingAmount = 0M;
            decimal secondRemainingAmount = 0M;

            if (monthly!=0.00M ||  monthly.ToString() != String.Empty)
            {
                decimal yearly = monthly * 12;
                if (isMarried)
                {
                    if (yearly > 0 && yearly <= firstLimitMa)
                    {
                        yearlyTax = yearly * 0.01M;
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly-yearlyTax)/12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;

                    }
                    else if(yearly> firstLimitMa && yearly <= secondLimitMa)
                    {
                        remainingAmount = yearly - firstLimitMa;
                        yearlyTax = (remainingAmount * 0.15M)+ (yearly * 0.01M);
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if(yearly> secondLimitMa /*&& yearly <= thirdLimitMa*/)
                    {
                        remainingAmount = yearly - firstLimitMa;
                        secondRemainingAmount = remainingAmount - (secondLimitMa - firstLimitMa);

                        yearlyTax = (secondRemainingAmount*0.25M)+(remainingAmount * 0.15M) + (yearly * 0.01M);
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;

                    }
                    else
                    {

                    }
                }
                else
                {
                    if (yearly > 0 && yearly <= firstLimitUn)
                    {
                        yearlyTax = yearly * 0.01M;
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > firstLimitUn && yearly <= secondLimitUn)
                    {
                        remainingAmount = yearly - firstLimitUn;
                        yearlyTax = (remainingAmount * 0.15M) + (yearly * 0.01M);
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else if (yearly > secondLimitUn)
                    {
                        remainingAmount = yearly - firstLimitUn;
                        secondRemainingAmount = remainingAmount - (secondLimitMa - firstLimitMa);

                        yearlyTax = (secondRemainingAmount * 0.25M) + (remainingAmount * 0.15M) + (yearly * 0.01M);
                        monthlyTax = yearlyTax / 12;
                        monthlyAfterTaxDeduction = (yearly - yearlyTax) / 12;
                        monthlyAfterTaxDeduction = monthly - monthlyTax;
                    }
                    else
                    {

                    }
                }
                // return "Value Cannot be Null";
            }

            monthlyAfterTaxDeduction = decimal.Round(monthlyAfterTaxDeduction,2);
            return monthlyAfterTaxDeduction.ToString();
        }
    }
}