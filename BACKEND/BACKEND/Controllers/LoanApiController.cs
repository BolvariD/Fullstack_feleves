using BACKEND.Data;
using BACKEND.Model;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanApiController : Controller
    {
        ILoanRepository repo;

        public LoanApiController(ILoanRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<Loan> GetLoans()
        {
            return repo.GetAll();
        }

        [HttpPost]
        public void PostLoans(int amount, double interestRate)
        {
            repo.AddLoan(amount, interestRate);
        }
    }
}
