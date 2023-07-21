namespace DemoApp;

public class Order
{
    public List<OrderLineItem> OrderLineItems { get; private set; } = new();


    public void AddOrderLineItem(OrderLineItem orderLineItem)
    {
        OrderLineItems.Add(orderLineItem);
    }

    // add property to return the total price of order
    public decimal TotalPrice
    {
        get
        {
            var total = OrderLineItems.Sum(oli => oli.Price * oli.Quantity);

            // Apply a 10% discount if the total is greater than 100
            if (total > 100)
            {
                total *= 0.9m;
            } // Add a 5% discount if the total is greater than 50
            else if (total > 50)
            {
                total *= 0.95m;
            }

            return total;
        }
    }


}
