
using System.Text;

namespace Katas.TDD_III.V1;

public class ArabicNumber
{
    private static readonly int[] ARABIC_VALUES = [9, 5, 4, 1];
    private static readonly string[] ROMAN_VALUES = ["IX", "V", "IV", "I"];

    public static string ToRoman(int arabic)
    {
        StringBuilder romanBuilder = new();
        int remaining = arabic;

        for (int i = 0; i < ARABIC_VALUES.Length; i++)
        {
            remaining = AppendRomansNumerals(
                remaining,
                ARABIC_VALUES[i],
                ROMAN_VALUES[i],
                romanBuilder
            );
        }

        return romanBuilder.ToString();
    }

    private static int AppendRomansNumerals(int remaining, int arabicValue, string romanValue, StringBuilder builder)
    {
        while (remaining >= arabicValue)
        {
            builder.Append(romanValue);
            remaining -= arabicValue;
        }

        return remaining;
    }
}