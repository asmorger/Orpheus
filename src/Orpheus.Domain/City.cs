using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class City : Value<string, City, NotNullMax100CharactersString>
    {
    }
}