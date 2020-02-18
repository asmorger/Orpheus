using System;
using Calliope;

namespace Orpheus.Domain
{
    public class City : PrimitiveValue<string>
    {
        private City(string value) : base(value)
        {
        }
        
        public static City Parse(string? value)
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException();
            if(value.Length == 0) throw new ArgumentException();
            if(value.Length > 100) throw new ArgumentException();
            
            return new City(value!);
        }
    }
}