using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mappers
{
    public  class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<DataLayer.Entities.Products, DTOsLayer.Products.Read.GetProductDto>();
            CreateMap<DTOsLayer.Products.Write.AddProductDto, DataLayer.Entities.Products>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(x => x.ProductName.Trim()))
            .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<DTOsLayer.Products.Write.UpdateProductDto, DataLayer.Entities.Products>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(x => x.ProductName.Trim()));
        }

    }
}
