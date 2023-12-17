// 35. Search Insert Position
//
// Given a sorted array of distinct integers and a target value, return the index if the target is found.
// If not, return the index where it would be if it were inserted in order.
//
// You must write an algorithm with O(log n) runtime complexity.
//
// Example 1:
//
// Input: nums = [1,3,5,6], target = 5
// Output: 2
// Example 2:
//
// Input: nums = [1,3,5,6], target = 2
// Output: 1
// Example 3:
//
// Input: nums = [1,3,5,6], target = 7
// Output: 4
//
// Constraints:
//
// 1 <= nums.length <= 104
// -104 <= nums[i] <= 104
// nums contains distinct values sorted in ascending order.
// -104 <= target <= 104

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int from = 0;
        int to = nums.Length - 1;

        while (from <= to)
        {
            int index = from + (to - from) / 2;
            int value = nums[index];

            if (target == value)
                return index;
            else if (target > value)
                from = index + 1;
            else
                to = index - 1;
        }

        return from;
    }
}
