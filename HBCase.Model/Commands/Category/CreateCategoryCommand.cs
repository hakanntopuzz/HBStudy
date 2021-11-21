using FluentValidation;
using HBCase.Model.Resources;
using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Commands.Category
{
    public class CreateCategoryCommand : IRequest<BaseResponseResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(q => q.Name).NotNull().NotEmpty().WithMessage(Messages.ParameterCanNotBeEmpty);
        }
    }
}