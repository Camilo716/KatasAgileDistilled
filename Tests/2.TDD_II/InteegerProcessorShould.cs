namespace Tests.TDD_II;

using Katas.TDD_II;
using Katas.TDD_II.Dto;

public class InteegerProcessorShould
{
    [Fact]
    public void GetCorrectStatistics()
    {
        IntegeerProcessor processor = new();
        int[] numbers = [6, 9, 15, -2, 92, 11];

        SequenceNumberStatistics statistics = processor.GetStatistics(numbers); 

        Assert.Equal(-2, statistics.MinimumValue);
        Assert.Equal(92, statistics.MaximumValue);
        Assert.Equal(6, statistics.NumElementsInSequence);
        double tolerance = 0.000001;
        Assert.InRange(statistics.AverageValue, 21.833333 - tolerance, 21.833333 + tolerance);   
    }
}