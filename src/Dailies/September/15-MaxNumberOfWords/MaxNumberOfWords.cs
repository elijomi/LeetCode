namespace LeetCode.Dailies.MaxNumberOfWords;

/// <summary>
/// There is a malfunctioning keyboard where some letter keys do not work. All other keys on the keyboard work properly.
/// Given a string text of words separated by a single space(no leading or trailing spaces) and a string brokenLetters of 
/// all distinct letter keys that are broken, return the number of words in text you can fully type using this keyboard.
/// 
/// Constraints
/// 1 <= text.length <= 10^4
/// 0 <= brokenLetters.length <= 26
/// text consists of words separated by a single space without any leading or trailing spaces.
/// Each word only consists of lowercase English letters.
/// brokenLetters consists of distinct lowercase English letters.
/// 
/// https://leetcode.com/problems/maximum-number-of-words-you-can-type
/// </summary>
public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        HashSet<char> brokens = [.. brokenLetters];
        int words = 0;
        bool skip = false;
        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (brokens.Contains(letter))
            {
                skip = true;
                continue;
            }
            if (text[i] == ' ' || i == text.Length - 1)
            {
                words = skip ? words : words + 1;
                skip = false;
            }
        }

        return words;
    }
}