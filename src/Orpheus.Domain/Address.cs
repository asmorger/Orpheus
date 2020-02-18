using System.Collections.Generic;
using Calliope;

namespace Orpheus.Domain
{
    public class Address : Value
    {
        public Address1 Address1 { get; }
        public Address2 Address2 { get; }
        public City City { get; }
        public State State { get; }
        public PostalCode PostalCode { get; }

        public Address(Address1 address1, Address2 address2, City city, State state, PostalCode postalCode)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address1;
            yield return Address2;
            yield return City;
            yield return State;
            yield return PostalCode;
        }
    }
}