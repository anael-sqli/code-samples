using Shop;

namespace ShopUnitTests;

public class OrderReceiverTests
{
    [Fact]
    public void ShouldValidateOrdersMadeLessThan50KM()
    {
        var orderReceiver = BuildOrderReceiver();

        bool validated = orderReceiver.ProcessOrder(productId: 1, range: 49);

        validated.Should().BeTrue();
    }

    [Fact]
    public void ShouldValidateOrdersMadeAt50KM()
    {
        var orderReceiver = BuildOrderReceiver();

        bool validated = orderReceiver.ProcessOrder(productId: 1, range: 50);

        validated.Should().BeTrue();
    }

    [Fact]
    public void ShouldValidateOrdersMadeAt0KM()
    {
        var orderReceiver = BuildOrderReceiver();

        bool validated = orderReceiver.ProcessOrder(productId: 1, range: 0);

        validated.Should().BeTrue();
    }

    [Fact]
    public void ShouldNotValidateOrdersMadeMoreThan50KM()
    {
        var orderReceiver = BuildOrderReceiver();

        bool validated = orderReceiver.ProcessOrder(productId: 1, range: 51);

        validated.Should().BeFalse();
    }

    [Fact]
    public void ShouldRejectOrdersMadeWithNegativeRange()
    {
        var orderReceiver = BuildOrderReceiver();

        var act = () => orderReceiver.ProcessOrder(productId: 1, range: -1);

        act.Should().Throw<Exception>("The order was malformated");
    }

    private OrderReceiver BuildOrderReceiver()
    {
        var expectedDate = DateTime.Now;
        var orderReceiver = new OrderReceiver(new FakeDataSource(), new FakeDateProvider(expectedDate));
        return orderReceiver;
    }

}
