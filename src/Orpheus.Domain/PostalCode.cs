using Calliope;
using Calliope.Validators;

namespace Orpheus.Domain
{
    public class PostalCode : PrimitiveValue<string, PostalCode, PostalCodeValidator>
    {
        private PostalCode(string value) : base(value)
        {
        }

        public static PostalCode Create(string value) => Create(value, x => new PostalCode(x));

        public static implicit operator string(PostalCode code) => code.Value;
    }

    public class PostalCodeValidator : RegexValidation
    {
        public PostalCodeValidator() : base("^[0-9]{5}(?:-[0-9]{4})?$") { }
    }
}