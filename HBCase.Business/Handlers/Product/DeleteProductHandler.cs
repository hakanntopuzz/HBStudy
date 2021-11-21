using HBCase.Data.Repositories;
using HBCase.Model.Commands.Product;
using HBCase.Model.Entities;
using HBCase.Model.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HBCase.Business.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, BaseResponseResult>
    {
        private readonly ILogger<DeleteProductHandler> _logger;
        private readonly IRepository<Product> _productRepository;

        public DeleteProductHandler(ILogger<DeleteProductHandler> logger, IRepository<Product> productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
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

                await _productRepository.DeleteAsync(command.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while delete product.");
            }

            return response;
        }
    }
}