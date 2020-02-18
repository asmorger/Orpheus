using System;
using Calliope;

namespace Orpheus.Domain
{
    public class Address2 : PrimitiveValue<string>
    {
        public static readonly Address2 Empty = new Address2(string.Empty);

        private Address2(string value) : base(value)
        {
        }
        
        public static Address2 Parse(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Empty;
            if (value.Length > 100) throw new ArgumentException();
            
            return new Address2(value);
        }
    }
}