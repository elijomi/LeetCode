using LeetCode.Dailies.DesignSpreadsheet;
using Xunit;

namespace LeetCode.Tests.Dailies.September;


public class SpreadsheetTests
{
    [Fact]
    public void SetCell_ShouldStoreValue()
    {
        var sheet = new Spreadsheet(10);

        sheet.SetCell("A1", 42);

        Assert.Equal(42, sheet.GetValue("=A1+0")); // A1 + 0 = 42
    }

    [Fact]
    public void ResetCell_ShouldRemoveValue()
    {
        var sheet = new Spreadsheet(10);
        sheet.SetCell("A1", 42);

        sheet.ResetCell("A1");

        Assert.Equal(0, sheet.GetValue("=A1+0")); // A1 removed → 0
    }

    [Fact]
    public void GetValue_ShouldAddTwoNumbers()
    {
        var sheet = new Spreadsheet(10);

        var result = sheet.GetValue("=5+7");

        Assert.Equal(12, result);
    }

    [Fact]
    public void GetValue_ShouldAddCellAndNumber()
    {
        var sheet = new Spreadsheet(10);
        sheet.SetCell("A1", 10);

        var result = sheet.GetValue("=A1+5");

        Assert.Equal(15, result);
    }

    [Fact]
    public void GetValue_ShouldAddTwoCells()
    {
        var sheet = new Spreadsheet(10);
        sheet.SetCell("A1", 10);
        sheet.SetCell("B2", 20);

        var result = sheet.GetValue("=A1+B2");

        Assert.Equal(30, result);
    }

    [Fact]
    public void GetValue_ShouldTreatMissingCellsAsZero()
    {
        var sheet = new Spreadsheet(10);

        var result = sheet.GetValue("=A1+B2");

        Assert.Equal(0, result); // both cells unset → 0 + 0
    }

    [Fact]
    public void GetValue_ShouldHandleCellPlusMissingCell()
    {
        var sheet = new Spreadsheet(10);
        sheet.SetCell("A1", 10);

        var result = sheet.GetValue("=A1+B2");

        Assert.Equal(10, result); // B2 defaults to 0
    }
}
