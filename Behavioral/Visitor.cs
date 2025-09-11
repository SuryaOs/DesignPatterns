namespace Behavioral;

// it lets you to add operations to an object without modifying it.
// ex. a document has elements text, image, link. you want to add operations like render, export without modyfing elements

public interface IVisitor
{
    void Visit(Text text);
    void Visit(Image image);
    void Visit(Link link);
}
public interface IElement
{
    void Accept(IVisitor visitor);
}
public class Text : IElement
{
    public string content;
    public Text(string content) => this.content = content;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
public class Image : IElement
{
    public string path;
    public Image(string path) => this.path = path;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
public class Link : IElement
{
    public string url;
    public Link(string url) => this.url = url;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
public class Renderer : IVisitor
{
    public void Visit(Text text)
    {
        Console.WriteLine("Rendering text : " + text.content);
    }

    public void Visit(Image image)
    {
        Console.WriteLine("Rendering image from path : " + image.path);
    }

    public void Visit(Link link)
    {
        Console.WriteLine("Rendering image from url : " + link.url);
    }
}
