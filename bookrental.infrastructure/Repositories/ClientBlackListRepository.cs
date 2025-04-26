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
    public class ClientBlackListRepository : BaseRepository<ClientBlackList>, IClientBlackListRepository
    {
        private readonly AppDbContext _context;

        public ClientBlackListRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsClientBlacklisted(int clientId)
        {
            return await _context.ClientBlackList
               .AnyAsync(b => b.ClientId == clientId && b.Active);
        }
    }
}
