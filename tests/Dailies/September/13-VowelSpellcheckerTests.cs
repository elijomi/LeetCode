using LeetCode.Dailies.VowelSpellchecker;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class VowelSpellcheckerTests
{
    private readonly Solution _sut = new();

    [Fact]
    public void MinimumTeachings_LeetCodeSample1()
    {
        string[] wordlist =
        {
            "KiTe","kite","hare","Hare"
        };
        string[] queries =
        {
            "kite","Kite","KiTe","Hare","HARE","Hear","hear","keti","keet","keto"
        };
        string[] expected =
        {
            "kite","KiTe","KiTe","Hare","hare","","","KiTe","","KiTe"
        };

        string[] actual = _sut.Spellchecker(wordlist, queries);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MinimumTeachings_LeetCodeSample2()
    {
        string[] wordlist =
        {
            "yellow"
        };
        string[] queries =
        {
            "YellOw"
        };
        string[] expected =
        {
            "yellow"
        };

        string[] actual = _sut.Spellchecker(wordlist, queries);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MinimumTeachings_LeetCodeSample3()
    {
        string[] wordlist =
        {
            "zeo","Zuo"
        };
        string[] queries =
        {
            "zuo"
        };
        string[] expected =
        {
            "Zuo"
        };

        string[] actual = _sut.Spellchecker(wordlist, queries);

        Assert.Equal(expected, actual);
    }
}
