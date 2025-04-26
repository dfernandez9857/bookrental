using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Entities
{
    public class BookCopy
    {
        public int Id { get; set; }
        public bool IsLoanable { get; set; }
        public int LoanStatusId { get; set; }
    }
}
