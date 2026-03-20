using System;
using FluentValidation;
using PaintStore.Models.DTOs;

namespace PaintStore.API.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty")
                            .MaximumLength(50).WithMessage("Name Length can not be more than 50 characters").Must(IsValidName);

        RuleFor(x => x.Email).EmailAddress().WithMessage("Must be a valid email");
    }

    private bool IsValidName(string name)
    {
        return !name.Contains("@");
    }
}
