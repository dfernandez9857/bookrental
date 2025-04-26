using bookrental.core.Entities;

namespace bookrental.web.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SchoolId { get; set; }
        public Loan School { get; set; }
    }
}
