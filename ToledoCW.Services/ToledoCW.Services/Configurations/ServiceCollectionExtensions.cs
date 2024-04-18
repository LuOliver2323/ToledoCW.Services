using ToledoCW.Services.Infraestructure.Repositorios;
using ToledoCW.Services.Infraestructure;
using ToledoCW.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace ToledoCW.Services.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("Padrao",
                x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ToledoCWContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("Mysql"));
        });


        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();

        services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

        services.AddAutoMapper(typeof(Program).Assembly);


        return services;
    }
}