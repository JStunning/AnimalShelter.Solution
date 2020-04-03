﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AnimalShelter.Models;

namespace AnimalShelter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:*");
                });

                options.AddPolicy("AllowSubdomain", builder =>
                {
                    builder.WithOrigins("http://localhost:*")
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                });

                options.AddPolicy("AllowAllHeaders", builder =>
                {
                    builder.WithOrigins("http://localhost:*")
                        .AllowAnyHeader();
                });

                options.AddPolicy("AllowCredentials", builder =>
                {
                    builder.WithOrigins("http://localhost:*")
                        .AllowCredentials();
                });
            });
            services.AddDbContext<AnimalContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
