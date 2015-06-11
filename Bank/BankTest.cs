using System;
using System.Collections.Generic;
using System.Linq;

using Bank.Enumerators;
using Bank.Interfaces;
using Bank.Accounts;
using Bank.Exceptions;

/*
 * A bank holds different types of accounts for its customers: deposit accounts, 
 * loan accounts and mortgage accounts. Customers could be individuals or companies.
 * All accounts have customer, balance and interest rate (monthly based). 
 * Deposit accounts are allowed to deposit and withdraw money. Loan and mortgage accounts 
 * can only deposit money.
 * All accounts can calculate their interest for a given period (in months) using the formula
 * A = money * (1 + interest rate * months) 
 *Loan accounts have no interest for the first 3 months if held by individuals and 
 * for the first 2 months if held by a company.
 * Deposit accounts have no interest if their balance is positive and less than 1000.
 * Mortgage accounts have ½ interest for the first 12 months for companies and no interest 
 * for the first 6 months for individuals.
 * Write a program to model the bank system with classes and interfaces. 
 * You should identify the classes, interfaces, base classes and abstract actions 
 * and implement the calculation of the interest functionality through overridden methods. 
 * Write a program to demonstrate that your classes work correctly.
 */

class BankTest
{
    static void Main()
    {
        List<Account> accounts = new List<Account>();

        Account depoComp = new DepositAccount(Customer.Company, 23500.00m, 3.23);
        Account depoInd = new DepositAccount(Customer.Individual, 33500.00m, 3.23);

        Account mortComp = new MortgageAccount(Customer.Company, 43500.00m, 8.23);
        Account mortInd = new MortgageAccount(Customer.Individual, 53500.00m, 9.23);

        Account loanComp = new LoanAccount(Customer.Company, 63500.00m, 13.23);
        Account loanInd = new LoanAccount(Customer.Individual, 73500.00m, 23.23);

        accounts.Add(depoComp);
        accounts.Add(depoInd);
        accounts.Add(mortComp);
        accounts.Add(mortInd);
        accounts.Add(loanComp);
        accounts.Add(loanInd);

        //throws exceptions if trying to withdraw from mortgate or loan account
        int months = 2;
        foreach (Account acc in accounts)
        {
            Console.WriteLine(acc);
            decimal withdrawAmount = 200m;
            Console.WriteLine("Trying to withdraw {0:c}", withdrawAmount);
            try
            {
                acc.Withdraw(withdrawAmount);
            }catch (UnathorizedTransactionException ex){
                    Console.WriteLine(ex.Message);
            }

            Console.WriteLine(acc);
            Console.WriteLine("Interest for {0} months is: {1:c}",
                months, acc.CalculateInterest(months));
            Console.WriteLine("===========================");


            months += 2;
        }




    }
}