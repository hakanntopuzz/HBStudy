using FluentValidation;
using HBCase.Model.Resources;
using HBCase.Model.Results;
using MediatR;

namespace HBCase.Model.Commands.Product
{
    public class CreateProductCommand : IRequest<BaseResponseResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get;  set; }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(q => q.Name).NotNull().NotEmpty().WithMessage(Messages.ParameterCanNotBeEmpty);
            RuleFor(q => q.CategoryId).NotNull().NotEmpty().WithMessage(Messages.ParameterCanNotBeEmpty);
            RuleFor(q => q.Price).GreaterThan(0).WithMessage(Messages.ValueGreaterThanZero);
            RuleFor(q => q.Currency).NotNull().NotEmpty().WithMessage(Messages.ParameterCanNotBeEmpty);
        }
    }
}