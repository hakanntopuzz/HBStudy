using HBCase.Model.Results;
using MediatR;
using System.Collections.Generic;

namespace HBCase.Model.Queries
{
    public class GetProductsQuery : IRequest<BaseResponseResult<List<ProductResult>>>
    {
        public GetProductsQuery(string name, string categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
}