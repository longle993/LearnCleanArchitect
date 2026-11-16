using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnCleanArchitect.Application.Candidates.Commands.AddCandidates
{
    public class AddCandidateCommandValidator : AbstractValidator<AddCandidateCommand>
    {
        public AddCandidateCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.").MaximumLength(128);
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.").MaximumLength(128);
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage("Birth day is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.").MaximumLength(256);
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.").MaximumLength(15);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().MaximumLength(256);

        }
    }
}
