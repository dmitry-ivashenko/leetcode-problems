// 6. Zigzag Conversion
//
// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
// (you may want to display this pattern in a fixed font for better legibility)
//
// P   A   H   N
// A P L S I I G
// Y   I   R
// And then read line by line: "PAHNAPLSIIGYIR"
//
// Write the code that will take a string and make this conversion given a number of rows:
//
// string convert(string s, int numRows);
//
//
// Example 1:
//
// Input: s = "PAYPALISHIRING", numRows = 3
// Output: "PAHNAPLSIIGYIR"
// Example 2:
//
// Input: s = "PAYPALISHIRING", numRows = 4
// Output: "PINALSIGYAHRPI"
// Explanation:
// P     I    N
// A   L S  I G
// Y A   H R
// P     I
// Example 3:
//
// Input: s = "A", numRows = 1
// Output: "A"
//
//
// Constraints:
//
// 1 <= s.length <= 1000
// s consists of English letters (lower-case and upper-case), ',' and '.'.
// 1 <= numRows <= 1000

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || numRows >= s.Length)
        {
            return s;
        }

        var rows = new List<StringBuilder>();

        for (var i = 0; i < Math.Min(numRows, s.Length); i++)
        {
            rows.Add(new StringBuilder());
        }

        var currentRow = 0;
        var goingDown = false;

        foreach (var c in s)
        {
            rows[currentRow].Append(c);
            if (currentRow == 0 || currentRow == numRows - 1)
            {
                goingDown = !goingDown;
            }
            currentRow += goingDown ? 1 : -1;
        }

        var result = new StringBuilder();

        foreach (StringBuilder row in rows)
        {
            result.Append(row);
        }

        return result.ToString();
    }
}
