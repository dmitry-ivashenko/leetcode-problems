// 20. Valid Parentheses
//
// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
//
// An input string is valid if:
//
// Open brackets must be closed by the same type of brackets.
// Open brackets must be closed in the correct order.
// Every close bracket has a corresponding open bracket of the same type.
//
//
// Example 1:
//
// Input: s = "()"
// Output: true
// Example 2:
//
// Input: s = "()[]{}"
// Output: true
// Example 3:
//
// Input: s = "(]"
// Output: false
//
//
// Constraints:
//
// 1 <= s.length <= 104
// s consists of parentheses only '()[]{}'.

public class Solution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            var symbol = s[i];
            var expected = symbol == ')' ? '('
                            : symbol == ']' ? '['
                            : symbol == '}' ? '{'
                            : '0';

            if (stack.Count == 0 || expected == '0')
            {
                stack.Push(symbol);
                continue;
            }

            var top = stack.Peek();

            if (top == expected)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(symbol);
            }
        }

        return stack.Count == 0;
    }
}
