using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Enumerations;
using static DistributedSystem.Contract.Services.V1.Product.Response;

namespace DistributedSystem.Contract.Services.V1.Product;

public static class Query
{
    //public record GetProductsQuery(string? SearchTerm, string? SortColumn, SortOrder? SortOrder):  IQuery<List<ProductResponse>>;
    public record GetProductsQuery(string? SearchTerm, string? SortColumn, string? SortOrder, 
        IDictionary<string, SortOrder>? SortColumnAndOrder, 
        int PageIndex, int PageSize) : IQuery<PagedResult<ProductResponse>>;

    public record GetProductByIdQuery(Guid Id): IQuery<ProductResponse>;
}
