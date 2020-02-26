using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class City : PrimitiveValue<string, City, NotNullMax100CharactersString>
    {
    }
}