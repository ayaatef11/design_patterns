using System;

// Target Interface
public interface ITarget
{
    void Request();
}

// Adaptee (Existing class)
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee's specific request");
    }
}

// Adapter
public class Adapter : ITarget
{
    private Adaptee adaptee;

    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

// Client Code
class Program
{
    static void Main()
    {
        // Using the Adaptee directly
        Adaptee adaptee = new Adaptee();
        adaptee.SpecificRequest();

        // Using the Adapter to make Adaptee compatible with ITarget
        ITarget target = new Adapter(adaptee);
        target.Request();
    }
}
