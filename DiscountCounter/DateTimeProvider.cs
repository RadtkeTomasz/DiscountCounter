namespace DiscountCounter
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
