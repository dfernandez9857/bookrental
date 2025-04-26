using bookrental.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Interfaces.Repositories
{
    public interface IClientBlackListRepository : IBaseRepository<ClientBlackList>
    {
        Task<bool> IsClientBlacklisted(int clientId);
    }
}
