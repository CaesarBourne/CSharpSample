// See https://aka.ms/new-console-template for more information
using System.Text;

class NewMan
{

    public string GetName(int ID)
    {
        string[] names = ["Spencer", "Sally", "Doug"];

        if (ID < names.Length)
            return names[ID];
        else
            return String.Empty;
    }

    // Console.WriteLine("Hello, Emmanuel!");
    // string adjective = "resourceful";
    // Console.WriteLine($"Caesra is smart and is hungry and {adjective} ");

    // string work = "  Hello World   ";
    // string newWork = work.TrimStart();
    // Console.WriteLine(newWork.Contains("O"));
    // int a = 18;
    // int b = 6;
    // int c = a + b;
    // Console.WriteLine(c);


    // var fibList = new List<int> { 1, 1 };

    // // while (fibList.Count < 20)
    // // {
    // //     fibList.Add(fibList[fibList.Count - 2] + fibList[fibList.Count - 1]);

    // // }

    // // foreach (var val in fibList)
    // // {
    // //     Console.WriteLine("Fib " + val);


    // // }

    // StringBuilder builder = new();
    // builder.AppendLine("The following arguments are passed:");

    // // Display the command line arguments using the args variable.
    // foreach (var arg in args)
    // {
    //     builder.AppendLine($"Argument={arg}");
    // }

    // Console.WriteLine(builder.ToString());

    // Return a success code.
    static void TestFinally()
    {
        FileStream? file = null;
        //Change the path to something that works on your machine.
        FileInfo fileInfo = new System.IO.FileInfo("./file.txt");

        try
        {
            file = fileInfo.OpenWrite();
            file.WriteByte(0xF);
        }
        finally
        {
            // Closing the file allows you to reopen it immediately - otherwise IOException is thrown.
            file?.Close();
        }

        try
        {
            file = fileInfo.OpenWrite();
            Console.WriteLine("OpenWrite() succeeded");
        }
        catch (IOException)
        {
            Console.WriteLine("OpenWrite() failed");
        }
    }

}

public record Person(string FirstName, string LastName)
{
    public required string[] PhoneNumbers { get; init; }
}

public class Program
{
    public static void Main()
    {
        Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
        Console.WriteLine(person1);
        // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

        Person person2 = person1 with { FirstName = "John" };
        Console.WriteLine(person2);
        // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with { PhoneNumbers = new string[1] };
        Console.WriteLine(person2);
        // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
        Console.WriteLine(person1 == person2); // output: False

        person2 = person1 with { };
        Console.WriteLine(person1 == person2); // output: True
    }
}

public class Car : IEquatable<Car>
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }

    // Implementation of IEquatable<T> interface
    public bool Equals(Car? car)
    {
        return (this.Make, this.Model, this.Year) ==
            (car?.Make, car?.Model, car?.Year);
    }
}