using Microsoft.EntityFrameworkCore;
using ToledoCW.Services.Infraestructure;
using ToledoCW.Services.Infraestructure.Repositorios;
using ToledoCW.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
        
builder.Services.AddCors(options =>
{
    options.AddPolicy("Padrao",
        x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});
        
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToledoCWContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Mysql"));
});


builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();

builder.Services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Padrao");

app.MapControllers();
        
app.UseHttpsRedirection();

app.Run();