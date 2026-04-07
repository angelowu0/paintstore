using System;
using FluentAssertions;
using PaintStore.Models.Models;

namespace PaintStore.Tests;

public class OrderModelTests
{
    [Fact]
    public void TotalPrice_WhenNoPaintProduct_ShouldBeZero()
    {
        // Arrange
        var order = new Order(1, 1);

        // Act
        order.TotalPrice.Should().Be(0);

        // Assert
    }
    [Fact]
    public void TotalPrice_WhenOneProduct_ShouldEqualPriceOfProduct()
    {
        // Arrange

        var order = new Order(1, 1);
        var product = new PaintProduct(1, "paint", 10m, 1);
        order.Products.Add(product);

        // Act & Assert
        order.TotalPrice.Should().Be(10m);

    }
}
