//using MediatR;

//namespace DistributedSystem.Application.Behaviors
//{
//    public sealed class TransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//        where TRequest : notnull
//    {
//        private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2
//        private readonly IApplicationDbContext _context; // SQL-SERVER-STRATEGY-1

//        public TransactionPipelineBehavior(IUnitOfWork unitOfWork, IApplicationDbContext context)
//        {
//            _unitOfWork = unitOfWork;
//            _context = context;
//        }

//        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            if (!IsCommand())
//                return await next();

//            // ================= SQL-SERVER-STRATEGY-1 =================

//            // ================= SQL-SERVER-STRATEGY-2 =================
//        }

//        private bool IsCommand()
//            => typeof(TRequest).Name.EndsWith("Command");
//    }
//}