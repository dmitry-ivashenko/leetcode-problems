// 202. Happy Number
//
// Write an algorithm to determine if a number n is happy.
//
// A happy number is a number defined by the following process:
//
// Starting with any positive integer, replace the number by the sum of the squares of its digits.
// Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
// Those numbers for which this process ends in 1 are happy.
// Return true if n is a happy number, and false if not.
//
//
//
// Example 1:
//
// Input: n = 19
// Output: true
// Explanation:
// 12 + 92 = 82
// 82 + 22 = 68
// 62 + 82 = 100
// 12 + 02 + 02 = 1
// Example 2:
//
// Input: n = 2
// Output: false
//
//
// Constraints:
//
// 1 <= n <= 231 - 1

public class Solution
{
    private static readonly Dictionary<int, int> squares = new Dictionary<int, int>
    {
        {0, 0}, {1, 1}, {2, 4}, {3, 9}, {4, 16}, {5, 25}, {6, 36}, {7, 49}, {8, 64}, {9, 81}
    };

    public int GetNext(int n)
    {
        int totalSum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            totalSum += squares[digit];
            n /= 10;
        }
        return totalSum;
    }

    public bool IsHappy(int n)
    {
        var set = new HashSet<int>();

        while (n != 1 && !set.Contains(n))
        {
            set.Add(n);
            n = GetNext(n);
        }

        return n == 1;
    }
}
