using AutoMapper;
using TesteAmbev.DTOs;
using TesteAmbev.Models;

namespace TesteAmbev.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Sale, SaleDTO>().ReverseMap();
            CreateMap<SaleItem, SaleItemDTO>().ReverseMap();
        }
    }
}
