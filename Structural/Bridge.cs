namespace Structural;
// extracts abstraction from implementation, allowing to vary indepedently

#region breaks SOLID
/* looks like it will break OCP and ISP when we add new Shape
    * add RenderRectangle to IRenderer
    * implement in all renderer
        * forcing to implement - breaks isp
        * modifying existing class by adding new method - breaks ocp 
    * add new shape (extending - so no breakage)
 */
#endregion
public interface IRenderer
{
    void RenderCircle(int radius);
    void RenderSquare(int side);
}
public class RasterRenderer : IRenderer
{
    public void RenderCircle(int radius)
    {
        Console.WriteLine($"Raster Circle : {Math.PI * radius * radius}");
    }
    public void RenderSquare(int side)
    {
        Console.WriteLine($"Raster Squre : {4 * side}");
    }
}
public class VectorRenderer : IRenderer
{
    public void RenderCircle(int radius)
    {
        Console.WriteLine($"Vector Circle : {Math.PI * radius * radius}");
    }
    public void RenderSquare(int side)
    {
        Console.WriteLine($"Vector Squre : {4 * side}");
    }
}
public abstract class Shape
{
    protected IRenderer _renderer;
    public Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }
    public abstract void Draw();
}
public class Circle : Shape
{
    private int radius;
    public Circle(IRenderer renderer, int radius) : base(renderer)
    {
       this.radius = radius;
    }
    public override void Draw()
    {
        _renderer.RenderCircle(radius);
    }
}
public class Square : Shape
{
    private int side;
    public Square(IRenderer renderer, int side) : base(renderer)
    {
        this.side = side;
    }
    public override void Draw()
    {
        _renderer.RenderSquare(side);
    }
}