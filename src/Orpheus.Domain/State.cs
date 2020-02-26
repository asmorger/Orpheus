using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class State : PrimitiveValue<string, State, NotNullMax100CharactersString>
    {
    }
}