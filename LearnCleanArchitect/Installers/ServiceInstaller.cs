using FluentValidation;
using LearnCleanArchitect.Application.Candidates.Commands.AddCandidates;
using LearnCleanArchitect.Application.Common;
using LearnCleanArchitect.Application.Interfaces;
using LearnCleanArchitect.Configurations;
using LearnCleanArchitect.Infrastructure;
using LearnCleanArchitect.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace LearnCleanArchitect.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = new DatabaseConfiguration(); 
            configuration.GetSection("ConnectionStrings").Bind(dbConfig);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(dbConfig.DefaultConnection));
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            var applicationAssembly = typeof(AddCandidateCommand).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>));

            services.AddScoped<ICandidateService, CandidateService>();
        }
    }
}
