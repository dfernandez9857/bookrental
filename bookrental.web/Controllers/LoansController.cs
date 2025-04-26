using AutoMapper;
using bookrental.core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookrental.core.Entities;
using bookrental.core.Interfaces.Services;
using bookrental.web.Models;

namespace bookrental.web.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;

        public LoansController(ILoanService loanService, IMapper mapper)
        {
            _loanService = loanService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<LoanModel>> Post([FromBody] CreateLoanRequest request)
        {
            try
            {
                var createdLoan =
                    await _loanService.CreateLoanAsync(_mapper.Map<CreateLoanRequest, Loan>(request));

                return Ok(_mapper.Map<Loan, LoanModel>(createdLoan));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
