namespace LeetCode.Dailies.SortVowelsInString;

/// <summary>
/// Given a 0-indexed string s, permute s to get a new string t such that:
/// All consonants remain in their original places. More formally, if there is an index i with 0 <= i < s.length 
/// such that s[i] is a consonant, then t[i] = s[i]. The vowels must be sorted in the nondecreasing order of 
/// their ASCII values. More formally, for pairs of indices i, j with 0 <= i < j < s.length such that s[i] and 
/// s[j] are vowels, then t[i] must not have a higher ASCII value than t[j].
/// 
/// The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in lowercase or uppercase. Consonants comprise 
/// all letters that are not vowels.
/// 
/// Constraints:
/// 1 <= s.length <= 10^5
/// s consists only of letters of the English alphabet in uppercase and lowercase.
/// 
/// https://leetcode.com/problems/sort-vowels-in-a-string
/// </summary>
public class SortVowelsInStringSolver
{
    private static bool IsVowel(char c) => c switch
    {
        'a' or 'e' or 'i' or 'o' or 'u' or
        'A' or 'E' or 'I' or 'O' or 'U' => true,
        _ => false
    };

    public string SortVowels(string s)
    {

        var sortedVowels = new List<char>();
        var vowelIndices = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (IsVowel(c))
            {
                sortedVowels.Add(c);
                vowelIndices.Add(i);
            }
        }

        if (vowelIndices.Count < 2) return s;

        sortedVowels.Sort();

        int viLength = vowelIndices.Count;
        if (viLength == s.Length) return new string(sortedVowels.ToArray());

        char[] sc = s.ToCharArray();

        for (int i = 0; i < viLength; i++)
        {
            sc[vowelIndices[i]] = sortedVowels[i];
        }

        return new string(sc);
    }
}

