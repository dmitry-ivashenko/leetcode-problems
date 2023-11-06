// 498. Diagonal Traverse
// 
// Given an m x n matrix mat, return an array of all the elements of the array in a diagonal order.
// 
// Example 1:
// 
// Input: mat = [[1,2,3],[4,5,6],[7,8,9]]
// Output: [1,2,4,7,5,3,6,8,9]
// 
// Example 2:
// 
// Input: mat = [[1,2],[3,4]]
// Output: [1,2,3,4]
//  
// Constraints:
// 
// m == mat.length
// n == mat[i].length
// 1 <= m, n <= 104
// 1 <= m * n <= 104
// -105 <= mat[i][j] <= 105

public class Solution 
{
    public enum Direction
    {
        Left,
        Right
    }
    
    public struct Pos
    {
        public int i;
        public int j;
        
        public Pos(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
    
    public static bool OutOfRange(int[][] mat, int i, int j)
    {
        if (mat.Length == 0 || mat[0].Length == 0) return true;
        
        if (i >= mat.Length || j >= mat[0].Length) return true;
        
        if (i < 0 || j < 0) return true;
        
        return false;
    }
    
    public static bool MoveForward(ref Pos pos, ref Direction direction, int[][] mat)
    {
        var i = pos.i;
        var j = pos.j;
        var maxI = mat.Length - 1;
        var maxJ = mat[0].Length - 1;
        
        if (direction == Direction.Left)
        {
            i += 1;
            j -= 1;
        }
        else
        {
            i -= 1;
            j += 1;
        }
        
        if (OutOfRange(mat, i, j))
        {
            direction = direction == Direction.Right ? Direction.Left : Direction.Right;
            
            i = pos.i;
            j = pos.j;
            
            if (direction == Direction.Left)
            {
                if (j < maxJ) j += 1;
                else i += 1;
            }
            else
            {
                if (i < maxI) i += 1;
                else j += 1;
            }
        }
        
        pos = new Pos(i, j);
        
        return !OutOfRange(mat, i, j);
    }
    
    public int[] FindDiagonalOrder(int[][] mat) 
    {
        int[] result = new int[mat.Length * mat[0].Length];
        var pos = new Pos(0, 0);
        var direction = Direction.Right;
        var i = 0;
        
        do
        {
            result[i++] = mat[pos.i][pos.j];
        }
        while (MoveForward(ref pos, ref direction, mat));
        
        return result;
    }
}
