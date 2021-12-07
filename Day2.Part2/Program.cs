// Read all Movements from the file and store them in a string array
var lines = File.ReadAllLines("Input.txt");

// Create the Submarine object
Submarine submarine = new Submarine();

// Loop through all the instructions on how to move the Submarine
foreach (var line in lines)
{
    // Create the current Movement
    var movement = new Movement(line);
    
    // Move the Submarine
    submarine.Move(movement);
}

// Show the result
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Horizontal Position: {submarine.HorizontalPosition} * Depth: {submarine.Depth} = {submarine.HorizontalPosition * submarine.Depth}");
Console.ResetColor();

public class Movement
{
    public Movement(string instruction)
    {
        // Split the string on a space char
        var i = instruction.Split(' ');

        // The first part of the string is the Direction.
        Direction = i[0];

        // The second part of the string is
        // the value the Submarine are going to move
        Units = Convert.ToInt32(i[1]);
    }

    // The direction the Submarine is going to move in
    public string Direction { get; set; }

    // The value of the movement
    public int Units { get; set; }
}

public class Submarine
{
    // The current horizontal position of the Submarine
    public int HorizontalPosition { get; set; } = 0;

    // The current depth of the Submarine
    public int Depth { get; set; } = 0;

    // The current aim of the Submarine
    public int Aim { get; set; } = 0;

    // The only way to move the Submarine in any direction
    public void Move(Movement movment)
    {
        // What Direction is the Submarine moving?
        switch (movment.Direction)
        {
            // Move forward
            case "forward":
                Forward(movment.Units);
                break;

            // Move up
            case "up":
                Up(movment.Units);
                break;

            // Move down
            case "down":
                Down(movment.Units);
                break;
        }

        // Debug output
        Console.WriteLine($"Move: {movment.Direction}, Units: {movment.Units}, Aim: {Aim}, HorizontalPosition: {HorizontalPosition}, Depth: {Depth}");
    }

    // Increase the HorizontalPosition and Depth by the Units of the Movement and the Aim
    private void Forward(int units)
    {
        HorizontalPosition += units;
        Depth = Depth + (Aim * units);
    }

    // Decrease the Aim of the Submarine by the Units of the Movement
    private void Up(int units)
    {
        Aim -= units;
    }

    // Increase the Aim of the Submarine by the Units of the Movement
    private void Down(int units)
    {
        Aim += units;
    }
}
