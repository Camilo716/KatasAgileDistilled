using Katas.TDD_III.V1;

namespace Tests.TDD_III.V1;

public class ArabicNumberShould
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(9, "IX")]
    public void ConvertCorrectlyArabicNumberToRoman(int arabicNumber, string romanExpected)
    {
        string result = ArabicNumber.ToRoman(arabicNumber);

        Assert.Equal(romanExpected, result);
    }
}