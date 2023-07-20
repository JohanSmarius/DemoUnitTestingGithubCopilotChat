namespace DemoApp;

public class Order
{
    public List<OrderLineItem> OrderLineItems { get; private set; } = new();


    public void AddOrderLineItem(OrderLineItem orderLineItem)
    {
        OrderLineItems.Add(orderLineItem);
    }

    // add property to return the total price of order
    public decimal TotalPrice => OrderLineItems.Sum(oli => oli.Price * oli.Quantity);


}
