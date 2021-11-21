using HBCase.Business.Services;
using HBCase.Data.Repositories;
using HBCase.Model.Entities;
using HBCase.Model.Queries;
using HBCase.Model.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HBCase.Business.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, BaseResponseResult<List<ProductResult>>>
    {
        private readonly ILogger<GetProductsHandler> _logger;
        private readonly IRepository<Product> _productRepository;
        private readonly ICacheService _cacheService;

        public GetProductsHandler(ILogger<GetProductsHandler> logger, IRepository<Product> productRepository, ICacheService cacheService)
        {
            _logger = logger;
            _productRepository = productRepository;
            _cacheService = cacheService;
        }

        public async Task<BaseResponseResult<List<ProductResult>>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<List<ProductResult>>();

            try
            {
                string cacheKey = $"ProductsCache_{query.Name}_{query.CategoryId}";
                var cacheData = _cacheService.Get<List<ProductResult>>(cacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                    return response;
                }

                var products = GetProducts(query.Name, query.CategoryId);

                if(products.Count > 0)
                {
                    _cacheService.Set(cacheKey, products, TimeSpan.FromMinutes(5));
                }
               
                response.Result = products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while get products.");
            }

            return response;
        }

        private List<ProductResult> GetProducts(string name, string categoryId)
        {
            var productsQuery = _productRepository.Get();

            if (!string.IsNullOrEmpty(name))
            {
                productsQuery = productsQuery.Where(q => q.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(categoryId))
            {
                productsQuery = productsQuery.Where(q => q.CategoryId == categoryId);
            }

            return productsQuery.Select(s => new ProductResult
            {
                CategoryId = s.CategoryId,
                Currency = s.Currency,
                Description = s.Description,
                Id = s.Id,
                Name = s.Name,
                Price = s.Price
            }).ToList();
        }
    }
}