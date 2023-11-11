// 3. Longest Substring Without Repeating Characters
// 
// Given a string s, find the length of the longest 
// substring without repeating characters.
// 
// Example 1:
// 
// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3.
// Example 2:
// 
// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.
// Example 3:
// 
// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
//  
// 
// Constraints:
// 
// 0 <= s.length <= 5 * 104
// s consists of English letters, digits, symbols and spaces.

public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        var tmp = "";
        var maxLen = 0;
        var i = 0;
        var j = 0;
        var len = s.Length;

        if (s.Length == 1) return 1;

        while (i >= 0 && i < len && j >= 0 && j < len && i >= j)
        {    
            i++;
            if (i == j) continue;

            var substr = s.Substring(j, i-j);
            var set = new HashSet<char>(substr);

            if (set.Count != substr.Length)
            {
                j++;
            }

            if (i-j > maxLen)
            {
                maxLen = i-j;
            }
        }

        

        return maxLen;
    }
}
