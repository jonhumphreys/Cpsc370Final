using Xunit; // xUnit testing framework
using Cpsc370Final; // Namespace where Grid is defined
using System; // used to write to the console
using System.IO; // required for StringWriter (capturing the console output)

public class GridTests
{
    [Fact] // Marks this method as a test case
    public void DisplayGrid_OutputContainsExpectedGridElements_GridIsPrintedCorrectly()
    {
        // Arrange - Set up the test environment
        Grid grid = new Grid(); // Create a Grid instance
        
        string result = grid.DisplayGrid(); // Capture the printed console output

        Assert.Contains("║ 1 ║", result); // Check if the 9 boxes appears in the output
        Assert.Contains("║ 2 ║", result); 
        Assert.Contains("║ 3 ║", result); 
        Assert.Contains("║ 4 ║", result); 
        Assert.Contains("║ 5 ║", result); 
        Assert.Contains("║ 6 ║", result); 
        Assert.Contains("║ 7 ║", result); 
        Assert.Contains("║ 8 ║", result); 
        Assert.Contains("║ 9 ║", result); 
    }
}