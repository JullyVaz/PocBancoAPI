using Microsoft.OpenApi.Models;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Business;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Data.Repositories;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.Services;
using PocBancoAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Data.UnitOfWork;

namespace PocBancoAPI.API
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PocBancoAPI", Version = "v1" });
            });
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IFinancialOperationService, FinancialOperationService>();
            return serviceCollection;

        }

        public static IServiceCollection AddBusinesses(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountBusiness, AccountBusiness>();
            serviceCollection.AddScoped<IUserBusiness, UserBusiness>();
            serviceCollection.AddScoped<IFinancialOperationBusiness, FinancialOperationBusiness>();
            serviceCollection.AddScoped<IUserBusiness, UserBusiness>();
            return serviceCollection;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<IFinancialOperationRepository, FinancialOperationRepository>();
            return serviceCollection;
        }

        public static IServiceCollection AddDataBase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return serviceCollection;
        }

        public static void CreateDatabaseIfNotExists(this WebApplication webApplication)
        {
            using (IServiceScope _serviceScope = webApplication.Services.CreateScope())
            {
                AppDbContext _appDbContext = _serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                _appDbContext.Database.EnsureCreated();
            }
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}