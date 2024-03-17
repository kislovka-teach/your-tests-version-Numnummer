using Api.Models;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.EndpointGroups
{
    public static class CartGroup
    {
        public static RouteGroupBuilder CartGroupe(this RouteGroupBuilder builder)
        {
            builder.MapGet("/",
                [Authorize(Roles = "admin,user")] async (HttpContext context,
                [FromServices] ICartRepository cartRepository,
                [FromServices] IMapper mapper) =>
            {
                var userLogin = context.User.FindFirstValue(ClaimTypes.Name);
                var cart = await cartRepository.GetCartByUserLogin(userLogin);
                return mapper.Map<CartView>(cart);
            });
            builder.MapPost("/addProduct", [Authorize(Roles = "admin,user")] async (HttpContext context,
                [FromServices] ICartRepository cartRepository,
                [FromServices] IProductService productService) =>
            {
                var userLogin = context.User.FindFirstValue(ClaimTypes.Name);
                await cartRepository.AddProductAsync(productService.MakeRandomProduct(), userLogin);
                await cartRepository.SaveChangesAsync();
            });
            builder.MapGet("/look", [Authorize(Roles = "admin")] async (HttpContext context,
                [FromServices] ICartRepository cartRepository) =>
            {
                return await cartRepository.GetAllCartsAsync();
            });
            return builder;
        }
    }
}
