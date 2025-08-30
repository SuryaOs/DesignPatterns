using System.Runtime.CompilerServices;

namespace Structural;
// treats single item and group of item with same interface
// when you need to perform same operations on leaf node and composite node consistently
public interface IFileSystem
{
    void PrintStructure(string indent);
    void Delete();
    int GetSize();
}
public class File : IFileSystem
{
    public string name;
    public int size;
    public File(string name, int size)
    {
        this.name = name;
        this.size = size;
    }
    public void PrintStructure(string indent)
    {
        Console.WriteLine($"{indent} - {name} ({size}kbs) ");
    }
    public int GetSize()
    {
        return size;
    }
    public void Delete()
    {
        Console.Write("Deleted SuccessFully");
    }
}
public class Folder : IFileSystem
{
    private string fileName;
    List<IFileSystem> _fileSystems = new();
    public Folder(string fileName)
    {
        this.fileName = fileName;
    }
    public void Add(IFileSystem fileSystem)
    {
        _fileSystems.Add(fileSystem);
    }
    public void PrintStructure(string indent)
    {
        Console.WriteLine($"{indent} + {fileName}/");
        foreach (var fs in _fileSystems)
        {
            fs.PrintStructure(indent + "  ");
        }
    }
    public int GetSize()
    {
        int size = 0;
        foreach (var fs in _fileSystems)
        {
            size += fs.GetSize();
        }
        return size;
    }
    public void Delete()
    {
        _fileSystems.ForEach(x => x.Delete());
    }
}