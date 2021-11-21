using HBCase.Data.Repositories;
using HBCase.Model.Queries;
using HBCase.Model.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HBCase.Business.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, BaseResponseResult<CategoryResult>>
    {
        private readonly ILogger<GetCategoryHandler> _logger;
        private readonly IRepository<Model.Entities.Category> _categoryRepository;

        public GetCategoryHandler(ILogger<GetCategoryHandler> logger, IRepository<Model.Entities.Category> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponseResult<CategoryResult>> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<CategoryResult>();

            try
            {
                var category = await _categoryRepository.GetByIdAsync(query.Id);

                if(category == null)
                {
                    return response;
                }

                response.Result = new CategoryResult(category.Id, category.Name, category.Description);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("An error occurred while get category.");
            }

            return response;
        }
    }
}