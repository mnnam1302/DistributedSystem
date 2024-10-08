﻿using AutoMapper;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Domain.Entities;
using DistributedSystem.Domain.Entities.Identity;

namespace DistributedSystem.Application.Mapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        // V1
        CreateMap<Product, Response.ProductResponse>().ReverseMap();
        CreateMap<PagedResult<Product>, PagedResult<Response.ProductResponse>>().ReverseMap();

        CreateMap<AppUser, DistributedSystem.Contract.Services.V1.Identity.Response.UserResponse>().ReverseMap();

        //// V2
        //CreateMap<Product, Contract.Services.V2.Product.Response.ProductResponse>().ReverseMap();
    }
}
