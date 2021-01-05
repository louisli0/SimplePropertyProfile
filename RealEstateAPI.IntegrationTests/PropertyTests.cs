using Xunit;
using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Contracts.V1.Request;

public class VGQueryTests : IClassFixture<Setup>
{
    Setup _fixture;

    public VGQueryTests(Setup fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Query_VG_Property()
    {
        // Arrange
        //await _fixture.AuthenticateAsync();
        QueryVGData propertyQuery = new QueryVGData
        {
            HouseNumber = "89",
            StreetName = "Tungstall",
            Locality = "Kensington",
            PostCode = "2032"
        };

        //Act
        var response = await _fixture.QueryProperty(propertyQuery);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Query_Locality()
    {
        QueryVGData LocalityQuery = new QueryVGData
        {
            Locality = "Hornsby"
        };

        var response = await _fixture.QueryLocality(LocalityQuery);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }


}