namespace LeetCode.Dailies.DesignSpreadsheet;

public class Spreadsheet
{
    private readonly Dictionary<string, int> sheet = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    private static int ParseToken(ReadOnlySpan<char> s, Dictionary<string, int> sheet)
    {
        if (int.TryParse(s, out var val))
            return val;

        return sheet.TryGetValue(new string(s), out var cellVal) ? cellVal : 0;
    }

    public Spreadsheet(int rows) // req 
    { }

    public void SetCell(string cell, int value) => sheet[cell] = value;

    public void ResetCell(string cell) => sheet.Remove(cell);

    public int GetValue(string formula)
    {
        ReadOnlySpan<char> span = formula.AsSpan().Slice(1); // expect "=<lhs>+<rhs>"

        int plus = span.IndexOf('+');
        var lhs = span.Slice(0, plus);
        var rhs = span.Slice(plus + 1);

        return ParseToken(lhs, sheet) + ParseToken(rhs, sheet);
    }
}