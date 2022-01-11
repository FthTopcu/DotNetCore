using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
        ///bu validator sınıfı createbookcommandı valide eder (nesnelerini valide eder)
        public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
        {
                public CreateAuthorCommandValidator()
                {
                    RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);                   
                    RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);                   
                    RuleFor(command => command.Model.BirthDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
                }
        }

}