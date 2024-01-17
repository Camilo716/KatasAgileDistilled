namespace CConsole;

public class FizzBuzz
{
    public List<string> MapNumbersToFizzBuzz(int inclusiveFrom, int inclusiveTo)
    {
        List<string> words = new();

        for (int i = inclusiveFrom; i <= inclusiveTo; i++)
        {
            words.Add(MapNumberToFizzBuzz(i));
        }

        return words;
    }

    public string MapNumberToFizzBuzz(int number)
    {
        bool isMultipleOf3 = number % 3 == 0;
        string fizz = isMultipleOf3 ? "Fizz" : "";
        
        bool isMultipleOf5 = number % 5 == 0;
        string buzz = isMultipleOf5 ? "Buzz" : "";

        return fizz + buzz;
    }
}
