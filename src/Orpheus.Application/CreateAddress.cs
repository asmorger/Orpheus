using System.Threading;
using System.Threading.Tasks;
using Calliope.FluentValidation;
using FluentValidation;
using MediatR;
using Orpheus.Domain;

namespace Orpheus.Application
{
    public class CreateAddress : IRequest<Address>
    {
        public CreateAddress(string address1, string address2, string city, string state, string postalCode)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Address1 { get; }
        public string Address2 { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
    }

    public class CreateAddressValidator : AbstractValidator<CreateAddress>
    {
        public CreateAddressValidator()
        {
            RuleFor(x => x.Address1).Targeting(Address1.Validator);
            RuleFor(x => x.Address2).Targeting(Address2.Validator);
            RuleFor(x => x.City).Targeting(City.Validator);
            RuleFor(x => x.State).Targeting(State.Validator);
            RuleFor(x => x.PostalCode).Targeting(PostalCode.Validator);
        }
    }
    
    public class CreateAddressHandler : IRequestHandler<CreateAddress, Address>
    {
        public Task<Address> Handle(CreateAddress request, CancellationToken cancellationToken)
        {
            var address1 = Address1.Create(request.Address1);
            var address2 = Address2.Create(request.Address2);
            var city = City.Create(request.City);
            var state = State.Create(request.State);
            var postalCode = PostalCode.Create(request.PostalCode);

            var result = Address.Create(address1, address2, city, state, postalCode);

            return Task.FromResult(result);
        }
    }
}