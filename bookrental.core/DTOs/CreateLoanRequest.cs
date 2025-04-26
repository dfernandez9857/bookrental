using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.core.DTOs
{
    public class CreateLoanRequest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime ReturnDate { get; set; }
        public int LoanStatusId { get; set; }
        public int RegisteredByUserId { get; set; }
        public string LoanChannel { get; set; }
        public List<int> BookCopyIds { get; set; } = new List<int>();

    }

}
