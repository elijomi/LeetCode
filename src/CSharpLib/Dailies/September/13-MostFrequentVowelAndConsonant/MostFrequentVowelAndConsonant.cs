namespace LeetCode.Dailies.MostFrequentVowelAndConsonant;

/// <summary>
/// You are given a string s consisting of lowercase English letters ('a' to 'z').
/// Your task is to:
/// Find the vowel (one of 'a', 'e', 'i', 'o', or 'u') with the maximum frequency.
/// Find the consonant (all other letters excluding vowels) with the maximum frequency.
/// Return the sum of the two frequencies.
/// Note: If multiple vowels or consonants have the same maximum frequency, you may 
/// choose any one of them.If there are no vowels or no consonants in the string, 
/// consider their frequency as 0. 
/// 
/// Constraints:
/// 1 <= s.length <= 100
/// s consists of lowercase English letters only.
/// 
/// https://leetcode.com/problems/find-most-frequent-vowel-and-consonant
/// </summary>
public class Solution
{
    private static bool IsVowel(char c) => c switch
    {
        'a' or 'e' or 'i' or 'o' or 'u' => true,
        _ => false
    };

    public int MaxFreqSum(string s)
    {
        int[] fq = new int[26]; // a-z constraints
        int maxV = 0;
        int maxC = 0;
        foreach (char c in s)
        {
            int idx = c - 'a'; fq[idx]++; int val = fq[idx];

            if (IsVowel(c))
            {
                if (val > maxV) maxV = val;
                continue;
            }

            if (val > maxC) maxC = val;
        }

        return maxC + maxV;
    }
}
