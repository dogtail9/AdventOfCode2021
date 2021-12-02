# Advent Of Code 2021

My solutions in C# to [Advent Of Code](https://adventofcode.com/) challenges.
I use Visual Studio 2022 and .NET 6.

## Day 1 / Part 1

We store the list of depth values in a text file `Input.txt`. 
One value per line.
Remember to set `Copy to Output Directory` to `Copy if newer` 
on the `Input.txt` file.

![Copy if newer](Images/Day1.png)

### Code

```C#
// Read all values from the file
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
```

### Output

```cmd
...
8072 (increased) 1558
8067 (decreased) 1558
8056 (decreased) 1558
8064 (increased) 1559
8075 (increased) 1560
8078 (increased) 1561
8081 (increased) 1562
8112 (increased) 1563
8127 (increased) 1564
Counter: 1564
```

### Summary

We start with a really big number `int.MaxValue` as the 
initial value of the variable `oldValue` because the 
first `value` in our list of values can't be `increased`.

We loop through all values and compare the `oldValue` with 
the current `value` and if the `oldValue` is less then 
the current `value` the depth increases and we increment 
the `counter` by one.

Last we print the `counter` to the Console.

## Day 1 / Part 2

In Part 2 we will use a sliding window of three values
to see how the depth changes.

### Code

```C#
// Read all values from the file and stor them in a string array
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
```

# Output
```cmd
...
24141 (increased) 1602
24141 (no change) 1602
24141 (no change) 1602
24144 (increased) 1603
24167 (increased) 1604
24191 (increased) 1605
24210 (increased) 1606
24209 (decreased) 1606
24195 (decreased) 1606
24187 (decreased) 1606
24195 (increased) 1607
24217 (increased) 1608
24234 (increased) 1609
24271 (increased) 1610
24320 (increased) 1611
Counter: 1611
```

### Summary

We change the loop from a `foreach` to a `for` loop 
to get the `startIndex` of the sliding window.

To get three values insted of one when we compare we are using 
`lines[startIndex..stopIndex]` syntax to create a new collection
with just the three values in our sliding window.

To sum the three values we need to convert from `string` to `int` 
as before with `int.Parse()` and we use the method `IEnumerable<T>.Sum()` 
to add the three numbers in the collection before we compare with 
the `oldValue` as in we do in Part 1.
