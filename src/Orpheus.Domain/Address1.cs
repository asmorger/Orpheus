using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class Address1 : PrimitiveValue<string, Address1, NotNullMax100CharactersString>
    {
        
        private Address1(string value) : base(value)
        {
        }

        public static Address1 Create(string value) => Create(value, e => new Address1(e));
        
        public static implicit operator string(Address1 value) => value.Value;
    }
}