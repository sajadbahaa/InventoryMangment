using AutoMapper;
using AutoMapper.QueryableExtensions;
using BussinesLayer.Interfaces;
using DataLayer.Interfaces.IUnit;
using DTOsLayer.Common.Exceptions;
using DTOsLayer.Common.Pagination;
using DTOsLayer.Common.Request;
using DTOsLayer.Products.Read;
using DTOsLayer.Products.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  Task<bool> AddProductAsync(AddProductDto product)
        {
           _unitOfWork.ProductRepository.Add(_mapper.Map<DataLayer.Entities.Products>(product));
            return _unitOfWork.CommitAsync();
        }
        public async Task<GetProductDto> GetProductByIdAsync(ApiRequestID request)
        {
        GetProductDto? productDto = 
              await  _unitOfWork.ProductRepository.
               QueryCustom(item => item.ProductId == request.Id, true)
               .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            if (productDto == null)
                throw new NotFoundException("Product not found with Id");
        
            return productDto;
        }
        public async Task<GetProductDto> GetProductByNameAsync(ApiRequestString request)
        {
            GetProductDto? productDto =
             await _unitOfWork.ProductRepository.
                QueryCustom(item => item.ProductName == request.Value, true)
                .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (productDto == null)
                throw new NotFoundException("Product not found with name");

            return productDto;
        }
        public async Task<ICollection<GetProductDto>> Pagination(Pagination request)
        {
            return  await _unitOfWork.ProductRepository.Pagination(request.PageNumber, request.PageSize)
                .ProjectTo<GetProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<bool> UpdateProductAsync(UpdateProductDto product)
        {
            bool isExist = await _unitOfWork.ProductRepository.AnyAsync(entity => entity.ProductId == product.ProductId);
            if (!isExist)
                throw new NotFoundException("Product with ID not found.");
            _unitOfWork.ProductRepository.Update(_mapper.Map<DataLayer.Entities.Products>(product));
            return await _unitOfWork.CommitAsync(); ;
        }
    }
}
