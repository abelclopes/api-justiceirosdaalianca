using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Interfaces;
using Scraffold;

namespace api
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
            // services.AddDbContext<ApplicationDbContext>(
            //     options =>options.UseSqlite("Data Source=MvcEmployee.db")
            // );  
            services.AddDbContext<JusticeirosdaaContext>(options =>
                 //options.UseSqlServer(
                 options.UseMySql(                    
                     Configuration.GetConnectionString("DefaultConnection"),
                     //b => b.MigrationsAssembly(migrationsAssembly)
                     b => b.MigrationsAssembly("API")
                 )
             );


            ResolveDependencies(services);
            Autorizacao(services);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(opt =>
                {
                    // Force all ISO8601 timestamp conversions to use UTC (ie: YYYY-MM-DDTHH:MM:SS.FFFZ)
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    opt.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    opt.SerializerSettings.DateFormatString = "yyyy-MM-dd'T'HH:mm:ss.FFFFFF'Z'";
                });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                .Build());
            });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Justiceiros da Alianca API", Version = "v1" });
                // c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                // c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                //     { "Bearer", Enumerable.Empty<string>() },
                // });
            });
        }

        private void ResolveDependencies(IServiceCollection services)
        {           
            services.AddScoped<IContext, JusticeirosdaaContext>();
        }

        private void Autorizacao(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.ConfigureJwtAuthentication();
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    "application/json"
                };
            });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme
                    ).RequireAuthenticatedUser().Build();
            });
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
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Justiceiros da Alianca API");
            });

        }
    }
}
