using System.ComponentModel.DataAnnotations;

namespace DiscountCounter
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Name { get; set; }

        [Range(0,130)]
        public required int Age { get; set; }

        public required DateTime LastVisit { get; set; }

    }
}