using System;
using Calliope;

namespace Orpheus.Domain
{
    public class State : PrimitiveValue<string>
    {
        private State(string value) : base(value)
        {
        }
        
        public static State Parse(string? value)
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentException();
            if(value!.Length != 2) throw new ArgumentException();
            
            return new State(value!);
        }
    }
}