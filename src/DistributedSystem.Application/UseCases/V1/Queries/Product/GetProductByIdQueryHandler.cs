using AutoMapper;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Domain.Abstractions.Repositories;
using DistributedSystem.Domain.Errors;
using DistributedSystem.Domain.Exceptions;
using DistributedSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DistributedSystem.Application.UseCases.V1.Queries.Product
{
    public class GetProductByIdQueryHandler : IQueryHandler<Query.GetProductByIdQuery, Response.ProductResponse>
    {
        //private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepositoryBase;

        // Sử dụng trong TH nhiều DbContext => Flexible hơn
        private readonly IRepositoryBaseDbContext<ApplicationDbContext, Domain.Entities.Product, Guid> _productRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public GetProductByIdQueryHandler(IRepositoryBaseDbContext<ApplicationDbContext, Domain.Entities.Product, Guid> productRepository,
            //IRepositoryBase<Domain.Entities.Product, Guid> productRepositoryBase,
            IMapper mapper,
            ApplicationDbContext dbContext)
        {
            _productRepository = productRepository;
            //_productRepositoryBase = productRepositoryBase;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Result<Response.ProductResponse>> Handle(Query.GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            //Should be throw exception or use Result<T>.Failure()
            //var productBase = await _productRepositoryBase.FindByIdAsync(request.Id)
            //    ?? throw new ProductException.ProductNotFoundException(request.Id);

            //var product = await _productRepository.FindByIdAsync(request.Id);
            //if (product is null)
            //    return Result.Failure<Response.ProductResponse>(ProductErrors.NotFound(request.Id));

            var product = await _productRepository.FindByIdAsync(request.Id)
                ?? throw new ProductException.ProductNotFoundException(request.Id);

            // TEST
            // EF Core
            //var product = await _dbContext.Products
            //    .AsNoTracking()
            //    .Where(p => p.Id == request.Id)
            //    .FirstOrDefaultAsync(cancellationToken);

            var result = _mapper.Map<Response.ProductResponse>(product);

            return Result.Success(result);
        }
    }
}