using bookrental.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Interfaces.Services
{
    public interface ILoanService
    {
        Task<Loan> CreateLoanAsync(Loan newLoan);

    }
}
