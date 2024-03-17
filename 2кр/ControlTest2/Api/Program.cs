using Api.EndpointGroups;
using Api.MapperProfiles;
using DataAccess;
using DataAccess.Repositories;
using Domain.Abstractions;
using Domain.Abstractions.Repository;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnect")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAutoMapper(mapper => mapper.AddProfile<AppMapProfile>());
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login/{login}/{password}", async (string login, string password, [FromServices] IUserService userService) =>
{
    return await userService.MakeJwtTokenAsync(login, password);
});

app.MapGroup("/product").ProductGroupe().RequireAuthorization();
app.MapGroup("/cart").CartGroupe().RequireAuthorization();

app.Run();
