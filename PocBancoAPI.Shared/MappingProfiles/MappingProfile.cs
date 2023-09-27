using AutoMapper;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Shared.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserLoginViewModel, UserDTO>()
                .ReverseMap();
            CreateMap<UserViewModel, UserDTO>()
                .ReverseMap();

            CreateMap<UserToInsertViewModel, UserDTO>()
                .ReverseMap();

            CreateMap<UserDTO, User>()
                .ReverseMap();

            CreateMap<AccountToInsertViewModel, AccountDTO>()
                .ReverseMap();

            CreateMap<AccountViewModel, AccountDTO>()
                .ReverseMap();

            CreateMap<AccountDTO, Account>()
                .ReverseMap();

            CreateMap<FinancialOperationViewModel, FinancialOperationDTO>()
               .ReverseMap();

            CreateMap<FinancialOperationDTO, FinancialOperation>()
                .ReverseMap();
        }
    }
}
