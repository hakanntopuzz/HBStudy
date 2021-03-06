using HBCase.Model.Entities;
using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Queries
{
    public class GetProductQuery : IRequest<BaseResponseResult<ProductResult>>
    {
        public GetProductQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}