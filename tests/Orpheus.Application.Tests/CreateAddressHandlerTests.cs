using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Calliope.Monads;
using Orpheus.Application.Tests.Builders;
using Orpheus.Domain;
using Xunit;

namespace Orpheus.Application.Tests
{
    namespace Orpheus.Application.Tests
    {
        public class CreateAddressHandlerTests
        {
            public CreateAddressHandlerTests()
            {
                _builder = new CreateAddressCommandBuilder();
                _handler = new CreateAddressHandler();
            }

            private readonly CreateAddressCommandBuilder _builder;
            private readonly CreateAddressHandler _handler;
            
            [Fact]
            public async Task Create_address_succeeds_given_valid_input()
            {
                var address = _builder.Generate();
                var result = await _handler.Handle(address, CancellationToken.None);

                Assert.Equal(address.Address1, result.Address1);
            }

            [Theory, MemberData(nameof(GetStandardInvalidStrings))]
            public void Create_address_fails_when_address1_is_invalid(string? address1) =>
                Assert.ThrowsAsync<ArgumentException>(() =>
                    _handler.Handle(_builder.WithAddress1(address1).Generate(), CancellationToken.None));

            [Theory, MemberData(nameof(GetStandardValidStrings))]
            public async Task Create_address_succeeds_when_address1_is_valid(string? address1)
            {
                var address = _builder.WithAddress1(address1).Generate();
                var result = await _handler.Handle(address, CancellationToken.None);

                Assert.Equal(address.Address1, result.Address1);
            }
            
            [Theory, MemberData(nameof(GetStandardInvalidStrings))]
            public void Create_address_fails_when_address2_is_invalid(string? address2) =>
                Assert.ThrowsAsync<ArgumentException>(() =>
                    _handler.Handle(_builder.WithAddress2(address2).Generate(), CancellationToken.None));
            
            [Theory, MemberData(nameof(GetStandardValidStrings))]
            public async Task Create_address_succeeds_when_address2_is_valid(string? address2)
            {
                var address = _builder.WithAddress2(address2).Generate();
                var result = await _handler.Handle(address, CancellationToken.None);

                var resultValue = result.Address2 as Some<Address2>;

                Assert.NotNull(resultValue);
                Assert.Equal(address.Address2, resultValue.Value);
            }

            [Theory, MemberData(nameof(GetStandardInvalidStrings))]
            public void Create_address_fails_when_city_is_invalid(string? city) =>
                Assert.ThrowsAsync<ArgumentException>(() =>
                    _handler.Handle(_builder.WithCity(city).Generate(), CancellationToken.None));
            
            [Theory, MemberData(nameof(GetStandardValidStrings))]
            public async Task Create_address_succeeds_when_city_is_valid(string? city)
            {
                var address = _builder.WithCity(city).Generate();
                var result = await _handler.Handle(address, CancellationToken.None);

                Assert.Equal(address.City, result.City);
            }
            
            [Theory, InlineData(null), InlineData(""), InlineData("USA")]
            public void Create_address_fails_when_state_is_invalid(string? state) =>
                Assert.ThrowsAsync<ArgumentException>(() =>
                    _handler.Handle(_builder.WithState(state).Generate(), CancellationToken.None));
            
            [Theory, InlineData("CO"), InlineData("MN"), InlineData("DC")]
            public async Task Create_address_succeeds_when_state_is_valid(string? state)
            {
                var address = _builder.WithState(state).Generate();
                var result = await _handler.Handle(address, CancellationToken.None);

                Assert.Equal(address.State, result.State);
            }
            
            [Theory, InlineData(null), InlineData(""), InlineData("USA"), InlineData("ABCDE")]
            public void Create_address_fails_when_postal_code_is_invalid(string? postalCode) =>
                Assert.ThrowsAsync<ArgumentException>(() =>
                    _handler.Handle(_builder.WithPostalCode(postalCode).Generate(), CancellationToken.None));

            [Theory, InlineData("12345"), InlineData("55923"), InlineData("12345-6789")]
            public async Task Create_address_succeeds_when_postal_code_is_valid(string? postalCode)
            {
                var address = _builder.WithPostalCode(postalCode).Generate();
                var result = await _handler.Handle(address, CancellationToken.None);

                Assert.Equal(address.PostalCode, result.PostalCode);
            }

            public static IEnumerable<object[]> GetStandardInvalidStrings() =>
                new List<object[]>
                {
                    new []{ (object)null },
                    new []{ string.Empty },
                    new []{ new string(Enumerable.Repeat('a', 100).ToArray()) }
                };
            
            public static IEnumerable<object[]> GetStandardValidStrings() =>
                new List<object[]>
                {
                    new []{ "123 Test Ln" },
                    new []{ "999 Post Rd" },
                    new []{ "Testopia" }
                };
        }
    }
}