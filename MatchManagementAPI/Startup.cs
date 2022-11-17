using AutoMapper;
using MatchManagementAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;


namespace MatchManagementAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<MatchContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MatchManagementConnection")));

			services.AddControllers().AddNewtonsoftJson(s => { 
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});


			services.AddSwaggerGen(options =>
			{
				options.CustomSchemaIds(type => type.ToString());
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Match Management API",
					Version = "v1",
					Description = "Matches Management API - REST API ASP.NET CORE 3.1 ENTITY FRAMEWORK CORE.",
					Contact = new OpenApiContact
					{
						Name = "Potsi Eleftheria",
						Email = "el.potsi@gmail.com",
						Url = new Uri("https://www.linkedin.com/in/elpotsi/"),
					},
				});
				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});
			

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<IMatchRepo, SqlMatchRepo>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Match Management API");

				// To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
				c.RoutePrefix = string.Empty;
			});

			

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
