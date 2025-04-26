using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Entities
{
    public class ClientBlackList
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string Reason { get; set; }

        public bool Active { get; set; }

        public virtual Client Client { get; set; }

    }
}
