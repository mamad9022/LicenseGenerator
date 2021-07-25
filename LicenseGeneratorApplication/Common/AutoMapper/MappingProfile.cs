using System;
using AutoMapper;
using LicenseGenerator.Model.Models;
using LicenseGeneratorApplication.Command.Customer;
using LicenseGeneratorApplication.Command.License;
using LicenseGeneratorApplication.Command.Product;
using LicenseGeneratorApplication.Dtos.Customer;
using LicenseGeneratorApplication.Dtos.LicenseLog;
using LicenseGeneratorApplication.Dtos.Product;
using LicenseGeneratorApplication.Dtos.ProductDetail;

namespace LicenseGenerator.Application.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customer

            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerAddCommand, Customer>()
                .ForMember(src => src.Id, opt => opt.MapFrom(des => Guid.NewGuid()))
                .ForMember(src => src.Code, opt => opt.MapFrom(des => des.Code))
                .ForMember(src => src.Name, opt => opt.MapFrom(des => des.Name));

            CreateMap<CustomerEditCommand, Customer>()
                  .ForMember(src => src.Id, opt => opt.MapFrom(des => Guid.NewGuid()))
                .ForMember(src => src.Code, opt => opt.MapFrom(des => des.Code))
                 .ForMember(src => src.Name, opt => opt.MapFrom(des => des.Name));

            #endregion Customer

            #region LicenseLog

            CreateMap<LicenseLog, LicenseLogDto>();

            CreateMap<LicenseCreateCommand, LicenseLog>()
                .ForMember(src => src.ProductId, opt => opt.MapFrom(des => des.ProductId))
                .ForMember(src => src.CustomerId, opt => opt.MapFrom(des => des.CustomerId))
                .ForMember(src => src.CreationTime, opt => opt.MapFrom(des => DateTime.Now))
                .ForMember(src => src.Id, opt => opt.MapFrom(des => Guid.NewGuid()));

            #endregion LicenseLog

            #region Product

            CreateMap<ProductDetails, ProductDetailDto>();

            CreateMap<Product, ProductDto>()
                 .ForMember(src => src.Id, opt => opt.MapFrom(des => des.Id))
                .ForMember(src => src.Name, opt => opt.MapFrom(des => des.Name))
                .ForMember(src => src.ProductDetails, opt => opt.MapFrom(des => des.ProductDetails));
            #endregion Product

        }
    }
}