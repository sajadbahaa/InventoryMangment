using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mappers
{
    public class CategoryProfile : AutoMapper.Profile
    {
        public CategoryProfile()
        {
            CreateMap<DataLayer.Entities.Category, DTOsLayer.Categories.Read.GetCategoeyDto>()
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest=>dest.CategoryName,opt=>opt.MapFrom(x=>x.Name.Trim()));
                CreateMap<DTOsLayer.Categories.Write.AddCategoryDto, DataLayer.Entities.Category>()
                .ForMember(dest=>dest.Id,opt=>opt.Ignore())
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(x=>x.Name.Trim()));
            CreateMap<DTOsLayer.Categories.Write.UpdateCategoryDto, DataLayer.Entities.Category>();
        }
    }
}
