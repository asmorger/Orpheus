using Calliope;
using Calliope.Validators;

namespace Orpheus.Domain
{
    public class Address2 : Value<string, Address2, Address2Validator>
    {
    }

    public class Address2Validator : NullableStringValidator
    {
        public Address2Validator() : base(0, 100) { }
    }
}