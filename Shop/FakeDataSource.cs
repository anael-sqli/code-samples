namespace Shop;

public class FakeDataSource : ISaveOrder
{
    private List<Order> Orders { get; set; } = new List<Order>();
    public void Save(Order order)
    {
        Orders.Add(order);
    }
}
