using Microsoft.EntityFrameworkCore;
using SOL_DONOVAN_FLORENCIO.DataAccess.Models;
using SOL_DONOVAN_FLORENCIO.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cadenaConexion = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ModelContext>(x =>
    x.UseOracle(
        cadenaConexion,
        options => options.UseOracleSQLCompatibility("11")
    )
);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ILibroService, LibroService>();
builder.Services.AddTransient<IPrestamoService, PrestamoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
