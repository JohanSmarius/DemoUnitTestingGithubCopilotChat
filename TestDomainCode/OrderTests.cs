using Xunit;
using System.Collections.Generic;
using DemoApp;

namespace TestDomainCode;

public class OrderTests
{
    [Fact]
    public void TestTotalPrice()
    {
        // Arrange
        var order = CreateOrderWithLineItems();

        // Assert
        Assert.Equal(50, order.TotalPrice);
    }


    [Fact]
    public void TotalPrice_ShouldApply5PercentDiscountIfTotalIsJustMoreThan50()
    {
        // Arrange
        var order = new Order();
        var orderlineItem1 = new OrderLineItem { ProductName = "Product 1", Quantity = 50, Price = 1 };
        var orderlineItem2 = new OrderLineItem { ProductName = "Product 2", Quantity = 1, Price = 1 };
        order.AddOrderLineItem(orderlineItem1);
        order.AddOrderLineItem(orderlineItem2);

        // Act
        decimal totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(48.45m, totalPrice);
    }

    [Fact]
    public void TotalPrice_ShouldNotApply5PercentDiscountIfTotalIsJust49()
    {
        // Arrange
        var order = new Order();
        var orderlineItem1 = new OrderLineItem { ProductName = "Product 1", Quantity = 49, Price = 1 };
        order.AddOrderLineItem(orderlineItem1);

        // Act
        decimal totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(49.0m, totalPrice);
    }

    [Fact]
    public void TotalPrice_ShouldApply5PercentDiscountIfTotalIsGreaterThan50()
    {
        // Arrange
        var order = new Order();
        var orderlineItem1 = new OrderLineItem { ProductName = "Product 1", Quantity = 50, Price = 1 };
        var orderlineItem2 = new OrderLineItem { ProductName = "Product 2", Quantity = 20, Price = 1 };
        order.AddOrderLineItem(orderlineItem1);
        order.AddOrderLineItem(orderlineItem2);
       
        // Act
        decimal totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(66.50m, totalPrice);
    }


    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 99, 94.05m },
            new object[] { 100, 95.0m },
            new object[] { 101, 90.9m },
            new object[] { 200, 180.0m },
        };


    [Theory]
    [MemberData(nameof(Data))]

    public void TotalPrice_ShouldApplyPercentDiscountTakingBoundaryValuesInConsideration(int quantity, decimal totalPriceExpected)
    {
        // Arrange
        var order = new Order();
        var orderlineItem1 = new OrderLineItem { ProductName = "Product 1", Quantity = quantity, Price = 1 };
        order.AddOrderLineItem(orderlineItem1);

        // Act
        decimal totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(totalPriceExpected, totalPrice);
    }

    // Create a test to check for TotalPrice when there are no OrderLineItems
    [Fact] 
    public void TestTotalPriceNoOrderLines()
    {
        var sut = new Order();

        Assert.Equal(0, sut.TotalPrice);
    }

    [Fact]
    public void TestAddOrderLineItem()
    {
        // Arrange
        var lineItem1 = new OrderLineItem { ProductName = "Product 1", Quantity = 1, Price = 1 };
        var order = new Order();
        
        // Act
        order.AddOrderLineItem(lineItem1);
        
        // Assert
        Assert.Single(order.OrderLineItems);

        // Assert that lineItem1 is in the OrderLineItems collection
        Assert.Contains(lineItem1, order.OrderLineItems);
    }


    private Order CreateOrderWithLineItems()
    {
        var order = new Order();

        for (int i = 1; i <= 2 ; i++) 
        {
            order.AddOrderLineItem(new OrderLineItem { ProductName = $"Name-{i}", Price = i * 10, Quantity = i }); ;
        }

        return order;
    }


}
