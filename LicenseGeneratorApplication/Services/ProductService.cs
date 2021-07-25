using AutoMapper;
using LicenseGenerator.Application.Common.Interface;
using LicenseGenerator.Application.Interface.Product;
using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGenerator.Model.Models;
using LicenseGeneratorApplication.Command.Product;
using LicenseGeneratorApplication.Dtos.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;
using LicenseGenerator.Common.Helper.Messages;

namespace LicenseGenerator.Application.Services
{
    public class ProductService : PagingService<Product>, IProductService
    {
        protected readonly ILicenseGeneratorDbContext _context;
        protected readonly IMapper _mapper;

        public ProductService(ILicenseGeneratorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Add(ProductAddCommand command)
        {
            //var product = _mapper.Map<Product>(command);
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                ProductDetails = null
            };
            _context.Products.Add(product);

            foreach (var item in command.Details)
            {
                var details = new ProductDetails
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                    EnName = item.EnName,
                    Product = product
                };
                _context.ProductDetails.Add(details);
            }

            //await _context.Products.AddAsync(product);
            await _context.SaveAsync();
            return Result<Guid>.SuccessFul(product.Id);
        }

        public async Task<Result<ProductDto>> Get(Guid id)
        {
            var product = await _context.Products.Include(x => x.ProductDetails).SingleOrDefaultAsync(x => x.Id == id);
            if (product is null)
                return Result<ProductDto>.Failed(new NotFoundObjectResult
                    (new ApiMessage("موردی یافت نشد")));

            return Result<ProductDto>.SuccessFul(_mapper.Map<ProductDto>(product));
        }

        public async Task<List<Product>> GetList()
        {
            var list = await _context.Products.AsNoTracking().ToListAsync();
            _context.Dispose();
            return list;
        }

        public async Task<PagedList<ProductDto>> GetPagingList(PagingOptions request)
        {
            IQueryable<Product> products = _context.Products.Include(e => e.ProductDetails);

            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                products = products.Where(x => x.Name.Contains(request.Query));
            }

            var productList = await GetPagedAsync(request.Page, request.Limit, products);

            return productList.MapTo<ProductDto>(_mapper);
        }
    }
}
