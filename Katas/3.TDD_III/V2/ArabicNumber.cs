
namespace Katas.TDD_III.V2;

public class ArabicNumber
{
    private static readonly Dictionary<int, string> _mapping = new(){
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"},
    };

    public static string ToRoman(int arabicValue)
    {
        string result = "";

        foreach (var mapping in _mapping)
        {
            while (arabicValue >= mapping.Key)
            {
                result += mapping.Value;
                arabicValue -= mapping.Key;
            }
        }

        return result;
    }
}