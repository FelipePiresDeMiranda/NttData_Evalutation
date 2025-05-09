﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRepositoryAsync<Domain.Entities.Customer>, CustomerRepository>();
        builder.Services.AddScoped<IRepositoryAsync<Domain.Entities.Sale>, SaleRepository>();
        builder.Services.AddScoped<IRepositoryAsync<Domain.Entities.Item>, ItemRepository>();
        builder.Services.AddScoped<IRepositoryAsync<Domain.Entities.Product>, ProductRepository>();
        builder.Services.AddScoped<IRepositoryAsync<Domain.Entities.Branch>, BranchRepository>();
    }
}