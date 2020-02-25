using Calliope;
using Calliope.Validators;

namespace Orpheus.Domain
{
    public class Address2 : PrimitiveValue<string, Address2, Address2Validator>
    {
        private Address2(string value) : base(value)
        {
        }

        public static Address2 Create(string value) => Create(value, x => new Address2(value));

        public static implicit operator string(Address2 value) => value.Value;
    }

    public class Address2Validator : NullableStringValidator
    {
        public Address2Validator() : base(0, 100) { }
    }
}