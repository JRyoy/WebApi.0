using Api.Migraciones;
using Api.Migraciones.ServiceManager;
using Carter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.AddEnvironmentVariables();
builder.Services.AddDbContext<AplicacionDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddServiceManager();
builder.Services.AddCarter();

var app = builder.Build();

// Configuración de desarrollo
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
//}

// Aplicar migraciones pendientes automáticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AplicacionDbContext>();
    dbContext.Database.Migrate();
}

app.UseRouting();
app.MapCarter();

app.Run();

