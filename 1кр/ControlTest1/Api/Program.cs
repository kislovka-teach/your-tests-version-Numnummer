using Domain.Abstractions;
using Domain.Repository;
using Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped<IRepository, Domain.Repository.Repository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.AccessDeniedPath="/loginError");
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.Map("/loginError", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access Denied");
});

app.MapGet("/login", async (context) =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/form.html");
});

app.MapPost("/login", async (HttpContext context, [FromServices] IUserService userService) =>
{
    var form = context.Request.Form;
    if (!form.ContainsKey("login") || !form.ContainsKey("password"))
        return Results.BadRequest("Логин и/или пароль не установлены");
    var user = new User()
    {
        Login=form["login"],
        Password=form["password"]
    };
    var userPrincipal = await userService.GetUserPrincipalAsync(user);
    if (userPrincipal!=null)
    {
        await context.SignInAsync(userPrincipal);
        return Results.Ok("Sign in success");
    }
    return Results.Unauthorized();
});

app.MapGet("/asd", async (context) =>
{
    var a = context.User.Claims;
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/form.html");
});

app.MapGet("/asdd", [Authorize(Roles = "couch")] async (context) =>
{
    var a = context.User.Claims;
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/form.html");
});

app.MapControllers();

app.Run();
