namespace Shop;

public record class Order(int productId, int range)
{
    public DateTime CreatedDate { get; internal set; }
}

