using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net5Api.Core.CustomEntities;
using Net5Api.Core.Interfaces;
using Net5Api.Core.Services;
using Net5Api.Infrastructure.Data;
using Net5Api.Infrastructure.Interfaces;
using Net5Api.Infrastructure.Options;
using Net5Api.Infrastructure.Repositories;
using Net5Api.Infrastructure.Services;
using System.Text;


namespace Net5Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<Net5ApiContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Net5Api"));
            });

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration) {

            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddSerices(this IServiceCollection services) {

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IPassworService, PasswordService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider => {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });


            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration) {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services) {

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Net 5 Api Example",
                    Version = "v1"
                });

            });

            return services;
        }
    }
}
