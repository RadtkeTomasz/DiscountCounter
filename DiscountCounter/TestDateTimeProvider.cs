namespace DiscountCounter
{
    public class TestDateTimeProvider : IDateTimeProvider
    {
        private DateTime _dateTime;

        public TestDateTimeProvider(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime CurrentDateTime()
        {
            return _dateTime;
        }
    }
}
