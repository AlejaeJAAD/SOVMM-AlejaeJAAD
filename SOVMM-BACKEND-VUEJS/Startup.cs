using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using sovmm_backend.Models;
using sovmm_backend.Services;


namespace sovmm_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            var appSettingsSection = Configuration.GetSection(nameof(ConnSettings));
            services.Configure<ConnSettings>(appSettingsSection);
            services.AddSingleton<IConnSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<ConnSettings>>().Value);
            var appSettings = appSettingsSection.Get<ConnSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretCredentials);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jsonWebToken =>
            {
                jsonWebToken.RequireHttpsMetadata = false;
                jsonWebToken.SaveToken = true;
                jsonWebToken.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            
            services.AddScoped<UsersRepository,UsersRepository>();
            services.AddScoped<IPresidenciasRepository,PresidenciasRepository>();
            services.AddScoped<IProyectosRepository, ProyectosRepository>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors(policy =>
                policy.AllowAnyOrigin().
                    AllowAnyHeader().
                    AllowAnyMethod()
            );
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}