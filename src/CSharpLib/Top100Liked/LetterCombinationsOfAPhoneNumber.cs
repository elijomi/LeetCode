namespace LeetCode.Top100Liked.LetterCombinationsOfAPhoneNumber;

/// <summary>
/// Given a string containing digits from 2-9 inclusive, return all possible 
/// letter combinations that the number could represent based on T9 typing. 
/// Return the answer in any order.
/// 
/// Constraints:
/// 0 <= digits.length <= 4
/// digits[i] is a digit in the range ['2', '9'].
/// 
/// https://leetcode.com/problems/letter-combinations-of-a-phone-number
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
