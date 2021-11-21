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
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, BaseResponseResult>
    {
        private readonly ILogger<CreateCategoryHandler> _logger;
        private readonly IRepository<Model.Entities.Category> _categoryRepository;

        public CreateCategoryHandler(ILogger<CreateCategoryHandler> logger, IRepository<Model.Entities.Category> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponseResult> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();

            try
            {
                var category = new Model.Entities.Category(command.Name, command.Description);

                await _categoryRepository.AddAsync(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while create category.");
            }

            return response;
        }
    }
}
