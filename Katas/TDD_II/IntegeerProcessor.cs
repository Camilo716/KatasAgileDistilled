using Console.Dto;

namespace CConsole.KataClass;

public class IntegeerProcessor
{
    public SequenceNumberStatistics GetStatistics(IEnumerable<int> numbers)
    {
        SequenceNumberStatistics statistics = new()
        {
            MaximumValue = numbers.Max(),
            MinimumValue = numbers.Min(),
            NumElementsInSequence = numbers.Count(),
            AverageValue = numbers.Average()
        };

        return statistics;
    }


}