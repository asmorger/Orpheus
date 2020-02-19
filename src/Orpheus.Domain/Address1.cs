using System;
using Calliope;

namespace Orpheus.Domain
{
    public class Address1 : PrimitiveValue<string>
    {
        private Address1(string value) : base(value)
        {
        }
        
        public static Address1 Parse(string? value)
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException();
            if(value.Length == 0) throw new ArgumentException();
            if(value.Length > 100) throw new ArgumentException();
            
            return new Address1(value!);
        }
        
        public static implicit operator string(Address1 value) => value.Value;
    }
}