using Domain.Entities.BookEntity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validator
{
    public  class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(a=>a.Author).NotEmpty().MinimumLength(2).WithMessage("Author is requird");
            RuleFor(a=>a.Title).NotEmpty().MinimumLength(2).WithMessage("Title is requird");
            RuleFor(a=>a.Description).NotEmpty().MinimumLength(2).WithMessage("Description is requird");

        }
    }
}
