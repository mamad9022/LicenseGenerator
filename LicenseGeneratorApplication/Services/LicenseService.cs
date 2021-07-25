using AutoMapper;
using LicenseGenerator.Application.Common.Interface;
using LicenseGenerator.Application.Interface.License;
using LicenseGenerator.Common.Helper.Messages;
using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGenerator.Model.Models;
using LicenseGeneratorApplication.Command.License;
using LicenseGeneratorApplication.Dtos.LicenseLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LicenseGenerator.Application.Services
{
    public class LicenseService : PagingService<LicenseLog>, ILicenseService
    {
        protected readonly ILicenseGeneratorDbContext _context;
        protected readonly IMapper _mapper;
        public LicenseService(ILicenseGeneratorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<string>> Create(LicenseCreateCommand command)
        {
            string key = "BDE6282501A84E0DB9E777D0AE37FED4";
            string Iv = "2A5658A3A7204E19";

            var customer = _context.Customers.SingleOrDefault(x => x.Id == command.CustomerId);
            if (customer is null)
                return Result<string>.Failed(new NotFoundObjectResult
                   (new ApiMessage("مشتری یافت نشد")));

            var product = _context.Products.SingleOrDefault(x => x.Id == command.ProductId);
            if (product is null)
                return Result<string>.Failed(new NotFoundObjectResult
                   (new ApiMessage("محصول یافت نشد")));


            List<string> listValue = new List<string>();
            foreach (var item in command.Features)
            {
                listValue.Add(item.Value);
            }

            var feature = new Feature
            {
                ExpireDate = command.ExpireDate,
                SystemId = command.SystemId,
                CustomerNumber = customer.Code,
                Values = listValue
            };

            var lisence = JsonSerializer.Serialize(feature);

            var data = EncryptProvider.AESEncrypt(lisence, key, Iv);

            await SaveInLog(command.CustomerId, command.ProductId, data);

            return Result<string>.SuccessFul(data);

        }

        private async Task SaveInLog(Guid customerId, Guid productId, string data)
        {
            var license = new LicenseLog
            {
                CustomerId = customerId,
                CreationTime = DateTime.Now,
                ProductId = productId,
                Id = Guid.NewGuid(),
                License = data
            };

            _context.LicenseLogs.Add(license);
            await _context.SaveAsync();
        }

        public async Task<PagedList<LicenseLogDto>> GetPagingList(PagingOptions request)
        {
            IQueryable<LicenseLog> licenseLogs = _context.LicenseLogs.Include(x=>x.Customer).Include(x=>x.Products);

            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                licenseLogs = licenseLogs.Where(x => x.Customer.Name.Contains(request.Query));
            }

            var licenseLogList = await GetPagedAsync(request.Page, request.Limit, licenseLogs);

            return licenseLogList.MapTo<LicenseLogDto>(_mapper);
        }


        private class Feature
        {
            public int CustomerNumber { get; set; }
            public string SystemId { get; set; }
            public DateTime ExpireDate { get; set; }
            public List<string>Values { get; set; }
        }
    }
}
