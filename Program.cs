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

// WorkItem implicitly inherits from the Object class.
public class WorkItem
{
    // Static field currentID stores the job ID of the last WorkItem that
    // has been created.
    private static int currentID;

    //Properties.
    protected int ID { get; set; }
    protected string Title { get; set; }
    protected string Description { get; set; }
    protected TimeSpan jobLength { get; set; }

    // Default constructor. If a derived class does not invoke a base-
    // class constructor explicitly, the default constructor is called
    // implicitly.
    public WorkItem()
    {
        ID = 0;
        Title = "Default title";
        Description = "Default description.";
        jobLength = new TimeSpan();
    }

    // Instance constructor that has three parameters.
    public WorkItem(string title, string desc, TimeSpan joblen)
    {
        this.ID = GetNextID();
        this.Title = title;
        this.Description = desc;
        this.jobLength = joblen;
    }

    // Static constructor to initialize the static member, currentID. This
    // constructor is called one time, automatically, before any instance
    // of WorkItem or ChangeRequest is created, or currentID is referenced.
    static WorkItem() => currentID = 0;

    // currentID is a static field. It is incremented each time a new
    // instance of WorkItem is created.
    protected int GetNextID() => ++currentID;

    // Method Update enables you to update the title and job length of an
    // existing WorkItem object.
    public void Update(string title, TimeSpan joblen)
    {
        this.Title = title;
        this.jobLength = joblen;
    }

    // Virtual method override of the ToString method that is inherited
    // from System.Object.
    public override string ToString() =>
        $"{this.ID} - {this.Title}";
}

// ChangeRequest derives from WorkItem and adds a property (originalItemID)
// and two constructors.
public class ChangeRequest : WorkItem
{
    protected int originalItemID { get; set; }

    // Constructors. Because neither constructor calls a base-class
    // constructor explicitly, the default constructor in the base class
    // is called implicitly. The base class must contain a default
    // constructor.

    // Default constructor for the derived class.
    public ChangeRequest() { }

    // Instance constructor that has four parameters.
    public ChangeRequest(string title, string desc, TimeSpan jobLen,
                         int originalID)
    {
        // The following properties and the GetNexID method are inherited
        // from WorkItem.
        this.ID = GetNextID();
        this.Title = title;
        this.Description = desc;
        this.jobLength = jobLen;

        // Property originalItemID is a member of ChangeRequest, but not
        // of WorkItem.
        this.originalItemID = originalID;
    }
}