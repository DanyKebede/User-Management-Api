using Microsoft.EntityFrameworkCore;
using WebApi.Application;
using WebApi.Data;
using WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddScoped<IUser, UserService>();
// builder.Services.AddScoped<IBankAccount, BankAccountService>();


builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PG_DB_CONNECTION_STR")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
