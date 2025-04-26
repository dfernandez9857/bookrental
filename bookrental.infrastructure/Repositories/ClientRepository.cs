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
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {

        public ClientRepository(AppDbContext context) : base(context)
        {
        }

    }
}
