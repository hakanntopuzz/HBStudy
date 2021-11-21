using FluentValidation.AspNetCore;
using HBCase.ActionFilters;
using HBCase.Model.Commands.Category;
using Microsoft.Extensions.DependencyInjection;

namespace HBCase.Bootstrapper
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
        {
            services
                 .AddMvc(option => option.Filters.Add<ValidationFilter>())
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
                });

            return services;
        }
    }
}