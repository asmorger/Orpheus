using Calliope;
using Orpheus.Domain.Validators;

namespace Orpheus.Domain
{
    public class State : PrimitiveValue<string, State, NotNullMax100CharactersString>
    {
        private State(string value) : base(value)
        {
        }

        public static State Create(string value) => Create(value, x => new State(x));

        public static implicit operator string(State state) => state.Value;
    }
}