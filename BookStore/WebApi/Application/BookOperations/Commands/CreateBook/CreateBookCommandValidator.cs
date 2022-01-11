using System;
using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
        ///bu validator sınıfı createbookcommandı valide eder (nesnelerini valide eder)
        public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
        {
                public CreateBookCommandValidator()
                {
                    RuleFor(command => command.Model.GenreId).GreaterThan(0);
                    RuleFor(command => command.Model.PageCount).GreaterThan(0);
                    RuleFor(command => command.Model.AuthorId).GreaterThan(0);
                    RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
                    RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
                }
        }

}