// 14. Longest Common Prefix
//
// Write a function to find the longest common prefix string amongst an array of strings.
//
// If there is no common prefix, return an empty string "".
//
//
//
// Example 1:
//
// Input: strs = ["flower","flow","flight"]
// Output: "fl"
// Example 2:
//
// Input: strs = ["dog","racecar","car"]
// Output: ""
// Explanation: There is no common prefix among the input strings.
//
//
// Constraints:
//
// 1 <= strs.length <= 200
// 0 <= strs[i].length <= 200
// strs[i] consists of only lowercase English letters.

public class Solution
{
    public string GetPreffix(string preffix, string str)
    {
        var minLength = preffix.Length < str.Length ? preffix.Length : str.Length;
        var len = 0;

        for (var i = 0; i < minLength; i++)
        {
            if (preffix[i] != str[i] || i == minLength) break;
            len += 1;
        }

        return preffix.Substring(0, len);
    }

    public string LongestCommonPrefix(string[] strs)
    {
        var preffix = strs[0];

        for (var i = 1; i < strs.Length; i++)
        {
            preffix = GetPreffix(preffix, strs[i]);
        }

        return preffix;
    }
}