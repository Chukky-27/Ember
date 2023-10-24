using Ember.Domain.Base;
using Ember.Domain.Enum;

namespace Ember.Domain.Model
{
    public class Fragrance : Entity
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int VolumeInMilliliters { get; set; }

        public FragranceType Type { get; set; }

        public Intensity Intensity { get; set; }

        public Preference Preference { get; set; }
    }
}
