using bookrental.core.Entities;
using bookrental.core.Interfaces.Services;
using bookrental.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookrental.services.Validators;
using FluentValidation;

namespace bookrental.services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Loan> CreateLoanAsync(Loan newLoan)
        {
            CreateLoanValidator validator = new();

            var validationResult = await validator.ValidateAsync(newLoan);
            if (validationResult.IsValid)
            {
                
                var client = await _unitOfWork.ClientRepository.GetByIdAsync(newLoan.ClientId);
                if (client == null)
                    throw new ArgumentException("Client not found");

                var isClientBlackListed = await _unitOfWork.ClientBlackListRepository.IsClientBlacklisted(client.Id);

                if (isClientBlackListed)
                    throw new ArgumentException("Client is blacklisted");


                var areAvailable = await _unitOfWork.LoanRepository.AreBooksAvailable(
                        newLoan.LoanDetails
                        .Select(x=>x.Id)
                        .ToList());

                if (!areAvailable)
                    throw new ArgumentException("One or more books are not available");

                newLoan.LoanDate = DateTime.UtcNow;

                await _unitOfWork.LoanRepository.AddAsync(newLoan);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newLoan;
        }

    }
}
