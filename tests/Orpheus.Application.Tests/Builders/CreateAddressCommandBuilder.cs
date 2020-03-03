using Bogus;
using Calliope;

namespace Orpheus.Application.Tests.Builders
{
    public class CreateAddressCommandBuilder
    {
        private Optional<string> Address1 { get; set; } = Optional<string>.None;
        private Optional<string> Address2 { get; set; } = Optional<string>.None;
        private Optional<string> City { get; set; } = Optional<string>.None;
        private Optional<string> State { get; set; } = Optional<string>.None;
        private Optional<string> PostalCode { get; set; } = Optional<string>.None;

        public CreateAddress Generate() =>
            new CreateAddressFaker(Address1, Address2, City, State, PostalCode).Generate();
 
        public CreateAddressCommandBuilder WithAddress1(string address1)
        {
            Address1 = address1;
            return this;
        }
        
        public CreateAddressCommandBuilder WithAddress2(string address2)
        {
            Address2 = address2;
            return this;
        }
        
        public CreateAddressCommandBuilder WithCity(string city)
        {
            City = city;
            return this;
        }
        
        public CreateAddressCommandBuilder WithState(string state)
        {
            State = state;
            return this;
        }
        
        public CreateAddressCommandBuilder WithPostalCode(string postalCode)
        {
            PostalCode = postalCode;
            return this;
        }
        
        internal class CreateAddressFaker : Faker<CreateAddress>
        {
            internal CreateAddressFaker(Optional<string> address1, Optional<string> address2, Optional<string> city, 
                Optional<string> state, Optional<string> postalCode)
            {
                CustomInstantiator(f => new CreateAddress(
                    address1.Unwrap(() => f.Address.StreetAddress()),
                    address2.Unwrap(() => f.Address.SecondaryAddress()),
                    city.Unwrap(() => f.Address.City()),
                    state.Unwrap(() => f.Address.StateAbbr()),
                    postalCode.Unwrap(() => f.Address.ZipCode())
                    ));
            }
        }
    }
}