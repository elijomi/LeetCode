namespace LeetCode.Dailies.VowelSpellchecker;

/// <summary>
/// Given a wordlist, we want to implement a spellchecker that converts a query word into a correct word.
/// When the query exactly matches a word in the wordlist (case-sensitive), you should return the same word back.
/// When the query matches a word up to capitlization, you should return the first such match in the wordlist.
/// When the query matches a word up to vowel errors, you should return the first such match in the wordlist.
/// If the query has no matches in the wordlist, you should return the empty string.
/// Given some queries, return a list of words answer, where answer[i] is the correct word for query = queries[i].
/// 
/// Constraints
/// 1 <= wordlist.length, queries.length <= 5000
/// 1 <= wordlist[i].length, queries[i].length <= 7
/// wordlist[i] and queries[i] consist only of only English letters.
/// 
/// https://leetcode.com/problems/vowel-spellchecker
/// </summary>
public class Solution
{
    private static bool IsVowel(char c) =>
        c is 'a' or 'e' or 'i' or 'o' or 'u';

    private static string DevowelLower(string s) =>
        string.Create(s.Length, s, static (span, src) =>
        {
            for (int i = 0; i < span.Length; i++)
            {
                char c = char.ToLowerInvariant(src[i]);
                span[i] = IsVowel(c) ? ':' : c;
            }
        });

    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var exact = new HashSet<string>(wordlist, StringComparer.Ordinal);
        var ci = new Dictionary<string, string>(wordlist.Length, StringComparer.OrdinalIgnoreCase);
        var dv = new Dictionary<string, string>(wordlist.Length, StringComparer.Ordinal);

        foreach (var w in wordlist)
        {
            if (!ci.ContainsKey(w)) ci[w] = w;

            var key = DevowelLower(w);
            if (!dv.ContainsKey(key)) dv[key] = w;
        }

        var ans = new string[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            var q = queries[i];

            if (exact.Contains(q))  // exact match
            {
                ans[i] = q;
                continue;
            }

            if (ci.TryGetValue(q, out var w1))  // case insensitive match
            {
                ans[i] = w1;
                continue;
            }

            var k = DevowelLower(q);
            ans[i] = dv.TryGetValue(k, out var w2) ? w2 : "";   // replaced vowel + ci match
        }

        return ans;
    }
}