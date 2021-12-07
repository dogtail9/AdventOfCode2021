// Read all values from the file and store them in a string array
var lines = File.ReadAllLines("Input.txt");

// Don't count the first value, it will be less than int.MaxValue
int oldValue = int.MaxValue;
int counter = 0;

// We change the loop from a foreach to a for-loop because we only
// want to loop untill we don't have enough numbers left to calculate
// the sum and we also incresse the startIndex on each irritation.
for (int startIndex = 0; startIndex < lines.Length - 2; startIndex++)
{
    // Calculate the stopIndex. 
    // We have a sliding window of three values
    var stopIndex = startIndex + 3;

    // Take the three values in the sliding window.
    // Convert from string to int, add the numbers and store the sum.
    var value = lines[startIndex..stopIndex].Sum(v => int.Parse(v));

    // If the oldValue is less then the value the depth is increasing
    if (oldValue < value)
    {
        // Depth is increasing
        // Increment the counter by one
        counter++;

        // Debug output
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{value} (increased) {counter}");
    }
    else if(oldValue == value)
    {
        // Depth is not changing
        // Debug output
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{value} (no change) {counter}");
    }
    else
    {
        // Depth is decreasing
        // Debug output
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{value} (decreased) {counter}");
    }

    // Store the value in the oldValue so that we can compare the next value with the current
    oldValue = value;
}

// Show the result
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Counter: {counter}");
Console.ResetColor();