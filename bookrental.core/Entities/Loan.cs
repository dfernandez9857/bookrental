using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.Entities
{
    public class Loan
    {
        public Loan()
        {
            LoanDetails = new Collection<LoanDetail>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public int LoanStatusId { get; set; }
        public int RegisteredByUserId { get; set; }
        public string LoanChannel { get; set; }
        public ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();
        public virtual Client Client { get; set; }
    }
}
