using System.Runtime.InteropServices;

namespace LeetCodeProblems.Top100Liked.LetterCombinationsOfAPhoneNumber;

public class Runner
{
    /// <summary>
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number
    /// </summary>
    public static void Run()
    {
        var solver = new Solution();

        // Test cases
        var tests = new (string digits, IList<string> expected)[]
        {
            ("23", new List<string> { "ad","ae","af","bd","be","bf","cd","ce","cf" }),
            ("", new List<string>()),
            ("2", new List<string> { "a","b","c" }),
        };

        int i = 1;
        foreach (var (digits, expected) in tests)
        {
            var actual = solver.LetterCombinations(digits);
            Console.WriteLine($"Test {i}: expected=[{string.Join(",", expected)}], actual=[{string.Join(",", actual)}] - {(UnorderedSetEqual(actual, expected) ? "PASS" : "FAIL")}");
            i++;
        }


    }

    public static bool UnorderedSetEqual(IList<string>? a, IList<string>? b, IEqualityComparer<string>? comparer = null)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        var cmp = comparer ?? StringComparer.Ordinal;
        var setA = new HashSet<string>(a, cmp);
        var setB = new HashSet<string>(b, cmp);
        return setA.SetEquals(setB);
    }    
}

/// <summary>
/// Given a string containing digits from 2-9 inclusive, return all possible 
/// letter combinations that the number could represent based on T9 typing. 
/// Return the answer in any order.
/// 
/// Constraints:
/// 0 <= digits.length <= 4
/// digits[i] is a digit in the range ['2', '9'].
/// </summary>
public class Solution
{
    private static readonly string[] Map = { "", "", "abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"};

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits)) return new List<string>();

        var res = new Queue<string>();
        res.Enqueue("");

        foreach (char d in digits)
        {
            string letters = Map[d - '0'];

            for (int j = res.Count; j > 0; j--)
            {
                var baseStr = res.Dequeue();

                foreach (char ltr in letters)
                {
                    res.Enqueue(baseStr + ltr);
                }
            }
        }

        return res.ToList();
    }
}