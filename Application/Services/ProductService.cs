using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());
        }

        public Task<ProductDto> GetByIdAsync(int id)
        {
            return _mapper.Map<Task<ProductDto>>(_productRepository.GetAsync(id));
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            await _productRepository.UpdateAsync(_mapper.Map<Product>(updateProductDto));
        }
    }
}
