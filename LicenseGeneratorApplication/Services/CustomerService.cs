using AutoMapper;
using LicenseGenerator.Application.Common.Interface;
using LicenseGenerator.Application.Interface.Customer;
using LicenseGenerator.Common.Helper.Messages;
using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGenerator.Model.Models;
using LicenseGeneratorApplication.Command.Customer;
using LicenseGeneratorApplication.Dtos.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseGenerator.Common.Utilities;

namespace LicenseGenerator.Application.Services
{
    public class CustomerService : PagingService<Customer>, ICustomerService
    {
        protected readonly ILicenseGeneratorDbContext _context;
        protected readonly IMapper _mapper;
        public CustomerService(ILicenseGeneratorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<CustomerDto>> Add(CustomerAddCommand command)
        {
            var customer = _mapper.Map<Customer>(command);

            await _context.Customers.AddAsync(customer);
            await _context.SaveAsync();
            return Result<CustomerDto>.SuccessFul(_mapper.Map<CustomerDto>(customer));
        }
        public async Task<List<Customer>> GetList()
        {
            var customers = await _context.Customers.ToListAsync();
            _context.Dispose();
            return customers;

        }

        public async Task<PagedList<CustomerDto>> GetPagingList(PagingOptions request)
        {
            IQueryable<Customer> customers = _context.Customers.DynamicWhere(request.Query);

            var customerList = await GetPagedAsync(request.Page, request.Limit, customers);

            return customerList.MapTo<CustomerDto>(_mapper);
        }
    }
}
