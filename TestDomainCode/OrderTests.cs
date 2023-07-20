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

    //[Fact]
    //public void TestAddOrderLineItem()
    //{
    //    // Arrange
    //    var lineItem1 = new OrderLineItem(1, "Item 1", 10, 2);
    //    var lineItem2 = new OrderLineItem(2, "Item 2", 20, 3);

    //    var order = new Order();

    //    // Act
    //    order.AddOrderLineItem(lineItem1);
    //    order.AddOrderLineItem(lineItem2);

    //    // Assert
    //    Assert.Equal(2, order.OrderLineItems.Count);
    //}

    //[Fact]
    //public void TestOrderLineItemIsAdded()
    //{
    //    // Arrange
    //    var lineItem1 = new OrderLineItem(99, "Item 99", 100, 1);

    //    var order = new Order();

    //    // Act
    //    order.AddOrderLineItem(lineItem1);

    //    // Assert
    //    Assert.Contains(lineItem1, order.OrderLineItems);
   // }

    private Order CreateOrderWithLineItems()
    {
        var order = new Order();
        for (int i = 1; i <= 2; i++)
        {
            order.AddOrderLineItem(new OrderLineItem() { ProductName = $"Name-{i}", Price = i * 10, Quantity = i});
        }
        return order;
    }

}
