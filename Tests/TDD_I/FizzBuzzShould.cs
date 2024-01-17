using CConsole;

namespace Tests;

public class FizzBuzzShould
{
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public void ReturnFizzGivenMultipleOf3(int number)
    {
        var fizzBuzz = new FizzBuzz();

        string response = fizzBuzz.MapNumberToFizzBuzz(number);

        Assert.Equal("Fizz", response);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void ReturnBuzzGivenMultipleOf5(int number)
    {
        var fizzBuzz = new FizzBuzz();

        string response = fizzBuzz.MapNumberToFizzBuzz(number);

        Assert.Equal("Buzz", response);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    public void ReturnFizzBuzzGivenMultipleOf3And5(int number)
    {
        var fizzBuzz = new FizzBuzz();

        string response = fizzBuzz.MapNumberToFizzBuzz(number);

        Assert.Equal("FizzBuzz", response);
    }

    [Fact]
    public void MapNumbersToFizzBuzz()
    {
        var fizzBuzz = new FizzBuzz();

        List<string> response = fizzBuzz.MapNumbersToFizzBuzz(
            inclusiveFrom : 1,
            inclusiveTo: 100
        );

        int fizzBuzzCount = response.Count(word => word == "FizzBuzz");
        Assert.Equal(6, fizzBuzzCount);

        int fizzCount = response.Count(word => word == "Fizz");
        Assert.Equal(27, fizzCount);

        int buzzCount = response.Count(word => word == "Buzz");
        Assert.Equal(14, buzzCount);
    }
}