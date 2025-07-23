using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Repository;
using TaskTracker.Repository.Interfaces;
using TaskTracker.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITarefa, TarefaRepository>();
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<TarefaService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
