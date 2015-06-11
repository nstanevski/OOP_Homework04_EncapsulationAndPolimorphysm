using System;

using Bank.Enumerators;
using Bank.Interfaces;
using Bank.Exceptions;

namespace Bank.Accounts
{
    public abstract class Account:IRateCalculator
    {
        private Customer customerType;
        private decimal ballance; //negative for loans and mortgages
        private double interestRate; //in percents

        protected Account(Customer customerType, decimal ballance, double interestRate)
        {
            this.CustomerType = customerType;
            this.Ballance = ballance;
            this.InterestRate = interestRate;

        }

        public Customer CustomerType 
        { 
            get
            {
                return this.customerType;
            }
            private set
            {
                if ((int)value < 0 || (int)value > 1)
                    throw new ArgumentOutOfRangeException("Invalid customer type");
                this.customerType = value;
            }
        }

        public decimal Ballance
        { 
            get
            {
                return this.ballance;
            }
            set
            {
                this.ballance = value;
            }
        }

        public double InterestRate 
        { 
            get
            {
                return this.interestRate;
            } 
            set
            {
                if(value<0.0 || value>100.0)
                    throw new ArgumentOutOfRangeException("Interest rate is between 0 and 100 %");
                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterest(int months);
        public abstract void Deposit(decimal amount);
        public virtual void Withdraw(decimal amount)
        {
            throw new UnathorizedTransactionException(
                "You cannot withdraw money from this type of account"
                );
        }

        public override string ToString()
        {
            return string.Format("Account type: {0} customer type: {1} ballance: {2:c} interest rate: {3:f2} %",
                this.GetType().Name, this.CustomerType, this.Ballance, this.InterestRate);
            
        }
    }
}
