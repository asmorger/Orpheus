using Bogus;
using Calliope.Monads;

namespace Orpheus.Application.Tests.Builders
{
    public class CreateAddressCommandBuilder
    {
        private Option<string?> Address1 { get; set; } = None.Value;
        private Option<string?> Address2 { get; set; } = None.Value;
        private Option<string?> City { get; set; } = None.Value;
        private Option<string?> State { get; set; } = None.Value;
        private Option<string?> PostalCode { get; set; } = None.Value;

        public CreateAddress Generate() =>
            new CreateAddressFaker(Address1, Address2, City, State, PostalCode).Generate();
 
        public CreateAddressCommandBuilder WithAddress1(string? address1)
        {
            Address1 = address1;
            return this;
        }
        
        public CreateAddressCommandBuilder WithAddress2(string? address2)
        {
            Address2 = address2;
            return this;
        }
        
        public CreateAddressCommandBuilder WithCity(string? city)
        {
            City = city;
            return this;
        }
        
        public CreateAddressCommandBuilder WithState(string? state)
        {
            State = state;
            return this;
        }
        
        public CreateAddressCommandBuilder WithPostalCode(string? postalCode)
        {
            PostalCode = postalCode;
            return this;
        }
        
        internal class CreateAddressFaker : Faker<CreateAddress>
        {
            internal CreateAddressFaker(Option<string?> address1, Option<string?> address2, Option<string?> city, 
                Option<string?> state, Option<string?> postalCode)
            {
                CustomInstantiator(f => new CreateAddress(
                    address1.ValueOrFallback(() => f.Address.StreetAddress()),
                    address2.ValueOrFallback(() => f.Address.SecondaryAddress()),
                    city.ValueOrFallback(() => f.Address.City()),
                    state.ValueOrFallback(() => f.Address.StateAbbr()),
                    postalCode.ValueOrFallback(() => f.Address.ZipCode())
                    ));
            }
        }
    }
}