using BACKEND.Model;

namespace BACKEND.Data
{
    public interface ILoanRepository
    {
        public void AddLoan(int amount, double interestRate);
        public IEnumerable<Loan> GetAll();
    }
}
