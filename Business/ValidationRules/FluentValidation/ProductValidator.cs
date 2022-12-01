using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //ProductName
            RuleFor(p => p.ProductName).NotNull();
            RuleFor(p => p.ProductName).MaximumLength(2);
            RuleFor(p => p.ProductName).Must(StartWithA);

            //UnitPrice
            RuleFor(p => p.UnitPrice).NotNull();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10)
                .When(p => p.CategoryId == 1);

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith('a') ? true : false;
        }
    }
}
