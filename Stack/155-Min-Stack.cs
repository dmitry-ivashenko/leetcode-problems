// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
// 
// Implement the MinStack class:
// 
// MinStack() initializes the stack object.
// void push(int val) pushes the element val onto the stack.
// void pop() removes the element on the top of the stack.
// int top() gets the top element of the stack.
// int getMin() retrieves the minimum element in the stack.
// You must implement a solution with O(1) time complexity for each function.
// 
//  
// 
// Example 1:
// 
// Input
// ["MinStack","push","push","push","getMin","pop","top","getMin"]
// [[],[-2],[0],[-3],[],[],[],[]]
// 
// Output
// [null,null,null,null,-3,null,0,-2]
// 
// Explanation
// MinStack minStack = new MinStack();
// minStack.push(-2);
// minStack.push(0);
// minStack.push(-3);
// minStack.getMin(); // return -3
// minStack.pop();
// minStack.top();    // return 0
// minStack.getMin(); // return -2
//  
// 
// Constraints:
// 
// - -2^31 <= val <= 2^31 - 1
// - Methods pop, top and getMin operations will always be called on non-empty stacks.
// - At most 3 * 104 calls will be made to push, pop, top, and getMin.

public class MinStack 
{
    private int[] data = new int[40000];
    private int[] info = new int[40000];
    private int index = -1;
    
    public MinStack() { }
    
    public void Push(int val) 
    {    
        index += 1;

        data[index] = val;

        if (index == 0)
            info[index] = val;
        else
            info[index] = val < info[index-1] ? val : info[index-1];        
    }
    
    public void Pop() 
    {
        index -= 1;
    }
    
    public int Top() 
    {
        return data[index];
    }
    
    public int GetMin() 
    {
        return info[index];
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */