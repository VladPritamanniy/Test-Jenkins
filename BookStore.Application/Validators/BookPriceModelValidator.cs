using BookStore.Application.Models;
using FluentValidation;

namespace BookStore.Application.Validators
{
    public class BookPriceModelValidator : AbstractValidator<BookPriceModel>
    {
        public BookPriceModelValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is not valid");
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price is not valid");
        }
    }
}
