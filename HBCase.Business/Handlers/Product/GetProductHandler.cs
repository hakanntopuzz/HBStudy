using HBCase.Data.Repositories;
using HBCase.Model.Entities;
using HBCase.Model.Queries;
using HBCase.Model.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HBCase.Business.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, BaseResponseResult<ProductResult>>
    {
        private readonly ILogger<GetProductHandler> _logger;
        private readonly IRepository<Product> _productRepository;

        public GetProductHandler(ILogger<GetProductHandler> logger, IRepository<Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseResult<ProductResult>> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<ProductResult>();

            try
            {
                var product = await _productRepository.GetByIdAsync(query.Id);

                if (product == null)
                {
                    return response;
                }

                response.Result = new ProductResult(product.Id, product.Name, product.Description, product.CategoryId, product.Price, product.Currency);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while get product.");
            }

            return response;
        }
    }
}