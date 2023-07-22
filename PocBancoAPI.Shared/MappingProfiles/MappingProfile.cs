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
            CreateMap<AccountViewModel, AccountDTO>()
                .ReverseMap();

            CreateMap<AccountDTO, Account>()
                .ReverseMap();

            CreateMap<TransferViewModel, TransferDTO>()
               .ReverseMap();

            CreateMap<TransferDTO, Transfer>()
                .ReverseMap();
        }
    }
}
