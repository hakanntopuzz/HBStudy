using HBCase.Data.Repositories;
using HBCase.Model.Commands.Product;
using HBCase.Model.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HBCase.Business.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, BaseResponseResult>
    {
        private readonly ILogger<CreateProductHandler> _logger;
        private readonly IRepository<Model.Entities.Product> _productRepository;

        public CreateProductHandler(ILogger<CreateProductHandler> logger, IRepository<Model.Entities.Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();

            try
            {
                var product = new Model.Entities.Product(command.Name, command.Description, command.CategoryId, command.Price, command.Currency);

                await _productRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while create product.");
            }

            return response;
        }
    }
}