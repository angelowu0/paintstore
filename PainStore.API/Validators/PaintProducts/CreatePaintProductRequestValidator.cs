using System;
using FluentValidation;
using PaintStore.Models.DTOs.PaintProducts;

namespace PaintStore.API.Validators.PaintProducts;

public class CreatePaintProductRequestValidator: AbstractValidator<CreatePaintProductRequest>
{
    public CreatePaintProductRequestValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name Length can not be more than 50 characters");

        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
