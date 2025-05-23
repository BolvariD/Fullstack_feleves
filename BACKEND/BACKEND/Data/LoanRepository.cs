﻿using BACKEND.Model;

namespace BACKEND.Data
{
    public class LoanRepository : ILoanRepository
    {
        public List<Loan> repayments;
        public LoanRepository()
        {
            repayments = new List<Loan>();
        }

        void AddLoan(int amount, double interestRate)
        {
            for (int i = 5; i <= 25; i += 5)
            {
                Loan loan = new Loan();
                loan.Years = i;
                loan.RepayAmount = Calculate(amount, interestRate, i);
                double yearlyInterest = loan.RepayAmount / (i * 12);
                loan.InterestRate = yearlyInterest;
                repayments.Add(loan);
            }
        }

        long Calculate(int amount, double interestRate, int period)
        {
            return Convert.ToInt64(amount * Math.Pow((1 + interestRate / 100), period));
        }

        public IEnumerable<Loan> GetCalculations(int amount, double interestRate)
        {
            AddLoan(amount, interestRate);
            return repayments;
        }
    }
}
