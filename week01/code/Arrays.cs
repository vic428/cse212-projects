public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of doubles with size equal to 'length' to hold the right number of mulitples
         var result = new double[length];
        // 2. Loop from 1 up to and including the 'length'. Each iteration i represents the ith multiple of the number 
        for (int i = 1; i <= length; i++) {

            // 3 & 4. On each iteration, multiply 'number' by i and store the result in the array at index i-1 (since arrays are 0 indexed)
            result[i-1] = number * i;
        }
        // 4. After the loop, return the array of multiples
        return result;

        // 5. The time complexity of this function is O(n) where n is the length of the resulting array, 
        // since we have to compute each multiple once. The space complexity is also O(n) since we are storing n multiples in the array.
            
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Identify the slice that will omve to the front.

        // 2. Calculate the split index - where the last "amount" elements starts 
        var splitIndex = data.Count - amount;

        // 3. Extract the last "amount" elements to be moved to the front and store in a temp list
        var tail = data.GetRange(splitIndex, amount);

        // 4. Remove the last "amount" elements from the original list
        data.RemoveRange(splitIndex, amount);
        
        // 5. Insert the extracted elements at the beginning of the original list.
        data.InsertRange(0, tail);
    }
}
