using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace OrderService.Api.IntegrationTests.Orders;

public class CreateOrderTests 
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CreateOrderTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ShouldReturnBadRequestWhenOrderHasNoItems()
    {
        var payload = new
        {
            items = new object[] { }
        };

        var response = await _client.PostAsJsonAsync("/orders", payload);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
    