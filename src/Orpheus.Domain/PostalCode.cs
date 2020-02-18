using System;
using System.Text.RegularExpressions;
using Calliope;

namespace Orpheus.Domain
{
    public class PostalCode : PrimitiveValue<string>
    {
        private PostalCode(string value) : base(value)
        {
        }

        public static PostalCode Parse(string? value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException();
            if (!Regex.IsMatch(value, "^[0-9]{5}(?:-[0-9]{4})?$")) throw new ArgumentException();
            
            return new PostalCode(value!);
        }
    }
}