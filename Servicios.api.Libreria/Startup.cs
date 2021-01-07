using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Servicios.api.Libreria.Core;
using Servicios.api.Libreria.Core.ContextMongoDb;
using Servicios.api.Libreria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.api.Libreria
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//CONFIGURO LA CONEXION
			services.Configure<MongoSettings>(//LLAMO A LA CLASE MONGOSETTINGS
				options =>
				{
					options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value; // Configuration accede a el JSON
					options.Database = Configuration.GetSection("MongoDb:Database").Value;
				}
			);
			
			services.AddSingleton<MongoSettings>();//CUANDO LA APP QUIERA HACER UN LLAMADO O VERIFICAR SI EXISTE UN OBJETO DE MONGO AQUI SE REVISARA Y SI EXISTE LO DEVOLVERA, SI NO EXISTE CREA UN NUEVO OBJETO
												   //ESTE FRAGMENTO DE CODIGO SIEMPRE ESTARA CORRIENDO DURANTE TODA LA EJECUCION
			services.AddTransient<IAutorContext, AutorContext>(); // Interfaz, Implementacion de la interfaz (clase),  crea nuevas instancias cada vez que un cliente quiera ejecutar un api

			services.AddTransient<IAutorRepository, AutorRepository>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servicios.api.Libreria", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Servicios.api.Libreria v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
