using AutoMapper;
using bookrental.core.DTOs;
using bookrental.core.Entities;
using bookrental.web.Models;

namespace bookrental.web.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Loan, LoanModel>();
            CreateMap<LoanModel, Loan>();


            CreateMap<CreateLoanRequest, Loan>()
                .ForMember(dest => dest.LoanDetails, opt => opt.MapFrom(src =>
                    src.BookCopyIds.Select(id => new LoanDetail { BookCopyId = id })))
                .ForMember(dest => dest.LoanDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.ReturnDate)) 
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

            CreateMap<Loan, CreateLoanRequest>()
                .ForMember(dest => dest.BookCopyIds, opt => opt.MapFrom(src =>
                    src.LoanDetails.Select(ld => ld.BookCopyId)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
