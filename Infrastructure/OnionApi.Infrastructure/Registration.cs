﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionApi.Domain.Contracts;
using OnionApi.Infrastructure.Databases.Context;
using OnionApi.Infrastructure.Databases.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Infrastructure
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<FamilyDBContext>(opt=> opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //for Dependency Injection
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IFamilyRepository<>), typeof(FamilyRepository<>));
        }
    }
}
