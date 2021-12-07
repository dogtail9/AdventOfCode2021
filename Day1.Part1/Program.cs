// Read all values from the file and store them in a string array
var lines = File.ReadAllLines("Input.txt");

// Don't count the first value, it will be less than int.MaxValue
int oldValue = int.MaxValue;
int counter = 0;

foreach (var line in lines)
{
    // Convert from string to int
    var value = int.Parse(line);

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