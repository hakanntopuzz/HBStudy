using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<BaseResponseResult>
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}