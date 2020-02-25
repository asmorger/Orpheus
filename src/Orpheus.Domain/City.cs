using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class City : PrimitiveValue<string, City, NotNullMax100CharactersString>
    {
        private City(string value) : base(value)
        {
        }

        public static City Create(string value) => Create(value, x => new City(x!));

        public static implicit operator string(City city) => city.Value;
    }
}