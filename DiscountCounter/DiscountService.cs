
namespace DiscountCounter
{
    public class DiscountService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private const int _daysFromLastVisitEligibleForDiscount = 200;

        public DiscountService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public int DiscountPercentCount(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (customer.Age <= 4)
                return 100;
            if (customer.Age >= 65)
                return 30;
            if (_dateTimeProvider.CurrentDateTime().AddDays(-_daysFromLastVisitEligibleForDiscount) > customer.LastVisit)
                return 50;
            return 0;
        }

        public decimal ApplyDiscount(decimal price, Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            return price - price * DiscountPercentCount(customer) / 100;
        }
    }
}