using System;

using Bank.Enumerators;
using Bank.Interfaces;


namespace Bank.Accounts
{
    class DepositAccount:Account
    {
        public DepositAccount(Customer accountType, decimal ballance, double interestRate):
            base(accountType, ballance, interestRate)
        {
                
        }
        
        public override decimal CalculateInterest(int months)
        {
            if (this.Ballance < 1000m)
                return 0.0m;
            return this.Ballance * (1.0m + (decimal)(this.InterestRate / 100.0) * months);
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    "Amount of money to deposit is always positive");
            this.Ballance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    "Amount of money to withdraw is always positive");
            if(amount > this.Ballance)
                throw new ArgumentOutOfRangeException(
                    "You cannot withdraw more than your current balance");

            this.Ballance -= amount;
        }


    }
}
