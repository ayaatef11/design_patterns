using System;
using System.Collections.Generic;

// Prototype Interface
public interface ICloneablePrototype
{
    ICloneablePrototype Clone();
}

// Concrete Prototype
public class ConcretePrototype : ICloneablePrototype
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICloneablePrototype Clone()
    {
        // Perform a shallow copy
        return (ICloneablePrototype)MemberwiseClone();
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}

// Client Code
class Program
{
    static void Main()
    {
        // Creating an instance of ConcretePrototype
        ConcretePrototype originalPrototype = new ConcretePrototype
        {
            Id = 1,
            Name = "Original"
        };

        // Cloning the original prototype
        ConcretePrototype clonedPrototype = (ConcretePrototype)originalPrototype.Clone();
        clonedPrototype.Name = "Cloned";

        // Displaying both instances
        Console.WriteLine("Original Prototype:");
        originalPrototype.Display();

        Console.WriteLine("\nCloned Prototype:");
        clonedPrototype.Display();
    }
}
