using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Commands.Product
{
    public class DeleteProductCommand : IRequest<BaseResponseResult>
    {
        public DeleteProductCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}