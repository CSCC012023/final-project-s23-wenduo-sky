using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using yourscope_api.service;
using Firebase.Auth;
using Firebase.Auth.Providers;

string YourScopePolicy = "YourScopePolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Services Configuration

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: YourScopePolicy,
        policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

#region dependency injection
builder.Services.AddTransient<IAccountsService, AccountsService>();

#endregion

#endregion

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

#region Middleware Configuration
app.UseCors(YourScopePolicy);
#endregion

app.Run();
