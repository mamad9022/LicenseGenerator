using AutoMapper;
using LicenseGenerator.Application.Common.Interface;
using LicenseGenerator.Application.Interface.License;
using LicenseGenerator.Common.Helper.Pagination;
using LicenseGenerator.Common.Result;
using LicenseGenerator.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LicenseGenerator.Application.Command.License;
using LicenseGenerator.Application.Dtos.LicenseLog;
using LicenseGenerator.Common.Helper.Message;
using LicenseGenerator.Common.Utilities;

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


            List<FeatureDetail> listValue = new List<FeatureDetail>();
            List<string> lisenceList = new List<string>();

            foreach (var item in command.Features)
            {
                listValue.Add(new FeatureDetail
                {
                    Name = item.Ename,
                    Value = item.Value
                });
            }

            var feature = new Feature
            {
                ExpireDate = Convert.ToDateTime(command.ExpireDate).Date,
                SystemId = EncryptProvider.AESDecrypt(command.SystemId, key, Iv),
            };

            foreach (var item in listValue)
            {
                string p = "\u0022" + item.Name + "\u0022" + ":" + item.Value;
                lisenceList.Add(p);
            }

            var license = CreateLicense(feature, lisenceList);

            var data = EncryptProvider.AESEncrypt(license, key, Iv);

            await SaveInLog(command.CustomerId, command.ProductId, data, feature.ExpireDate);

            return Result<string>.SuccessFul(data);

        }

        public async Task<PagedList<LicenseLogDto>> GetPagingList(PagingOptions request)
        {
            IQueryable<LicenseLog> licenseLogs = _context.LicenseLogs
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .OrderByDescending(x=>x.CreationTime)
                .DynamicWhere(request.Query);

            var licenseLogList = await GetPagedAsync(request.Page, request.Limit, licenseLogs);

            return licenseLogList.MapTo<LicenseLogDto>(_mapper);
        }

        #region SaveInLog
        private async Task SaveInLog(Guid customerId, Guid productId, string data, DateTime expireDate)
        {
            var license = new LicenseLog
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                CreationTime = DateTime.Now,
                ProductId = productId,
                ExpireDate = expireDate,
                License = data
            };

            _context.LicenseLogs.Add(license);
            await _context.SaveAsync();
        }
        #endregion

        #region CreateLicense
        private string CreateLicense(Feature feature, List<string> lisenceList)
        {
            string license = "{";
            foreach (var item in lisenceList)
            {
                license += item + ",";
            }
            var featureSerializer = JsonSerializer.Serialize(feature);
            char[] MyChar = { '{' };
            featureSerializer = featureSerializer.TrimStart(MyChar);
            return license += featureSerializer;
        }
        #endregion

        #region Feature 
        private class Feature
        {
            public string SystemId { get; set; }
            public DateTime ExpireDate { get; set; }
        }
        #endregion

        #region FeatureDetail
        private class FeatureDetail
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        #endregion

    }
}
