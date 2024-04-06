// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, Emmanuel!");
string adjective = "resourceful";
Console.WriteLine($"Caesra is smart and is hungry and {adjective} ");

string work = "  Hello World   ";
string newWork = work.TrimStart();
Console.WriteLine(newWork.Contains("O"));
int a = 18;
int b = 6;
int c = a + b;
Console.WriteLine(c);


var fibList = new List<int> { 1, 1 };

// while (fibList.Count < 20)
// {
//     fibList.Add(fibList[fibList.Count - 2] + fibList[fibList.Count - 1]);

// }

// foreach (var val in fibList)
// {
//     Console.WriteLine("Fib " + val);


// }

StringBuilder builder = new();
builder.AppendLine("The following arguments are passed:");

// Display the command line arguments using the args variable.
foreach (var arg in args)
{
    builder.AppendLine($"Argument={arg}");
}

Console.WriteLine(builder.ToString());

// Return a success code.
return 0;