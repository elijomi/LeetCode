using LeetCode.Dailies.SortVowelsInString;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class SortVowelsInStringTests
{
    private readonly SortVowelsInStringSolver _sut = new();

    [Theory]
    [InlineData("lEetcOde", "lEOtcede")]         // LeetCode sample
    [InlineData("lYmpH", "lYmpH")]               // LeetCode sample (no vowels)
    [InlineData("UpjPbEnOj", "EpjPbOnUj")]       // LeetCode sample
    [InlineData("bcdfg", "bcdfg")]               // no vowels, unchanged
    [InlineData("a", "a")]                         // single vowel
    [InlineData("uoiea", "aeiou")]                 // all vowels lower -> sorted asc
    [InlineData("UOIEA", "AEIOU")]                 // all vowels upper -> sorted asc
    [InlineData("aUeIo", "IUaeo")]                 // mixed case ASCII order
    [InlineData("bAcdEfgI", "bAcdEfgI")]           // vowels already in order
    [InlineData("uUoOeEaA", "AEOUaeou")]           // uppercase come before lowercase
    [InlineData("ThIsIsA_LongString_WithVowelsAndConsonants", "ThAsAsI_LIngStrang_WethViwilsondConsononts")] // longer
    [InlineData("uUoOeEaAiIzzzYYY", "AEIOUaeiouzzzYYY")]           // vowels are non decreasing
    public void SortVowels_ReturnsExpected(string s, string expected)
    {
        var actual = _sut.SortVowels(s);

        Assert.Equal(expected, actual);
    }
}
