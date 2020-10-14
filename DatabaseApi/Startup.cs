using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.HttpOverrides;

namespace DatabaseApi {
	/// <summary>
	/// Startup class. Configures the application startup using an IConfiguration interface.
	/// </summary>
	public class Startup {
		/// <summary>
		/// Startup constructor. Takes an IConfiguration interface to create a configuration for the application.
		/// </summary>
		/// <param name="configuration">The configuration interface containing information on the configuration.</param>
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called at runtime and adds defined services such as Swagger and IMapper.
		/// </summary>
		/// <param name="services">An interface containing a list for possible services as well as methods to start/stop them.</param>
		public void ConfigureServices(IServiceCollection services) {
			var config = new MapperConfiguration(conf => {
				conf.ForAllMaps((obj, cfg) => cfg.ForAllMembers(options => options.Condition((source, dest, sourceMember) => sourceMember != null)));
				conf.AddProfile(new AutoMapperProfiles());
			});
			services.AddSingleton<IMapper>(mapServ => config.CreateMapper());
			services.AddDbContext<BikeShop_Context>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
			//services.AddAutoMapper(typeof(Startup));
			services.AddControllers();
			services.AddSwaggerGen(c => {
				// Set the comments path for the Swagger JSON and UI.
				// ENABLES xml comments to also be generated
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		/// <summary>
		/// This method gets called at runtime. Configures the server with rules such as using Swagger and enabling/disables CORS.
		/// </summary>
		/// <param name="app">The builder for the application based on the environment.</param>
		/// <param name="env">The environment the application is being hosted in.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(
				options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
			);

			app.UseSwagger();
			//Route: hostingUrl/swagger
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Website API");
			});

			//Allow for forwarding with ngnix
			app.UseForwardedHeaders(new ForwardedHeadersOptions {
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});


		}
	}
}
