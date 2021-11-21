using HBCase.Model.Entities;
using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Queries
{
    public class GetCategoryQuery : IRequest<BaseResponseResult<CategoryResult>>
    {
        public GetCategoryQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}