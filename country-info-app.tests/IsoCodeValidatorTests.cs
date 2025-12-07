using country_info_app.server.validation;

public class IsoCodeValidatorTests
{
    [Theory]
    [InlineData("BR", true)]
    [InlineData("USA", true)]
    [InlineData(" br ", true)]
    [InlineData("B", false)]
    [InlineData("BRZL", false)]
    [InlineData("12", false)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    public void IsValid_ReturnsExpectedResult(string input, bool expected)
    {
        var result = IsoCodeValidator.IsValid(input);

        Assert.Equal(expected, result);
    }
}
