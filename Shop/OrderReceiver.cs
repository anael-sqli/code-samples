namespace Shop;

public class OrderReceiver
{
    private ISaveOrder _saveOrder;
    private IDateProvider _dateProvider;

    public OrderReceiver(ISaveOrder saveOrder, IDateProvider dateProvider)
    {
        _saveOrder = saveOrder;
        _dateProvider = dateProvider;
    }

    public bool ProcessOrder(int productId, int range)
    {
        if (range < 0) throw new Exception("The order is too far");
        if (range > 50) return false;
        var order = new Order(productId, range);
        order.CreatedDate = _dateProvider.Now();
        _saveOrder.Save(order);
        return true;
    }
}