using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class State : Value<string, State, NotNullMax100CharactersString>
    {
    }
}