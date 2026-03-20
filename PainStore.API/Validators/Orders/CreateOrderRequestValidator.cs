using System;
using FluentValidation;
using PaintStore.Models.DTOs.Orders;

namespace PaintStore.API.Validators.Orders;

public class CreateOrderRequestValidator: AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();

        RuleFor(x => x.Products);
    }
}
