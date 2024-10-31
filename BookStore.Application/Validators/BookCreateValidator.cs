using BookStore.Application.Models;
using FluentValidation;

namespace BookStore.Application.Validators
{
    public class BookCreateValidator : AbstractValidator<BookCreateModel>
    {
        public BookCreateValidator()
        {
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price is not valid");
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is not valid");
            RuleFor(p => p.AuthorsName)
                .NotEmpty().WithMessage("Authors is not valid");
        }
    }
}
