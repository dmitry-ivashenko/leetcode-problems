// 242. Valid Anagram
//
// Given two strings s and t, return true if t is an anagram of s, and false otherwise.
//
// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
//
//
//
// Example 1:
//
// Input: s = "anagram", t = "nagaram"
// Output: true
// Example 2:
//
// Input: s = "rat", t = "car"
// Output: false
//
//
// Constraints:
//
// 1 <= s.length, t.length <= 5 * 104
// s and t consist of lowercase English letters.
//
//
// Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var dict = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            var value = 0;
            dict.TryGetValue(c, out value);
            dict[c] = value + 1;
        }

        for (var i = 0; i < t.Length; i++)
        {
            var c = t[i];
            if (!dict.TryGetValue(c, out var value) || value <= 0)
                return false;

            if (value == 1)
                dict.Remove(c);
            else
                dict[c] = value - 1;
        }

        return dict.Count == 0;
    }
}