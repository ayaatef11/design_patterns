using System;

// Abstraction
public abstract class Shape
{
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}

// Implementor
public interface IRenderer
{
    void RenderCircle(float radius);
}

// Concrete Implementor A
public class RendererA : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Rendering Circle of radius {radius} using Renderer A.");
    }
}

// Concrete Implementor B
public class RendererB : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Rendering Circle of radius {radius} using Renderer B.");
    }
}

// Refined Abstraction
public class Circle : Shape
{
    private float radius;

    public Circle(float radius, IRenderer renderer) : base(renderer)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        renderer.RenderCircle(radius);
    }
}

// Client Code
class Program
{
    static void Main()
    {
        // Creating instances of different renderers
        IRenderer rendererA = new RendererA();
        IRenderer rendererB = new RendererB();

        // Creating instances of shapes with different renderers
        Shape circleA = new Circle(5, rendererA);
        Shape circleB = new Circle(7, rendererB);

        // Drawing shapes
        circleA.Draw();
        circleB.Draw();
    }
}
