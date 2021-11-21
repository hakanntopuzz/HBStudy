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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, BaseResponseResult>
    {
        private readonly ILogger<UpdateProductHandler> _logger;
        private readonly IRepository<Model.Entities.Product> _productRepository;

        public UpdateProductHandler(ILogger<UpdateProductHandler> logger, IRepository<Model.Entities.Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();

            try
            {
                var product = await _productRepository.GetByIdAsync(command.Id);

                if (product == null)
                {
                    response.Errors.Add("Product was not found.");
                    return response;
                }

                product.Name = command.Name;
                product.Description = command.Description;
                product.Price = command.Price;
                product.Currency = command.Currency;
                product.CategoryId = command.CategoryId;

                await _productRepository.UpdateAsync(command.Id, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while update product.");
            }

            return response;
        }
    }
}