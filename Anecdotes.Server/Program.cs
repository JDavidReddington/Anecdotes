using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Anecdotes.Server.Data; // Ajusta esto al namespace donde tienes tu DbContext

var builder = WebApplication.CreateBuilder(args);




// PASO 4 => VAMOS A PROGRAM.CS PARA GENERAR LA INYECCION DEL SERVICIO DE CADENA DE CONEXION:
// Configuración de la cadena de conexión desde appsettings.json
var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppAnecdotasDbContext>(options =>
    options.UseSqlServer(connectionString));




//PASO 8 => SERVICIO PARA COMUNICAR BACKEND CON FRONTED JDCN
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()));

// Agregar servicios necesarios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del middleware y del pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//PASO 8 (SEGUNDA PARTE)
app.UseCors("AllowWebApp");


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
