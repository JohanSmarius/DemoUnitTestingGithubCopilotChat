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
