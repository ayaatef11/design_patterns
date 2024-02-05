using System;
using System.Collections.Generic;

// Component
public abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Display(int depth);
}

// Leaf
public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " " + name);
    }
}

// Composite
public class Composite : Component
{
    private List<Component> children = new List<Component>();

    public Composite(string name) : base(name)
    {
    }

    public void Add(Component component)
    {
        children.Add(component);
    }

    public void Remove(Component component)
    {
        children.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + "+ " + name);

        foreach (var child in children)
        {
            child.Display(depth + 2);
        }
    }
}

// Client Code
class Program
{
    static void Main()
    {
        // Creating leaf nodes
        Leaf leaf1 = new Leaf("Leaf 1");
        Leaf leaf2 = new Leaf("Leaf 2");
        Leaf leaf3 = new Leaf("Leaf 3");

        // Creating composite nodes
        Composite composite1 = new Composite("Composite 1");
        Composite composite2 = new Composite("Composite 2");

        // Adding leaf nodes to composite nodes
        composite1.Add(leaf1);
        composite1.Add(leaf2);

        composite2.Add(leaf3);

        // Adding composite nodes to another composite node
        Composite root = new Composite("Root");
        root.Add(composite1);
        root.Add(composite2);

        // Displaying the hierarchy
        root.Display(0);
    }
}
