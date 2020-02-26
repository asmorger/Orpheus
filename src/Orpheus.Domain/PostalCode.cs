using Calliope;
using Calliope.Validators;

namespace Orpheus.Domain
{
    public class PostalCode : PrimitiveValue<string, PostalCode, PostalCodeValidator>
    {
    }

    public class PostalCodeValidator : RegexValidation
    {
        public PostalCodeValidator() : base("^[0-9]{5}(?:-[0-9]{4})?$") { }
    }
}