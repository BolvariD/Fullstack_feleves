using BACKEND.Data;
using BACKEND.Model;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : Controller
    {
        ILoanRepository repo;

        public LoanController(ILoanRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<Loan> GetLoans(int amount, double interestRate)
        {
            return repo.GetCalculations(amount, interestRate);
        }
    }
}
