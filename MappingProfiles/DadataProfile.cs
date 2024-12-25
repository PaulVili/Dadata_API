using AutoMapper;
using Dadata.Model;
using Dadata_API.Dto;

namespace Dadata_API.MappingProfiles
{
    public class DadataProfile : Profile
    {
        public DadataProfile() {
            CreateMap<Address, DestinationDto>();
        }
    }
}
