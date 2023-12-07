// 290. Word Pattern
//
// Given a pattern and a string s, find if s follows the same pattern.
//
// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
//
//
//
// Example 1:
//
// Input: pattern = "abba", s = "dog cat cat dog"
// Output: true
// Example 2:
//
// Input: pattern = "abba", s = "dog cat cat fish"
// Output: false
// Example 3:
//
// Input: pattern = "aaaa", s = "dog cat cat dog"
// Output: false
//
//
// Constraints:
//
// 1 <= pattern.length <= 300
// pattern contains only lower-case English letters.
// 1 <= s.length <= 3000
// s contains only lowercase English letters and spaces ' '.
// s does not contain any leading or trailing spaces.
// All the words in s are separated by a single space.

public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split(' ');

        if (words.Length != pattern.Length)
            return false;

        var charToWord = new Dictionary<char, string>();
        var wordToChar = new Dictionary<string, char>();

        for (var i = 0; i < words.Length; i++)
        {
            var pChar = pattern[i];
            var word = words[i];

            if (charToWord.TryGetValue(pChar, out var mappedWord))
            {
                if (mappedWord != word) return false;
            }
            else
            {
                if (wordToChar.ContainsKey(word)) return false;

                charToWord[pChar] = word;
                wordToChar[word] = pChar;
            }
        }

        return true;
    }
}
