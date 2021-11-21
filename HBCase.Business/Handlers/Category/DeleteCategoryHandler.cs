using HBCase.Data.Repositories;
using HBCase.Model.Commands.Category;
using HBCase.Model.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HBCase.Business.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, BaseResponseResult>
    {
        private readonly ILogger<DeleteCategoryHandler> _logger;
        private readonly IRepository<Model.Entities.Category> _categoryRepository;

        public DeleteCategoryHandler(ILogger<DeleteCategoryHandler> logger, IRepository<Model.Entities.Category> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponseResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();

            try
            {
                var category = await _categoryRepository.GetByIdAsync(command.Id);

                if (category == null)
                {
                    response.Errors.Add("Category was not found.");
                    return response;
                }

                await _categoryRepository.DeleteAsync(command.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while delete category.");
            }

            return response;
        }
    }
}