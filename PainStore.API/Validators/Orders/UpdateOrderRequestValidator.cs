using System;
using FluentValidation;
using PaintStore.Models.DTOs.Orders;

namespace PaintStore.API.Validators.Orders;

public class UpdateOrderRequestValidator: AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().When(x=>x.UserId!=null);

        // RuleFor(x => x.Products).When(x=>x.Products!=null);
    }
}
