using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class Address1 : Value<string, Address1, NotNullMax100CharactersString>
    {
    }
}