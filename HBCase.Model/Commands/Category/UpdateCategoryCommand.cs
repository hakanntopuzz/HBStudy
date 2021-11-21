using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<BaseResponseResult>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}