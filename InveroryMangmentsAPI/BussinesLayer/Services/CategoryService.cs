using AutoMapper;
using AutoMapper.QueryableExtensions;
using BussinesLayer.Interfaces;
using BussinesLayer.Utility;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DTOsLayer.Categories.Read;
using DTOsLayer.Categories.Write;
using DTOsLayer.Common.Exceptions;
using DTOsLayer.Common.Pagination;
using DTOsLayer.Common.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{


    public class CategoryService : ICategoyService
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoryAsync(AddCategoryDto category)
        {
             _unitOfWork.CategoryRepository.Add(_mapper.Map<DataLayer.Entities.Category>(category));
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteCategoryAsync(ApiRequestID request )
        {
         return  await _unitOfWork.CategoryRepository.DeleteAsync<short>(Helper<short>.CastingTo( request.Id));
        }

        public async Task<GetCategoeyDto> GetCategoryByIdAsync(ApiRequestID request)
        {
            GetCategoeyDto? category = await _unitOfWork.CategoryRepository
                   .QueryCustom(x => x.Id == Helper<short>.CastingTo(request.Id), true).ProjectTo<GetCategoeyDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (category == null)
                throw new NotFoundException("Category not found with id ");
            return category;
        }

        public async Task<GetCategoeyDto> GetCategoryByNameAsync(ApiRequestString request)
        {
            GetCategoeyDto ?category = await 
            _unitOfWork.CategoryRepository.QueryCustom(x=>x.Name==request.Value,true).ProjectTo<GetCategoeyDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        if (category==null) 
            {
                throw new NotFoundException("Category not found with name");
            }
            return category;
        }

        public async Task<ICollection<GetCategoeyDto>> Pagination(Pagination request)
        {
           return await _unitOfWork.CategoryRepository
                   .Pagination(request.PageNumber,request.PageSize ).ProjectTo<GetCategoeyDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto category)
        {
          _unitOfWork.CategoryRepository.Update(_mapper.Map<DataLayer.Entities.Category>(category));
         return  await _unitOfWork.CommitAsync();
        }
    }
}
