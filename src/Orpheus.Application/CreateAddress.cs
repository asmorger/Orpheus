using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orpheus.Domain;

namespace Orpheus.Application
{
    public class CreateAddress : IRequest<Address>
    {
        public CreateAddress(string? address1, string? address2, string? city, string? state, string? postalCode)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string? Address1 { get; }
        public string? Address2 { get; }
        public string? City { get; }
        public string? State { get; }
        public string? PostalCode { get; }
    }
    
    public class CreateAddressHandler : IRequestHandler<CreateAddress, Address>
    {
        public Task<Address> Handle(CreateAddress request, CancellationToken cancellationToken)
        {
            var address1 = Address1.Parse(request.Address1);
            var address2 = Address2.Parse(request.Address2);
            var city = City.Parse(request.City);
            var state = State.Parse(request.State);
            var postalCode = PostalCode.Parse(request.PostalCode);

            var result = new Address(address1, address2, city, state, postalCode);

            return Task.FromResult(result);
        }
    }
}