using Calliope.Validators;

namespace Orpheus.Domain.Validators
{
    public class NotNullMax100CharactersString : NotEmptyStringValidator
    {
        public NotNullMax100CharactersString() : base(minimumLength: 1, maximumLength: 100) { }
    }
}