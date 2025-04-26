using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Entities
{
    public class LoanDetail
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int BookCopyId { get; set; }
        public virtual Loan Loan { get; set; }
        public virtual BookCopy BookCopy { get; set; }
    }
}
