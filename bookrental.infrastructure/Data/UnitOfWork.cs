using bookrental.core.Interfaces.Repositories;
using bookrental.core.Interfaces;
using bookrental.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private LoanRepository _loanRepository;
        private ClientRepository _clientRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public ILoanRepository LoanRepository => _loanRepository ??= new LoanRepository(_context);

        public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
