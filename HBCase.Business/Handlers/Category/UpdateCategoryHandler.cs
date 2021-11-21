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
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, BaseResponseResult>
    {
        private readonly ILogger<UpdateCategoryHandler> _logger;
        private readonly IRepository<Model.Entities.Category> _categoryRepository;

        public UpdateCategoryHandler(ILogger<UpdateCategoryHandler> logger, IRepository<Model.Entities.Category> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponseResult> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();

            try
            {
                var category = await _categoryRepository.GetByIdAsync(command.Id);
                
                if(category == null)
                {
                    response.Errors.Add("Category was not found.");
                    return response;
                }

                category.Name = command.Name;
                category.Description = command.Description;

                await _categoryRepository.UpdateAsync(command.Id, category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while update category.");
            }

            return response;
        }
    }
}