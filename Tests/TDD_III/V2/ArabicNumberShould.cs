using Katas.TDD_III.V2;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Tests.TDD_III.V2;

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
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(40, "XL")]
    [InlineData(44, "XLIV")]
    public void ConvertToRomanCorrectly(int arabicValue, string romanExpected)
    {
        string result = ArabicNumber.ToRoman(arabicValue);

        Assert.Equal(romanExpected, result);
    }
}