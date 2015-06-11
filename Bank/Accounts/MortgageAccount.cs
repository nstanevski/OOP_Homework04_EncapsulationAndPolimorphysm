using System;

using Bank.Enumerators;
using Bank.Interfaces;


namespace Bank.Accounts
{
    public class MortgageAccount:Account
    {
        public MortgageAccount(Customer customerType, decimal ballance, double interestRate) :
            base(customerType, ballance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if (this.CustomerType == Customer.Individual)
            {
                if (months <= 6)
                    return 0.0m;
                else
                {
                    months -= 6;
                    return Math.Abs(this.Ballance) * 
                        (1.0m + (decimal)(this.InterestRate / 100.0) * months);
                }
            }
            else   //company
            {
                if (months <= 12)
                {
                    return 0.5m * Math.Abs(this.Ballance) *
                        (1.0m + (decimal)(this.InterestRate / 100.0) * months);
                }
                else
                {
                    return 0.5m * Math.Abs(this.Ballance) *
                        (1.0m + (decimal)(this.InterestRate / 100.0) * 12)
                        +
                        Math.Abs(this.Ballance) *
                        (1.0m + (decimal)(this.InterestRate / 100.0) * (months - 12));
                }
            }
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    "Amount of money to deposit is always positive");
            this.Ballance += amount;
        }
    }
}
