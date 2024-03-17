using Api.Models;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.EndpointGroups
{
    public static class ProductGroup
    {
        public static RouteGroupBuilder ProductGroupe(this RouteGroupBuilder builder)
        {
            builder.MapPost("/{id}/add",
                [Authorize(Roles = "admin")] async ([FromServices] IProductRepository productRepository,
                [FromServices] IProductService productService) =>
            {
                await productRepository.AddProductAsync(productService.MakeRandomProduct());
                await productRepository.SaveChangesAsync();
            });
            builder.MapGet("/{categoryId}",
                [Authorize(Roles = "admin,user")] async (int categoryId,
                [FromServices] IProductRepository productRepository,
                [FromServices] IMapper mapper) =>
            {
                var products = await productRepository.GetProductsByCategoryAsync(categoryId);
                return products.Select(p => mapper.Map<ProductView>(p)).ToArray();
            });
            return builder;
        }
    }
}
