namespace Shop;

public class DateProvider : IDateProvider
{
    public DateProvider()
    {
    }

    public DateTime Now()
    {
        return DateTime.Now;
    }
}