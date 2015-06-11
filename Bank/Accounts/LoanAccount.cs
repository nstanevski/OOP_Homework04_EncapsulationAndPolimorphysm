using System;

using Bank.Enumerators;
using Bank.Interfaces;

namespace Bank.Accounts
{
    public class LoanAccount:Account
    {
        public LoanAccount(Customer customerType, decimal ballance, double interestRate) :
            base(customerType, ballance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            int monthsNoInterest = this.CustomerType == Customer.Company ? 2 : 3;
            if (months <= monthsNoInterest)
                return 0.0m;

            months -= monthsNoInterest;
            return Math.Abs(this.Ballance) *(1.0m + (decimal)(this.InterestRate / 100.0) * months);
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
