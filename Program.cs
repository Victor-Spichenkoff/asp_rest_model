using asp_rest_model.Data;
using asp_rest_model.Helpers;
using asp_rest_model.Interface.Repositoy;
using asp_rest_model.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlite("Data Source=Data/dev.db"));
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // seeding
    app.MigrateDatabase();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();