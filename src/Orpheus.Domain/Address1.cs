using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class Address1 : PrimitiveValue<string, Address1, NotNullMax100CharactersString>
    {
    }
}