using System;
using FluentValidation;
using PaintStore.Models.DTOs.PaintProducts;

namespace PaintStore.API.Validators.PaintProducts;

public class UpdatePaintProductRequestValidator: AbstractValidator<UpdatePaintProductRequest>
{
    public UpdatePaintProductRequestValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name Length can not be more than 50 characters").When(x => x.Name != null);
        RuleFor(x => x.Price).GreaterThan(0).When(x=>x.Price!=null);
        RuleFor(x => x.Quantity).GreaterThan(0).When(x=>x.Quantity!=null);
    }
}
