namespace Shop;

public class FakeDateProvider : IDateProvider
{
    private readonly DateTime _dateToProvide;

    public FakeDateProvider(DateTime dateToProvide)
    {
        _dateToProvide = dateToProvide;
    }

    public DateTime Now()
    {
        return _dateToProvide;
    }
}
