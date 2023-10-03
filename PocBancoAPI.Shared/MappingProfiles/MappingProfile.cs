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

            CreateMap<FinancialOperationDeposityViewModel, FinancialOperationDTO>()
                .ReverseMap();

            CreateMap<FinancialOperationWithdrawViewModel, FinancialOperationDTO>()
               .ReverseMap();

            CreateMap<FinancialOperationTransferViewModel, FinancialOperationDTO>()
               .ReverseMap();

            CreateMap<FinancialOperationDTO, FinancialOperation>()
                .ReverseMap();

            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.UserDTO, src => src.MapFrom(opt => opt.User))
                .ForMember(dest => dest.FinancialOperationDTOs, src => src.MapFrom(opt => opt.FinancialOperations));

            CreateMap<AccountDTO, AccountViewModel>()
                .ForMember(dest => dest.UserViewModel, src => src.MapFrom(opt => opt.UserDTO))
                .ForMember(dest => dest.FinancialOperationViewModels, src => src.MapFrom(opt => opt.FinancialOperationDTOs));
        }
    }
}
