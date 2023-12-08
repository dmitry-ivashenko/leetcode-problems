// 383. Ransom Note
//
// Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
//
// Each letter in magazine can only be used once in ransomNote.
//
//
//
// Example 1:
//
// Input: ransomNote = "a", magazine = "b"
// Output: false
// Example 2:
//
// Input: ransomNote = "aa", magazine = "ab"
// Output: false
// Example 3:
//
// Input: ransomNote = "aa", magazine = "aab"
// Output: true
//
//
// Constraints:
//
// 1 <= ransomNote.length, magazine.length <= 105
// ransomNote and magazine consist of lowercase English letters.

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dict = new Dictionary<char, int>();

        for (var i = 0; i < magazine.Length; i++)
        {
            var c = magazine[i];
            if (!dict.TryGetValue(c, out var value))
                value = 0;

            dict[c] = value + 1;
        }

        for (var i = 0; i < ransomNote.Length; i++)
        {
            var c = ransomNote[i];

            if (!dict.TryGetValue(c, out var value))
                return false;

            value -= 1;

            if (value < 0)
                return false;

            dict[c] = value;
        }

        return true;
    }
}