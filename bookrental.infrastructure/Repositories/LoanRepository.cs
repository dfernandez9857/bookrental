using Microsoft.EntityFrameworkCore;
using bookrental.core.Entities;
using bookrental.core.Interfaces.Repositories;
using bookrental.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.infrastructure.Repositories
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AreBooksAvailable(List<int> bookCopyIds)
        {
            
            var unavailableCount = await _context.BookCopies
                .Where(bc => bookCopyIds.Contains(bc.Id) &&
                            (!bc.IsLoanable || bc.LoanStatusId != 1)) // 1 = Disponible
                .CountAsync();

            return unavailableCount == 0;
        }
    }
}
