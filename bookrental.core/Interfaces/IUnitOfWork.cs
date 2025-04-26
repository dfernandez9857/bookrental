using bookrental.core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILoanRepository LoanRepository { get; }

        IClientRepository ClientRepository { get; }

        Task<int> CommitAsync();
    }
}
