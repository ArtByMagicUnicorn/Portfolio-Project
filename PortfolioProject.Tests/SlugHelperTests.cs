using Portfolio_Project.Helpers;

namespace PortfolioProject.Tests;

public class SlugHelperTests
{
    [Theory]
    [InlineData("Portfolio Engine", "portfolio-engine")]
    [InlineData("Årets C# Projekt!!", "arets-c-projekt")]
    [InlineData("  Hello    World!!!  ", "hello-world")]
    public void GenerateSlug_ReturnsUrlFriendlySlug(string input, string expected)
    {
        var result = SlugHelper.GenerateSlug(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateSlug_ReturnsEmptyString_WhenInputIsEmpty()
    {
        var result = SlugHelper.GenerateSlug("");

        Assert.Equal("", result);
    }

    [Fact]
    public void GenerateSlug_ReturnsEmptyString_WhenInputIsWhitespace()
    {
        var result = SlugHelper.GenerateSlug("   ");

        Assert.Equal("", result);
    }
}