using FluentValidation;
using bookrental.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookrental.services.Validators
{
    public class CreateLoanValidator : AbstractValidator<Loan>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.ClientId).GreaterThan(0).NotNull();
            RuleFor(x => x.LoanDetails).NotEmpty();
            RuleFor(x => x.DueDate).GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.LoanChannel).NotEmpty();
            RuleFor(x => x.RegisteredByUserId).GreaterThan(0).NotNull();

        }
    }
}
