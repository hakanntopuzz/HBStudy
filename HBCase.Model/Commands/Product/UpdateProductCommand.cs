using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Commands.Product
{
    public class UpdateProductCommand : IRequest<BaseResponseResult>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}