using AutoMapper;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Enumerations;
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Domain.Abstractions.Repositories;
using DistributedSystem.Domain.Entities;
using DistributedSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace DistributedSystem.Application.UseCases.V1.Queries.Product
{
    public class GetProductsQueryHandler : IQueryHandler<Query.GetProductsQuery, PagedResult<Response.ProductResponse>>
    {
        private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public GetProductsQueryHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository, 
            IMapper mapper,
            ApplicationDbContext dbContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Result<PagedResult<Response.ProductResponse>>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken)
        {
            // 2 CASE CỰC HAY
            // Paging có Create(truyền vào IQueryable) và CreateAsync(truyền vào một List - kết quả rồi)
            if (request.SortColumnAndOrder.Any()) // Raw Query when order by multi column
            {
                var PageIndex = request.PageIndex <= 0 ? PagedResult<Domain.Entities.Product>.DefaultPageIndex : request.PageIndex;

                var PageSize = request.PageSize <= 0
                    ? PagedResult<Domain.Entities.Product>.DefaultPageSize
                    : request.PageSize > PagedResult<Domain.Entities.Product>.UpperPageSize
                    ? PagedResult<Domain.Entities.Product>.UpperPageSize : request.PageSize;

                // ===================================================
                var productsQuery = string.IsNullOrWhiteSpace(request.SearchTerm)
                    ? @$"SELECT * FROM {nameof(Domain.Entities.Product)} ORDER BY "
                    : @$"SELECT * FROM {nameof(Domain.Entities.Product)} WHERE Name LIKE '%{request.SearchTerm}%' OR Description LIKE '%{request.SearchTerm}%' ORDER BY ";

                foreach (var item in request.SortColumnAndOrder)
                    productsQuery += item.Value == SortOrder.Descending
                        ? $"{item.Key} DESC, "
                        : $"{item.Key} ASC, ";

                productsQuery = productsQuery.Remove(productsQuery.Length - 2);

                productsQuery += $" OFFSET {(PageIndex - 1) * PageSize} ROWS FETCH NEXT {PageSize} ROWS ONLY";

                var products = await _dbContext.Products.FromSqlRaw(productsQuery)
                    .ToListAsync(cancellationToken);

                var totalCount = await _dbContext.Products.CountAsync();

                var productPageResult = PagedResult<Domain.Entities.Product>.Create(products,
                    PageIndex,
                    PageSize,
                    totalCount);

                var result = _mapper.Map<PagedResult<Response.ProductResponse>>(productPageResult);

                return Result.Success(result);
            }
            else // Entity Framework
            {
                //Xử lý search
                //Cái này trả về IQueryable
                var productsQuery = string.IsNullOrWhiteSpace(request.SearchTerm)
                    ? _productRepository.FindAll()
                    : _productRepository.FindAll(x => x.Name.Contains(request.SearchTerm) || x.Description.Contains(request.SearchTerm));

                // Xử lý sort column
                //Expression<Func<Domain.Entities.Product, object>> keySelector = request.SortColumn?.ToLower()
                //    switch
                //{
                //    "name" => product => product.Name,
                //    "price" => product => product.Price,
                //    "description" => product => product.Description,
                //    _ => product => product.Id
                //    // _ => product => product.CreatedOnUtc // Default sort Descensing by CreatedOnUtc
                //};

                //productsQuery = request.SortOrder == SortOrder.Descending
                //    ? productsQuery.OrderByDescending(keySelector)
                //    : productsQuery.OrderBy(keySelector);

                productsQuery = request.SortOrder == SortOrder.Descending
                    ? productsQuery.OrderByDescending(GetSortProperty(request))
                    : productsQuery.OrderBy(GetSortProperty(request));

                //Lúc này nó xuống db query
                //var products = await productsQuery.ToListAsync(cancellationToken);
                var products = await PagedResult<Domain.Entities.Product>.CreateAsync(productsQuery,
                    request.PageIndex,
                    request.PageSize);

                var result = _mapper.Map<PagedResult<Response.ProductResponse>>(products);
                
                return Result.Success(result);
            }
        }

        private static Expression<Func<Domain.Entities.Product, object>> GetSortProperty(Query.GetProductsQuery request)
            => request.SortColumn?.ToLower() switch
            {
                "name" => product => product.Name,
                "price" => product => product.Price,
                "description" => product => product.Description,
                _ => product => product.Id
                // _ => product => product.CreatedOnUtc // Default sort Descensing by CreatedOnUtc
            };
    }
}