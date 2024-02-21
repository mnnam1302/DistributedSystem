using Carter;
using DistributedSystem.Presentation.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace DistributedSystem.Presentation.APIs.Products
{
    public class ProductApi : ApiEndpoint, ICarterModule
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/products";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("products")
                .MapGroup(BaseUrl).HasApiVersion(1);

            group1.MapPost(string.Empty, () => "");
            group1.MapGet(string.Empty, () => "");
            group1.MapGet("{productId}", () => "");
            group1.MapDelete("{productId}", () => "");
            group1.MapPut("{productId}", () => "");

            // Tạm thời comment - FIX BUG sau, chưa ăn Version 02, nhưng check thì có, chắc do Swagger
            var group2 = app.NewVersionedApi("products")
                .MapGroup(BaseUrl).HasApiVersion(2);

            group2.MapPost(string.Empty, () => "");
            group2.MapGet(string.Empty, () => "");
            group2.MapGet("{productId}", () => "");
            group2.MapDelete("{productId}", () => "");
            group2.MapPut("{productId}", () => "");
        }
    }
}