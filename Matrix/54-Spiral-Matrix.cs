// 54. Spiral Matrix
// 
// Given an m x n matrix, return all elements of the matrix in spiral order.
// 
// Example 1:
// 
// Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
// Output: [1,2,3,6,9,8,7,4,5]
// 
// Example 2:
// 
// Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
// Output: [1,2,3,4,8,12,11,10,9,5,6,7]
//  
// 
// Constraints:
// 
// m == matrix.length
// n == matrix[i].length
// 1 <= m, n <= 10
// -100 <= matrix[i][j] <= 100

public class Solution 
{
    public enum Direction
    {
        Right,
        Down,
        Left,
        Up
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
    
    public struct Limits
    {
        public int top;
        public int bottom;
        public int left;
        public int right;
        
        public Limits(int[][] matrix)
        {
            top = -1;
            left = -1;
            right = matrix[0].Length;
            bottom = matrix.Length;
        }
        
        public bool Contains(Pos pos)
        {
            var isOut = pos.i <= top
                       || pos.i >= bottom
                       || pos.j <= left
                       || pos.j >= right;
            
            return !isOut;
        }
        
        public void MoveBorder(Direction dir)
        {
            if (dir == Direction.Right) left += 1;
            if (dir == Direction.Down) top += 1;
            if (dir == Direction.Left) right -= 1;
            if (dir == Direction.Up) bottom -= 1;
        }
        
        public override string ToString()
        {
            return $"{top}|{right}|{bottom}|{left}";
        }
    }
    
    public static Direction NextDirection(Direction dir)
    {
        if (dir == Direction.Right) return Direction.Down;
        if (dir == Direction.Down) return Direction.Left;
        if (dir == Direction.Left) return Direction.Up;
        if (dir == Direction.Up) return Direction.Right;
        
        return dir;
    }
    
    public static Pos MoveByDirection(Pos pos, Direction dir)
    {
        var i = pos.i;
        var j = pos.j;
        
        switch (dir)
        {
            case Direction.Right: j += 1; break;
            case Direction.Left: j -= 1; break;
            case Direction.Up: i -= 1; break;
            case Direction.Down: i += 1; break;
        }
        
        return new Pos(i, j);
    }
    
    public static bool MoveNext(ref Pos pos, ref Direction dir, ref Limits limits, int[][] matrix)
    {
        var nextPos = MoveByDirection(pos, dir);
        
        if (!limits.Contains(nextPos))
        {
            dir = NextDirection(dir);
            limits.MoveBorder(dir);
            nextPos = MoveByDirection(pos, dir);
        }
        
        pos = nextPos;
        
        return limits.Contains(pos);
    }
    
    public IList<int> SpiralOrder(int[][] matrix) 
    {
        var result = new List<int>();
        var pos = new Pos(0, 0);
        var direction = Direction.Right;
        var limits = new Limits(matrix);
        
        do
        {
            result.Add(matrix[pos.i][pos.j]);
        }
        while(MoveNext(ref pos, ref direction, ref limits, matrix));
        
        return result;
    }
}
