namespace Structural;

// proxy is a wrapper object that client calls to access real object
// proxy can simply forward request to real object or authorize, or log the req before forwarding, or lazily load

public interface Image
{
    void Display();
}
public class HighResolutionImage : Image
{
    private string name;
    public byte[] file;
    public HighResolutionImage(string name)
    {
        this.name = name;
        LoadFromDisk(); // Eager Loading Image
    }
    public void Display()
    {
        Console.WriteLine($"Displaying {name}");
    }
    public void LoadFromDisk()
    {
        Console.WriteLine($"Loading {name} from disk....");
        Thread.Sleep(1000);
        file = new byte[10 * 1024 * 1024];
        Console.WriteLine($"{name} Loaded Successfully");
    }
}
public class ImageProxy : Image
{
    private HighResolutionImage image;
    private string name;
    public ImageProxy(string name)
    {
        this.name = name;
        Console.WriteLine($"Imae Proxy - {name}");
    }
    public void Display()
    {
        if (image == null) // cache proxy
        {
            image = new HighResolutionImage(name); // Lazy loading Image
        }
        image.Display();
    }
}