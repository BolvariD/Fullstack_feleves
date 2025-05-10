using BACKEND.Model;

namespace BACKEND.Data
{
    public interface ILoanRepository
    {
        public IEnumerable<Loan> GetCalculations(int amount, double interestRate);
    }
}
