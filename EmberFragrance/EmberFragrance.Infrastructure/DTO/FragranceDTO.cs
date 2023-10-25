using Ember.Domain.Enum;

namespace Ember.Infrastructure.DTO
{
    public class FragranceDTO
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int VolumeInMilliliters { get; set; }

        public FragranceType Type { get; set; }

        public Intensity Intensity { get; set; }

        public Preference Preference { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
