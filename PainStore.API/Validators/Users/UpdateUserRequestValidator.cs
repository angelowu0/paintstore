using System;
using FluentValidation;
using PaintStore.Models.DTOs;

namespace PaintStore.API.Validators;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name Length can not be more than 50 characters").Must(IsValidName)
                            .When(x => x.Name != null);

        RuleFor(x => x.Email).EmailAddress().WithMessage("Must be a valid email")
                             .When(x=>x.Email != null);

    }

    private bool IsValidName(string name)
    {
        return !name.Contains("@");
    }

}
