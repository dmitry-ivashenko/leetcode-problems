// 69. Sqrt(x)
//
// Given a non-negative integer x, return the square root of x rounded down to the nearest integer.
// The returned integer should be non-negative as well.
//
// You must not use any built-in exponent function or operator.
//
// For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
//
//
// Example 1:
//
// Input: x = 4
// Output: 2
// Explanation: The square root of 4 is 2, so we return 2.
// Example 2:
//
// Input: x = 8
// Output: 2
// Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
//
//
// Constraints:
//
// 0 <= x <= 231 - 1

public class Solution
{
    public int MySqrt(int x)
    {
        if (x <= 1)
            return x;

        var low = 0;
        var high = x;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            var value = x / mid;

            if (value == mid)
                return mid;
            else if (value < mid)
                high = mid - 1;
            else
                low = mid + 1;
        }

        return high;
    }
}