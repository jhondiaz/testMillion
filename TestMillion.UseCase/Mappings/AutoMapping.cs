using AutoMapper;

using TestMillion.DTOs;
using TestMillion.Entities.POCOs;

namespace TestMillion.UseCases.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreatePropertyDTO, Property>().ReverseMap();
            CreateMap<Property, PropertyDTO>().ReverseMap();
            CreateMap<UpdatePropertyDTO, Property>().ReverseMap();
            CreateMap<CreateOwnerDTO, Owner>().ReverseMap();
            CreateMap<Owner, OwnerDTO>().ReverseMap();
            CreateMap<CreatePropertyImageDTO, PropertyImage>().ReverseMap();
            CreateMap<PropertyImage, PropertyImageDTO>().ReverseMap();
        }
    }
}
